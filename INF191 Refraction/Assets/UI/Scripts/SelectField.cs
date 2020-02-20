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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDisplaying && Input.GetMouseButton(0))
        {
            StartCoroutine(display());
        }
    }

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
