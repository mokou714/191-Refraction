using UnityEngine;
using UnityEngine.UI;

public class AccountSetupDataSaver : MonoBehaviour
{
    [SerializeField] private Clickable maleProfile;
    [SerializeField] private Clickable femaleProfile;
    [SerializeField] private InputField firstName;
    [SerializeField] private InputField lastName;
    [SerializeField] private sceneManager _sceneManager;
    

    public void LoadNextScene()
    {
        UpdataUserData();
        
        if(Data.userData.isEmployer)
            _sceneManager.LoadInterviewPortal();
        else if(Data.userData == null || !Data.userData.quizComplete)
            _sceneManager.LoadQuiz();
        else
            _sceneManager.LoadMainGameStage();

    }
    
    private void UpdataUserData()
    {
        if (Data.userData == null) return;
        Debug.Log("Updated user data");
        Data.userData.profileImageIndex = maleProfile.isSelected ? 0 : 1;
        Data.userData.firstName = firstName.text;
        Data.userData.lastName = lastName.text;
        Data.userData.accountSetupComplete = true;
    }
}
