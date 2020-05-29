using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Security.Cryptography;
using Newtonsoft.Json;

public class LoginManager : MonoBehaviour
{
    [SerializeField] private InputField _accountIdField;
    [SerializeField] private InputField _passwordField;
    [SerializeField] private GameObject _loginFailedUI;
    [SerializeField] private sceneManager _sceneManager;

    private void Awake()
    {
        _sceneManager.SetPortrait();
    }

    public void OnSubmit()
    {
        try
        {
            if (!Directory.Exists("./Users/" + _accountIdField.text))
            {
                LoginFailed("Invalid Username");
                return;
            }

            var path = "./Users/" + _accountIdField.text + "/data.json";
            var json = File.ReadAllText(path);
            var userData = JsonConvert.DeserializeObject<UserData>(json);

            var sha256 = SHA256.Create();
            var pwHashValue = sha256.ComputeHash(System.Text.Encoding.ASCII.GetBytes(_passwordField.text));
            
            if (pwHashValue.Length == userData.password.Length)
            {
                for (var i = 0; i < pwHashValue.Length;++i)
                {
                    if (pwHashValue[i] != userData.password[i])
                    {
                        LoginFailed("Invalid Password");
                        return;
                    }
                }
                Data.userData = new UserData();
                Data.userData.CopyUserData(userData);
                LoginSucceeded();
            }
            else
            {
                LoginFailed("Invalid Password");
            }

        }
        catch (IOException)
        {
            Debug.Log("Unknown Exception: Cannot open user data file.");
        }
    }

    private void LoginFailed(string msg)
    {
        Debug.Log(msg);
        _loginFailedUI.SetActive(true);
    }

    private void LoginSucceeded()
    {
        Debug.Log("Login Success");
        
        //employer logged in
        if (Data.userData.isEmployer)
        {
            //employer account setup
            if(Data.userData.accountSetupComplete)
                _sceneManager.LoadInterviewPortal();
            //interview portal
            else
                _sceneManager.LoadAccountSetupStage();
        }
        //candidate logged in
        else if(!Data.userData.accountSetupComplete)
            _sceneManager.LoadAccountSetupStage();
        else if(!Data.userData.quizComplete)
            _sceneManager.LoadQuiz();
        else
            _sceneManager.LoadMainGameStage();
    }
    
}