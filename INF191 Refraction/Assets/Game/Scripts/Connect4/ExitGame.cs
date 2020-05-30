using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    [SerializeField] private sceneManager sceneManager;
    public void Exit()
    {
        if (Data.userData is null || !Data.userData.isEmployer)
        {
            sceneManager.LoadMainGameStage();
        }
        else
        {
            sceneManager.LoadInterviewPortal();
        }
    }
}
