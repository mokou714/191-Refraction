using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PageBubbleSign : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private int pageIndex;
    [SerializeField] private QuizManager quizManager;
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color hoverColor;
    private Image _bubbleImage;
    private Color _defaultColor;
    private bool _isSelected = false;
    void Start()
    {
        _bubbleImage = GetComponent<Image>();
        _defaultColor = _bubbleImage.color;
        if(pageIndex == 0)
            Select();
    }

    public void Select()
    {
        _isSelected = true;
        _bubbleImage.color = selectedColor;
    }

    public void Deselect()
    {
        _isSelected = false;
        _bubbleImage.color = _defaultColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isSelected) return;
        Select();
        quizManager.ToPage(pageIndex);
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_isSelected) return;
        _bubbleImage.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_isSelected) return;
        _bubbleImage.color = _defaultColor;
    }
}
