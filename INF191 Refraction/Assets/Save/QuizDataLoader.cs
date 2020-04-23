using UnityEngine;
using UnityEngine.UI;
public class QuizDataLoader : DataLoader
{
    [SerializeField] private Text welcomeText;
    protected override void LoadData()
    {
        if(Data.userData != null)
            welcomeText.text = "Hi " +  Data.userData.firstName + "!";
    }
}