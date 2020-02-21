using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public Text counter;
    public List<SelectField> selections = new List<SelectField>();
    [SerializeField] string[] answers;
    int index;
    int size;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        size = selections.Count;
        answers = new string[size];
        StartQuiz();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartQuiz()
    {
        if (size > 0)
        {
            counter.text = "#" + (index+1).ToString();
            selections[index].gameObject.SetActive(true);
        }
    }

    //called by select field
    public void SetAnswser(string answer)
    {
        answers[index] = answer;
    }
    public void Next()
    {
        selections[index].gameObject.SetActive(false);
        if (index + 1 >= size)
            return;
        selections[++index].gameObject.SetActive(true);
        counter.text = "#" + (index + 1).ToString();
    }
}
