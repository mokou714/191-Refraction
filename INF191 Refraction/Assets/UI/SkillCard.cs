using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillCard : MonoBehaviour
{
    [SerializeField] private Vector3 displaySize;
    [SerializeField] private float rotationSensitivity;
    [SerializeField] private float transitionSpeed;
    [SerializeField] private Image cardImage;
    [SerializeField] private GameObject front;
    [SerializeField] private GameObject back;
    
    //status
    private bool _isDisplaying;
    private bool _inTransition;
    [SerializeField]private bool _isDragging;
    
    //helper data
    private Vector3 _screenCenter;
    private Vector3 _defaultPosition;
    private Vector3 _defaultScale;
    private Quaternion _defaultRotation;
    private Color _defaultCardImageColor;
    
    private Vector3 _targetPosition;
    private Vector3 _targetScale;
    [SerializeField]private Transform _parent;
    private Vector3 _lastMousePosition;

    //other component
    [SerializeField] private SkillCardUI _skillCardUI;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _screenCenter = _targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        _screenCenter.z = _targetPosition.z = _skillCardUI.SubCanvas.transform.position.z;
        _defaultPosition = transform.position;
        _defaultScale = _targetScale = transform.localScale;
        _defaultRotation = transform.rotation;
        _defaultCardImageColor = cardImage.color;
        _parent = transform.parent;
        _lastMousePosition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        ClickingTransition();
        DragAndRotate();
    }

    private void ClickingTransition()
    {
        if (!_inTransition) return;
       
        transform.position = Vector3.Lerp(transform.position, _targetPosition, transitionSpeed);
        transform.localScale = Vector3.Lerp(transform.localScale, _targetScale, transitionSpeed);
        if (Vector3.Distance(transform.position, _targetPosition) < 0.1f)
        { 
            transform.position = _targetPosition;
            transform.localScale = _targetScale;
            _inTransition = false;
            _isDisplaying = !_isDisplaying;
        }
        

    }

    private void DragAndRotate()
    {
        if (!_isDragging) return;
        var mousePositionDiff = _lastMousePosition - Input.mousePosition;
        var rotationVelocity = new Vector3(mousePositionDiff.y, mousePositionDiff.x);
        _lastMousePosition = Input.mousePosition;
        transform.Rotate(rotationVelocity*rotationSensitivity,Space.World);

        var cond = (transform.rotation.eulerAngles.y < 90f || transform.rotation.eulerAngles.y > 270f);
        front.SetActive(cond);
        back.SetActive(!cond);
    }

    public void GetPointerClick()
    {
        if (_isDisplaying) return;
        Display();
    }

    public void GetPointerDown()
    {
        if (!_isDisplaying) return;
        _isDragging = true;
        _lastMousePosition = Input.mousePosition;
    }

    public void GetPointerUp()
    {
        if (!_isDisplaying) return;
        _isDragging = false;
    }

    private void Display()
    {
        _inTransition = true;
        _targetPosition = _screenCenter;
        _targetScale = displaySize;
        cardImage.color = new Color(_defaultCardImageColor.r,_defaultCardImageColor.g,_defaultCardImageColor.b,1f);
        _skillCardUI.OnSkillCardClick(this);
    }

    public void Return()
    {
        _inTransition = true;
        _targetPosition = _defaultPosition;
        _targetScale = _defaultScale;
        transform.rotation = _defaultRotation;
        cardImage.color = _defaultCardImageColor;
        front.SetActive(true);
        back.SetActive(false);
        //transform.parent = _parent;
        ((RectTransform) transform).parent = _parent;

    }

}
