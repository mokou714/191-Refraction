using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
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
        SceneManager.LoadScene(0);
    }

    public void LoadCharaterCreationStage()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainGameStage()
    {
        SceneManager.LoadScene(2);
    }
}
