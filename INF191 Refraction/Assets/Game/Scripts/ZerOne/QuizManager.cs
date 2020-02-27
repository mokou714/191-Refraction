using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<RadioBtnField> pages = new List<RadioBtnField>();
    [SerializeField] string[] answers;
    [SerializeField] sceneManager SceneManager;
    int index;
    int size;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        size = pages.Count;
        answers = new string[size];
        StartQuiz();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartQuiz()
    {
        if (size > 1)
        {
            pages[index].gameObject.SetActive(true);
        }
    }

    //called by select field
    public void SetAnswser(string answer)
    {
        answers[index] = answer;
    }
    public void NextPage()
    {
        pages[index].gameObject.SetActive(false);
        if (index + 1 >= size)
        {
            EndQuiz();
            return;
        }
        pages[++index].gameObject.SetActive(true);
    }

    public void EndQuiz()
    {
        SceneManager.LoadMainGameStage();
    }


}
