using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputValidator : MonoBehaviour
{
    public static InputValidator instance;
    [HideInInspector]
    public InputField inputField;

    
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        inputField = GetComponent<InputField>();
    }

    public void OnValueChanged()
    {
        if (inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Substring(0, 1);
        }
    }
    public void OnEnterName()
    {
        if (inputField.text.Length > 3)
        {
            inputField.text = inputField.text.Substring(0, 30);
        }
    }
}
