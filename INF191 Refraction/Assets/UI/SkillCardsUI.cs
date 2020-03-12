using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillCardsUI : DeskInterfaceElement, IPointerClickHandler
{
    [SerializeField] GameObject UI;
    [SerializeField] GameObject Text;
    [SerializeField] HeaderManager headerManager;
    [SerializeField] MainDeskInterface mainDeskInterface;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (mainDeskInterface.GetCurrentDeskElement() != null) return;
        UI.SetActive(true);
        Text.SetActive(false);
        headerManager.OnSkillCards();
        mainDeskInterface.SetCurrentDeskElement(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Back()
    {
        UI.SetActive(false);
        Text.SetActive(true);
        mainDeskInterface.SetCurrentDeskElement(this);
        headerManager.OnDesk();

    }

   
}
