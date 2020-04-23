using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Clickable : MonoBehaviour, IPointerClickHandler
{
    public bool isSelected;
    [SerializeField] private Clickable[] cancelOut;
    [SerializeField] private Color selectedColor;
    private Color _defaultColor;
    private Image _image;
    
    

    void Start()
    {
        _image = GetComponent<Image>();
        _defaultColor = _image.color;
    }

    public void Cancel()
    {
        _image.color = _defaultColor;
        isSelected = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isSelected = true;
        _image.color = selectedColor;
        foreach (var clickable in cancelOut)
        {
            clickable.Cancel();
        }
    }
}
