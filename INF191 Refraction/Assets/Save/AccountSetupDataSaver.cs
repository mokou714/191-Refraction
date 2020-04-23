using UnityEngine;
using UnityEngine.UI;

public class AccountSetupDataSaver : DataSaver
{
    [SerializeField] private Clickable maleProfile;
    [SerializeField] private Clickable femaleProfile;
    [SerializeField] private InputField firstName;
    [SerializeField] private InputField lastName;
    [SerializeField] private sceneManager _sceneManager;
    

    public void LoadNextScene()
    {
        if(Data.userData == null || !Data.userData.quizComplete)
            _sceneManager.LoadQuiz();
        else
            _sceneManager.LoadMainGameStage();

    }
    
    protected override void SaveData()
    {
        if (Data.userData == null) return;
        Data.userData.profileImageIndex = maleProfile.isSelected ? 0 : 1;
        Data.userData.firstName = firstName.text;
        Data.userData.lastName = lastName.text;
        Data.userData.accountSetupComplete = true;
    }
}
