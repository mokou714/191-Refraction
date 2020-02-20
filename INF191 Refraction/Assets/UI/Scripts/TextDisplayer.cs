using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextDisplayer : MonoBehaviour
{
    public float displaySpeed;
    public Text textField;
    public string textFilePath;


    bool isDisplaying = false;
    string textContent;
   

    // Start is called before the first frame update
    void Start(){
        StreamReader reader = new StreamReader(textFilePath);
        textContent = reader.ReadToEnd();
        reader.Close();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDisplaying && Input.GetMouseButtonDown(0))
        {
            Debug.Log("!!!!");
            StartCoroutine(display());
        }
    }

    IEnumerator display()
    {
        isDisplaying = true;
        textField.text = "";
        for(int i = 0; i < textContent.Length; ++i) { 
            textField.text += textContent[i];
            yield return new WaitForSecondsRealtime(0.1f / displaySpeed);
        }
        isDisplaying = false;
    }
}
