using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class DataHandler : MonoBehaviour
{
    public static DataHandler instance;
    static string email;
    [HideInInspector]
    public bool isValid ;
    //email = ScreenManager.instance.enterEmail.ToString();
    // isValid = IsValidEmail(email);

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Start()
    {
        //Debug.Log(isValid);
    }

    public void CheckEmail()
    {
        //email = ScreenManager.instance.enterEmail.ToString();
        // isValid = IsValidEmail(email);
        isValid = IsValidEmail(ScreenManager.instance.userEmail.text.ToString());
    }

    
        public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            return false;

        // Regular expression pattern for a valid email address
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        // Use Regex.IsMatch to match the pattern against the email string
        return Regex.IsMatch(email, pattern);
    }

}
