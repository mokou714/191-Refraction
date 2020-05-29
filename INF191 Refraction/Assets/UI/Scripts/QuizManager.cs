using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<RadioBtnField> pages = new List<RadioBtnField>();
    public List<PageBubbleSign> bubbleSigns = new List<PageBubbleSign>();
    [SerializeField] string[] answers;
    [SerializeField] sceneManager _sceneManager;
    private int _index;
    private int _size;

    // Start is called before the first frame update
    void Start()
    {
        _index = 0;
        _size = pages.Count;
        answers = new string[_size];
        StartQuiz();
    }

    public void StartQuiz()
    {
        if (_size > 1)
        {
            pages[_index].gameObject.SetActive(true);
        }
    }

    //called by select field
    public void SetAnswer(string answer)
    {
        answers[_index] = answer;
    }
    public void NextPage()
    {
        pages[_index].gameObject.SetActive(false);
        bubbleSigns[_index].Deselect();
        if (_index + 1 >= _size)
        {
            EndQuiz();
            return;
        }
        pages[++_index].gameObject.SetActive(true);
        bubbleSigns[_index].Select();
    }

    public void ToPage(int index)
    {
        pages[_index].gameObject.SetActive(false);
        bubbleSigns[_index].Deselect();
        
        _index = index;
        pages[_index].gameObject.SetActive(true);
    }

    private void EndQuiz()
    {
        Data.userData.quizComplete = true;
        _sceneManager.LoadMainGameStage();
    }
}
