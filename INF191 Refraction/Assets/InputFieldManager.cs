using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{
    public bool isPassword;
    private InputField _inputField;
    // Start is called before the first frame update
    void Start()
    {
        _inputField = GetComponent<InputField>();
    }


    public void SetVisible(bool isVisible)
    {
        if (!isPassword) return;
        _inputField.contentType = isVisible ? InputField.ContentType.Standard : InputField.ContentType.Password;

    }

    public void ResetDefaultText()
    {
        _inputField.text = isPassword ? "Password" : "Username";
        SetVisible(true);
    }
    
}
