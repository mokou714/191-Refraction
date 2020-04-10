using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackgroundClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] MainDeskInterface mainDeskInterface;

    public void OnPointerClick(PointerEventData eventData)
    {
        var currentDeskElement = mainDeskInterface.GetCurrentDeskElement();
        if (currentDeskElement != null)
        {
            mainDeskInterface.GetCurrentDeskElement().Back();
            mainDeskInterface.SetCurrentDeskElement(null);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
