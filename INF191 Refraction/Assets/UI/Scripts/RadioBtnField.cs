using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioBtnField : MonoBehaviour
{
    [SerializeField] List<Toggle> selections;
    bool[] result;

    // Start is called before the first frame update
    void Start()
    {
        result = new bool[selections.Count];
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Select(int index)
    {
        result[index] = selections[index].isOn;

        //hard coded for selection cancel out each other
        if(index%2 == 0)
        {
            if(selections[index].isOn)
                selections[index + 1].isOn = false;
        }
        else
        {
            if (selections[index].isOn)
                selections[index - 1].isOn = false;
        }


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
