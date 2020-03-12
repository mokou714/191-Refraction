using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDeskInterface : MonoBehaviour
{
    DeskInterfaceElement currentDeskElement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrentDeskElement(DeskInterfaceElement deskInterfaceElement )
    {
        currentDeskElement = deskInterfaceElement;
    }

    public DeskInterfaceElement GetCurrentDeskElement()
    {
        return currentDeskElement;
    }
}
