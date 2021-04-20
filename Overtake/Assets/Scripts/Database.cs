using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography; 
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
        StartCoroutine(LoginFirebase());
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
        StartCoroutine(RegisterFirebase());
    }

    //OnSignOut button clicked
    public void OnSignOut()
    {
        StaticVars.currentNickname = "";
        StaticVars.currentUserId = "";
        StaticVars.currentHighscore = "";

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

    //Async login with Firebase Authentication
    IEnumerator LoginFirebase()
    {
        //JSON object created with necessary fields
        JObject jsonObj = new JObject(new JProperty("email", username.text), new JProperty("password", password.text), new JProperty("returnSecureToken", true));

        UnityWebRequest request = new UnityWebRequest("https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=" + StaticVars.APIKEY, "POST");
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonObj.ToString());
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            JObject responsenObj = JObject.Parse(request.downloadHandler.text);

            StaticVars.currentUserId = responsenObj["localId"].ToString();
            StartCoroutine(GetUserInfo(StaticVars.currentUserId));
        }
        else if (request.result == UnityWebRequest.Result.ProtocolError)
        {
            JObject responsenObj = JObject.Parse(request.downloadHandler.text);
            string errorMessage = responsenObj["error"]["message"].ToString();
            Debug.Log(errorMessage);
            if (errorMessage.Contains("INVALID_EMAIL"))
            {
                warningLogin.SetText("Invalid email");
            }
            else if (errorMessage.Contains("EMAIL_NOT_FOUND"))
            {
                warningLogin.SetText("Email not found");
            }
            else if (errorMessage.Contains("INVALID_PASSWORD"))
            {
                warningLogin.SetText("Invalid password");
            }
            else if (errorMessage.Contains("USER_DISABLED"))
            {
                warningLogin.SetText("User Disabled");
            }
            else if (errorMessage.Contains("TOO_MANY_ATTEMPTS_TRY_LATER"))
            {
                warningLogin.SetText("Too many Attempts");
            }
            else
            {
                warningLogin.SetText(errorMessage);
            }
            Debug.Log(request.error);
        }
        else
        {
            warningLogin.SetText("Networking Error");
            Debug.Log(request.error);
        }
    }

    //Async function to get userinfo from database
    IEnumerator GetUserInfo(string userId)
    {
        UnityWebRequest request = new UnityWebRequest("https://overtake-904f8-default-rtdb.firebaseio.com/users/" + userId + ".json", "GET");
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            JObject responsenObj = JObject.Parse(request.downloadHandler.text);

            StaticVars.currentNickname = responsenObj["nickname"].ToString();
            StaticVars.currentHighscore = responsenObj["highscore"].ToString();
            OnLoginSuccess.Invoke();
        }
        else
        {
            warningLogin.SetText("Database Error");
            Debug.Log(request.error);
        }
    }

    //Async register new user with Firebase Authentication
    IEnumerator RegisterFirebase()
    {
        //JSON object created with necessary fields
        JObject jsonObj = new JObject(new JProperty("email", emailRegister.text), new JProperty("password", passwordRegister.text), new JProperty("returnSecureToken", true));

        UnityWebRequest request = new UnityWebRequest("https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=" + StaticVars.APIKEY, "POST");
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonObj.ToString());
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            JObject responsenObj = JObject.Parse(request.downloadHandler.text);

            StartCoroutine(SetNewUserInfo(responsenObj["localId"].ToString()));
        }
        else if (request.result == UnityWebRequest.Result.ProtocolError)
        {
            JObject responsenObj = JObject.Parse(request.downloadHandler.text);
            string errorMessage = responsenObj["error"]["message"].ToString();
            Debug.Log(errorMessage);
            if (errorMessage.Contains("INVALID_EMAIL"))
            {
                warningSignUp.SetText("Invalid email");
            }
            else if (errorMessage.Contains("EMAIL_EXISTS"))
            {
                warningSignUp.SetText("Email already registered");
            }
            else if (errorMessage.Contains("INVALID_PASSWORD"))
            {
                warningSignUp.SetText("Invalid password");
            }
            else if (errorMessage.Contains("TOO_MANY_ATTEMPTS_TRY_LATER"))
            {
                warningSignUp.SetText("Too many Attempts");
            }
            else
            {
                warningSignUp.SetText(errorMessage);
            }
            Debug.Log(request.error);
        }
        else
        {
            warningSignUp.SetText("Networking Error");
            Debug.Log(request.error);
        }
    }

    //Async
    IEnumerator SetNewUserInfo(string userId)
    {
        //JSON object created with necessary fields
        JObject jsonObj = new JObject(new JProperty("nickname", usernameRegister.text), new JProperty("highscore", "0"));

        UnityWebRequest request = new UnityWebRequest("https://overtake-904f8-default-rtdb.firebaseio.com/users/" + userId + ".json", "PUT");
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonObj.ToString());
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        
        if (request.result == UnityWebRequest.Result.Success)
        {
            OnRegistrationSuccess.Invoke();
        }
        else
        {
            warningLogin.SetText("Database Error");
            Debug.Log(request.error);
        }
    }
}