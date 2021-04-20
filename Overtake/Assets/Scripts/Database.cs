using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using Newtonsoft.Json.Linq;
using UnityEngine.Events;

public class Database : MonoBehaviour
{
    [Header("Login")]
    public TMP_InputField username;
    public TMP_InputField password;

    [Header("Register")]
    public TMP_InputField emailRegister;
    public TMP_InputField usernameRegister;
    public TMP_InputField passwordRegister;
    public TMP_InputField passwordConfirmationRegister;

    [Header("Warning")]
    public TMP_Text warningLogin;
    public TMP_Text warningSignUp;

    //Events
    public UnityEvent OnLoginSuccess;
    public UnityEvent OnRegistrationSuccess;
    void Awake()
    {
        if (OnLoginSuccess == null)
            OnLoginSuccess = new UnityEvent();

        if (OnRegistrationSuccess == null)
            OnRegistrationSuccess = new UnityEvent();
    }
    //OnLogin button click
    public void OnLogin()
    {
        //Check username and password fields
        if (username.text == "")
        {
            Debug.LogError("Username cannot be empty");
            warningLogin.SetText("Username cannot be empty");
            return;
        }
        if (password.text == "")
        {
            Debug.LogError("Password cannot be empty");
            warningLogin.SetText("Password cannot be empty");
            return;
        }

        //Call async function to login
        StartCoroutine(Login());
    }

    //OnRegister when signup button is clicked
    public void OnRegister()
    {
        //Series of checks
        if (emailRegister.text == "")
        {
            Debug.LogError("Email cannot be empty");
            warningSignUp.SetText("Email cannot be empty");
            return;
        }
        if (!IsValidEmail(emailRegister.text))
        {
            Debug.LogError("Invalid email format");
            warningSignUp.SetText("Invalid email format");
            return;
        }
        if (usernameRegister.text == "")
        {
            Debug.LogError("Username cannot be empty");
            warningSignUp.SetText("Username cannot be empty");
            return;
        }
        if (passwordRegister.text == "")
        {
            Debug.LogError("Password cannot be empty");
            warningSignUp.SetText("Password cannot be empty");
            return;
        }
        if (passwordConfirmationRegister.text == "")
        {
            Debug.LogError("Password confirmation cannot be empty");
            warningSignUp.SetText("Password confirmation cannot be empty");
            return;
        }
        if (passwordRegister.text != passwordConfirmationRegister.text)
        {
            Debug.LogError("Passwords don't match");
            warningSignUp.SetText("Passwords don't match");
            return;
        }

        //Call async registration
        StartCoroutine(Register());
    }

    //OnSignOut button clicked
    public void OnSignOut()
    {
        StaticVars.currentUsername = "";
        StaticVars.currentUserId = "";
        RefreshMenu();
    }

    //Refresh menu
    void RefreshMenu()
    {
        username.text = "";
        password.text = "";
        usernameRegister.text = "";
        emailRegister.text = "";
        passwordRegister.text = "";
        passwordConfirmationRegister.text = "";
        warningLogin.SetText("");
        warningSignUp.SetText("");
    }

    //Check email field
    bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    //Check if login matches database
    void CheckLogin(JObject jsonObj)
    {
        foreach (var child in jsonObj.Children().Children())
        {
            if (username.text == child["username"].ToString())
            {
                if (password.text == child["password"].ToString())
                {
                    StaticVars.currentUsername = child["username"].ToString();
                    //Debug.Log(StaticVars.currentUsername);
                    StaticVars.currentUserId = child.Parent.Path.ToString();
                    //Debug.Log(StaticVars.currentUserId);
                    OnLoginSuccess.Invoke();
                    return;
                }
                else
                {
                    Debug.LogError("Incorrect password");
                    warningLogin.SetText("Incorrect password");
                    return;
                }
            }
        }
        Debug.LogError("Username not found");
        warningLogin.SetText("Username not found");
    }

    //Async login
    IEnumerator Login()
    {
        UnityWebRequest request = new UnityWebRequest("https://overtake-904f8-default-rtdb.firebaseio.com/users.json", "GET");
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        JObject jsonObj = JObject.Parse(request.downloadHandler.text);

        CheckLogin(jsonObj);
    }
  
    //Async Registering
    IEnumerator Register()
    {
        UnityWebRequest request = new UnityWebRequest("https://overtake-904f8-default-rtdb.firebaseio.com/users.json", "GET");
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        JObject jsonObj = JObject.Parse(request.downloadHandler.text);

        //Checks for duplicity
        CheckDuplicate(jsonObj);
    }

    void CheckDuplicate(JObject jsonObj)
    {
        foreach (var child in jsonObj.Children().Children())
        {
            if (usernameRegister.text == child["username"].ToString())
            {
                Debug.LogError("Username already exists");
                warningSignUp.SetText("Username already exists");
                return;
            }
            if (emailRegister.text == child["email"].ToString())
            {
                Debug.LogError("Email already registered");
                warningSignUp.SetText("Email already registered");
                return;
            }
        }

        //Call another async function to post to database
        StartCoroutine(FinishRegistration());
    }

    IEnumerator FinishRegistration()
    {
        //JSON object created with necessary fields
        JObject jsonObj = new JObject(new JProperty("email", emailRegister.text), new JProperty("username", usernameRegister.text), new JProperty("password", passwordRegister.text), new JProperty("highscore", 0));

        UnityWebRequest request = new UnityWebRequest("https://overtake-904f8-default-rtdb.firebaseio.com/users.json", "POST");
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonObj.ToString());
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        OnRegistrationSuccess.Invoke();
    }
}