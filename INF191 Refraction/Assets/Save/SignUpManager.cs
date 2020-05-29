using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Security.Cryptography;
using Newtonsoft.Json;

public class SignUpManager : MonoBehaviour
{
    [SerializeField] private InputField _accountIdField;
    [SerializeField] private InputField _passwordField;
    [SerializeField] private GameObject _signUpUI;
    [SerializeField] private Text errorText;
    [SerializeField] private Toggle isEmployer;
    public void OnSubmit()
    {
        var path = "./Users/" + _accountIdField.text;
        
        if (Directory.Exists(path))
        {
            errorText.enabled = true;
            errorText.text = "User already exists";
            return;
        }
        Directory.CreateDirectory(path);
        path += "/data.json";
        
        var fileWriter = File.CreateText(path);
        var sha256 = SHA256.Create();
        var pwHashValue = sha256.ComputeHash(System.Text.Encoding.ASCII.GetBytes(_passwordField.text));

        var userData = new UserData();
        userData.accountId = _accountIdField.text;
        userData.password = pwHashValue;
        userData.isEmployer = isEmployer.isOn;

        var json = JsonConvert.SerializeObject(userData);
        Debug.Log(json);
        fileWriter.WriteLine(json);
        fileWriter.Close();
        _signUpUI.SetActive(false);
    }
}
