using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillCardFrontBack : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    [SerializeField] private SkillCard _skillCard;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _skillCard.GetPointerUp();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _skillCard.GetPointerDown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //_skillCard.GetPointerUp();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _skillCard.GetPointerClick();
    }
}
