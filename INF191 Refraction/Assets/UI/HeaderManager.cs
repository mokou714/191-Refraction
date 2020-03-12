using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderManager : MonoBehaviour
{
    [SerializeField] Text text;
    Vector3 _defaultLocalPosition;
    Vector3 _defaultLocalScale;

    // Start is called before the first frame update
    void Start()
    {
        _defaultLocalPosition = transform.localPosition;
        _defaultLocalScale = transform.localScale;
        OnDesk();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDesk()
    {
        text.text = "WELCOME BACK TO YOUR DESK!";
        transform.localPosition = _defaultLocalPosition;
        transform.localScale = _defaultLocalScale;
    }

    public void OnSkillCards()
    {
        text.text = "YOUR SKILL CARDS";
    }

    public void OnComputer()
    {
        text.text = "WHAT WOULD YOU LIKE TO DO?";
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 85f, transform.localPosition.z);
        transform.localScale = new Vector3(0.5f, 0.5f, transform.localScale.z);
    }




}
