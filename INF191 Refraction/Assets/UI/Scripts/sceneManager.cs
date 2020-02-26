using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    [SerializeField]int PortraitWidth;
    [SerializeField]int PortraitHeight;
    [SerializeField]int LandscapeWidth;
    [SerializeField]int LandscapeHeight;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
}
