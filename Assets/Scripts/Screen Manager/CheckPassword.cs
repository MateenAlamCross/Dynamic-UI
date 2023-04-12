using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CheckPassword : MonoBehaviour
{
    public static CheckPassword instance;
    // public InputField firstPassword;
    // public InputField reenterPassword;
    public TMP_InputField firstPassword;
    public TMP_InputField reenterPassword;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void OnEndEdit()
    {
        if (firstPassword.text.Length > 7)
        {
            firstPassword.text = firstPassword.text.Substring(0, 20);
        }
        else
        {
            Debug.Log("Password Must be of 8 Characters");
        }
    }

    public void Re_enterPasswordCheck()
    {
        if (firstPassword == reenterPassword)
        {
            ScreenManager.instance.EnterName();
        }
        else
        {
            Debug.Log("Password Doesn't Match");
        }
    }
    
}
