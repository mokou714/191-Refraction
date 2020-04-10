using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    static int PortraitWidth;
    static int PortraitHeight;
    static int LandscapeWidth;
    static int LandscapeHeight;

    public void LoadLoginStage()
    {
        Screen.SetResolution(PortraitWidth, PortraitHeight, false);
        SceneManager.LoadScene(0);
    }

    public void LoadCharaterCreationStage()
    {
        Screen.SetResolution(PortraitWidth, PortraitHeight, false);
        SceneManager.LoadScene(1);
    }

    public void LoadMainGameStage()
    {
        Screen.SetResolution(LandscapeWidth, LandscapeHeight, false);
        SceneManager.LoadScene(2);
    }

    public void LoadZerOne()
    {
        Screen.SetResolution(LandscapeWidth, LandscapeHeight, false);
        SceneManager.LoadScene(3);
    }

    public void LoadQuiz()
    {
        Screen.SetResolution(PortraitWidth, PortraitHeight, false);
        SceneManager.LoadScene(4);
    }
}
