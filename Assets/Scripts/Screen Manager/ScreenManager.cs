using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.EventSystems;


public class ScreenManager : MonoBehaviour
{
    public static ScreenManager instance;
    
    [Header("Screen Panels")] public GameObject welcomeScreen;
    public GameObject logInScreen;
    public GameObject signUpScreen;
    public GameObject enterPhone;
    public GameObject enterEmail;
    public GameObject enterName;
    public GameObject setPassword;
    public GameObject verificationScreen;
    
    public GameObject[] screenPanels;
    // [Header("Timer For Code Send Again")] public Text timer;
    [Header("Timer For Code Send Again")] public TMP_Text timer;
    [Header("Get Text from User")] public Text userEmail;
    public Text userPassword;
    public int startTime;
    public VerifyText _verifyText;
    private int num;

    public List<GameObject> panelsList;
    float elapsedTime;
    EventSystem system;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    


    // private void Update()
    // {
    //     float elapsedTime = startTime - Time.time;
    //
    //     if (elapsedTime < 0.0f)
    //     {
    //         // Timer has expired
    //         elapsedTime = 0.0f;
    //     }
    //
    //     int minutes = Mathf.FloorToInt(elapsedTime / 60.0f);
    //     int seconds = Mathf.FloorToInt(elapsedTime - minutes * 60.0f);
    //
    //     string timeString = string.Format("{0:0}:{1:00}", minutes, seconds);
    //
    //     // Debug.Log(timeString);
    //     timer.text = timeString;
    // }
    //
    

    private void Start()
    {
        // num = Random.Range(1000, 9999);
        // Debug.Log(num);
        ResetScreens();
        welcomeScreen.SetActive(true);

        Debug.Log(Time.time);
        system = EventSystem.current;

        // SetPanelList();
    }
     
    public void Update()
    {
 
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnRight();
         
            if (next != null)
            {
             
                InputField inputfield = next.GetComponent<InputField>();
                if (inputfield != null)
                    inputfield.OnPointerClick(new PointerEventData(system));  //if it's an input field, also set the text caret
             
                system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
            }
            //else Debug.Log("next nagivation element not found");
         
        }
    }

    // public void OnBackBtn(int a)
    // {
    //     panelsList[a].SetActive(false);
    //     panelsList[a].SetActive(true);
    // // }
    // public void SetPanelList()
    // {
    //     panelsList.Add(welcomeScreen);
    //     panelsList.Add(logInScreen);
    //     panelsList.Add(signUpScreen);
    //     panelsList.Add(enterPhone);
    //     panelsList.Add(enterEmail);
    //     panelsList.Add(verificationScreen);
    //     panelsList.Add(setPassword);
    //     panelsList.Add(enterName);
    // }
    //
    public void LogInScreen()
    {
        ResetScreens();
        logInScreen.SetActive(true);
    }
    public void SignUp()
    {
        ResetScreens();
        signUpScreen.SetActive(true);
    }
    public void EnterPhone()
    {
        Debug.Log(DataHandler.instance.isValid);
        ResetScreens();
            enterPhone.SetActive(true);

    }
    public void EnterEmail()
    {
        ResetScreens();
        enterEmail.SetActive(true);
    }
    public void EnterName()
    {
        Debug.Log(CheckPassword.instance.firstPassword.text);
        if (CheckPassword.instance.firstPassword.text == CheckPassword.instance.reenterPassword.text && CheckPassword.instance.firstPassword.text.Length != 0)
        {
            ResetScreens();
            CheckPassword.instance.firstPassword.text = "";
            CheckPassword.instance.reenterPassword.text = "";
            enterName.SetActive(true);
        }
        else
        {
            var WrongPasswordText = GameObject.Find("Wrong Password").GetComponent<TMPro.TMP_Text>();
            WrongPasswordText.text = "Entered Password is Wrong";
            Debug.Log("Password Doesn't Match");
        }
    }
    public void SetPassword()
    {
        // var code = _verifyText._1stDigt.text.ToString()+ _verifyText._2ndDigt.text.ToString()+_verifyText._3rdDigt.text.ToString()+_verifyText._4thDigt.text.ToString();
        var code = _verifyText._1stDigt.text.ToString()+ _verifyText._2ndDigt.text.ToString()+_verifyText._3rdDigt.text.ToString()+_verifyText._4thDigt.text.ToString();
        // String code = _verifyText._1stDigt.textComponent.text.ToString() + _verifyText._2ndDigt.textComponent.text.ToString()+_verifyText._3rdDigt.textComponent.text.ToString()+_verifyText._4thDigt.textComponent.text.ToString();
        // var code = _verifyText._1stDigt.textComponent.text + _verifyText._2ndDigt.textComponent.text+_verifyText._3rdDigt.textComponent.text+_verifyText._4thDigt.textComponent.text;
        Debug.Log(code);
        int received;
        int.TryParse(code, out received);
        // int received = int.TryParse(code);
        // int received = Convert.ToInt32(code);
        Debug.Log(received);
        if (received == num)
        {
            Debug.Log("Code Verified");
            ResetScreens();
            StopCoroutine("CodeAgainTimer");
            timer.text = "00:00";
            elapsedTime = 0;
            setPassword.SetActive(true);
        }

    }

    public void ClearVerification()
    {
        num = 0;
        _verifyText._1stDigt.text = "";
            _verifyText._2ndDigt.text= "";
            _verifyText._3rdDigt.text= "";
            _verifyText._4thDigt.text= "";
            StopCoroutine("CodeAgainTimer");
            timer.text = "00:00";

            Debug.Log(_verifyText._1stDigt.text);
    }
    
    public void VerificationScreen()
    {
        DataHandler.instance.CheckEmail();
        Debug.Log(DataHandler.instance.isValid);
        Debug.Log(userEmail.text.ToString());
        
        if (DataHandler.instance.isValid)
        {
            num = Random.Range(1000, 9999);
            Debug.Log(num);
            ResetScreens();
            verificationScreen.SetActive(true);
            StartCoroutine("CodeAgainTimer");
        }
        if(enterPhone.activeSelf)
        {
            var get_child = enterPhone.transform.GetChild(3);
            var child = get_child.gameObject;
            Debug.Log(child);
            child.GetComponent<InputField>().text = "";
            num = Random.Range(1000, 9999);
            Debug.Log(num);
            ResetScreens();
            verificationScreen.SetActive(true);
            StartCoroutine("CodeAgainTimer");
        }
    }

    public void SendCode()
    {
        if (elapsedTime == 0)
        {
            num = Random.Range(1000, 9999);
            Debug.Log(num);
            startTime = 600;
            StartCoroutine("CodeAgainTimer");
        }
        else
        {
            Debug.Log("Try Again After 10 Minutes");
        }
    }
    IEnumerator CodeAgainTimer()
    {
        startTime += Mathf.RoundToInt(Time.time);
        elapsedTime = startTime - Time.time;
        while (elapsedTime > 0)
        {
            yield return new WaitForSeconds(1);
            elapsedTime = startTime - Time.time;
            if (elapsedTime < 0.0f)
            {
            
                // Timer has expired
                elapsedTime = 0.0f;
            }

            int minutes = Mathf.FloorToInt(elapsedTime / 60.0f);
            int seconds = Mathf.FloorToInt(elapsedTime - minutes * 60.0f);

            string timeString = string.Format("{0:0}:{1:00}", minutes, seconds);

            // Debug.Log(timeString);
            timer.text = timeString;
            // print(timeString);
        }
        
      
    }

    public void Exit()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    public void LoggedIn()
    {
        Debug.Log("User Have Logged In ");
    }

    public void GetUserInfo()
    {
        if (InputValidator.instance.inputField.text.Length > 3 )
        {
            Debug.Log("You have signed up");
            
                // && InputValidator.instance.inputField.text.Length <31
            // InputValidator.instance.inputField.text = InputValidator.instance.inputField.text.Substring(0, 30);
        }
        else
        {
            Debug.Log("Username must be Greater than 3 Characters");
        }
    }
    void ResetScreens()
    {
        welcomeScreen.SetActive(false);
        logInScreen.SetActive(false);
        signUpScreen.SetActive(false);
        enterPhone.SetActive(false);
        enterEmail.SetActive(false);
        enterName.SetActive(false);
        setPassword.SetActive(false);
        verificationScreen.SetActive(false);
    }
    
    
}

[System.Serializable]
public class VerifyText
{
    [Header("Get Text from User")] 
    // public Text _1stDigt;
    // public Text _2ndDigt;
    // public Text _3rdDigt;
    // public Text _4thDigt;
    // public InputField _1stDigt;
    // public InputField _2ndDigt;
    // public InputField _3rdDigt;
    // public InputField _4thDigt; 
    public TMP_InputField _1stDigt;
    public TMP_InputField _2ndDigt;
    public TMP_InputField _3rdDigt;
    public TMP_InputField _4thDigt;
}

public class ScreenPanels
{
    [Header("Screen Panels")] public GameObject welcomeScreen;
    public GameObject logInScreen;
    public GameObject signUpScreen;
    public GameObject enterPhone;
    public GameObject enterEmail;
    public GameObject enterName;
    public GameObject setPassword;
    public GameObject verificationScreen;

}