using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectField : MonoBehaviour
{
    public string prompt;
    public Text promptField;
    public float displaySpeed;
    public List<Button> selections;

    bool isDisplaying = false;
    string selected = null;
    QuizManager quizManager = null;


    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent && transform.parent.GetComponent<QuizManager>())
            quizManager = transform.parent.GetComponent<QuizManager>();
    }

    private void OnEnable()
    {
        Show();
    }

    //Public
    public void Select(string selection)
    {
        selected = selection;
        EndSelect();
    }

    public void EndSelect()
    {
        if (quizManager)
        {
            quizManager.SetAnswer(selected);
            quizManager.NextPage();
        }
    }

    public void Show()
    {
        if (!isDisplaying)
        {
            StartCoroutine(display());
        }
    }


    //Coroutines
    IEnumerator display()
    {
        isDisplaying = true;
        promptField.text = "";
        for (int i = 0; i < prompt.Length; ++i)
        {
            promptField.text += prompt[i];
            yield return new WaitForSecondsRealtime(0.1f / displaySpeed);
        }
        isDisplaying = false;
    }
}
