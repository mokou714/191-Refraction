using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioBtnField : MonoBehaviour
{
    public string prompt;
    public List<Toggle> selections;

    [SerializeField]Text promptText;
    bool[] result;

    // Start is called before the first frame update
    void Start()
    {
        result = new bool[selections.Count];
        promptText.text = prompt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Select(int index)
    {
        result[index] = true;

        //debug
        //for(int i = 0; i < result.Length; ++i)
        //{
        //    if (result[i])
        //        Debug.Log("T");
        //    else
        //        Debug.Log("F");
        //}
    }

    public void Submit()
    {
        gameObject.SetActive(false);
    }
}
