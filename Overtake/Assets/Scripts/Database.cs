using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEngine.Events;

public class Database : MonoBehaviour
{
    [Header("Login")]
    public TMP_InputField email;
    public TMP_InputField password;

    [Header("Register")]
    public TMP_InputField nicknameRegister;
    public TMP_InputField emailRegister;
    public TMP_InputField passwordRegister;
    public TMP_InputField passwordConfirmationRegister;

    [Header("Reset Password")]
    public TMP_InputField emailReset;

    [Header("Change Nickname")]
    public TMP_InputField nicknameChange;

    [Header("Warning")]
    public TMP_Text warningLogin;
    public TMP_Text warningSignUp;
    public TMP_Text warningReset;
    public TMP_Text warningNicknameChange;
    public TMP_Text registrationMessage;

    //Events
    public UnityEvent OnLoginSuccess;
    public UnityEvent OnRegistrationSuccess;
    public UnityEvent OnResetPasswordSuccess;
    public UnityEvent OnUserAlreadyLoggedIn;
    public UnityEvent OnChangeNicknameSuccess;

    void Awake()
    {
        if (OnLoginSuccess == null)
            OnLoginSuccess = new UnityEvent();

        if (OnRegistrationSuccess == null)
            OnRegistrationSuccess = new UnityEvent();

        if (OnResetPasswordSuccess == null)
            OnResetPasswordSuccess = new UnityEvent();

        if (OnUserAlreadyLoggedIn == null)
            OnUserAlreadyLoggedIn = new UnityEvent();

        if (OnChangeNicknameSuccess == null)
            OnChangeNicknameSuccess = new UnityEvent();

        if (StaticVars.currentUserId != "")
            OnUserAlreadyLoggedIn.Invoke();
    }
    //OnLogin button click
    public void OnLogin()
    {
        //Check username and password fields
        if (email.text == "")
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
        if (nicknameRegister.text == "")
        {
            Debug.LogError("Nickname cannot be empty");
            warningSignUp.SetText("Nickname cannot be empty");
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

    //Get leaderboard
    public void OnGetLeaderboard()
    {
        StartCoroutine(GetLeaderboard());
    }

    //Reset password clicked
    public void OnResetPassword()
    {
        //Check email
        if (emailReset.text == "")
        {
            Debug.LogError("Email cannot be empty");
            warningSignUp.SetText("Email cannot be empty");
            return;
        }
        StartCoroutine(ResetPasswordFirebase());
    }

    //OnSignOut button clicked
    public void OnSignOut()
    {
        StaticVars.currentNickname = "";
        StaticVars.currentUserId = "";
        StaticVars.currentHighScore = "";
        StaticVars.currentPersonalBest = "";

        RefreshMenu();
    }

    //OnChangeNickname button clicked
    public void OnChangeNickname()
    {
        if (nicknameChange.text == "")
        {
            Debug.LogError("Nickname cannot be empty");
            warningNicknameChange.SetText("Nickname cannot be empty");
            return;
        }
        StartCoroutine(ChangeNickname(StaticVars.currentUserId));
    }
    //Refresh menu
    public void RefreshMenu()
    {
        email.text = "";
        password.text = "";
        nicknameRegister.text = "";
        emailRegister.text = "";
        passwordRegister.text = "";
        passwordConfirmationRegister.text = "";
        emailReset.text = "";
        warningLogin.SetText("");
        warningSignUp.SetText("");
        warningReset.SetText("");
        registrationMessage.SetText("");
    }

    //Async login with Firebase Authentication
    IEnumerator LoginFirebase()
    {
        //JSON object created with necessary fields
        JObject jsonObj = new JObject(new JProperty("email", email.text), new JProperty("password", password.text), new JProperty("returnSecureToken", true));

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
            StartCoroutine(GetHighScore());
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
    IEnumerator GetHighScore()
    {
        UnityWebRequest request = new UnityWebRequest("https://overtake-904f8-default-rtdb.firebaseio.com/highscore.json", "GET");
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            JObject responsenObj = JObject.Parse(request.downloadHandler.text);
            Debug.Log(responsenObj["score"].ToString());
            StaticVars.currentHighScore = responsenObj["score"].ToString();
        }
        else
        {
            warningLogin.SetText("Database Error");
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
            StaticVars.currentPersonalBest = responsenObj["personalBest"].ToString();
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
        JObject jsonObj = new JObject(new JProperty("nickname", nicknameRegister.text), new JProperty("highscore", "0"));

        UnityWebRequest request = new UnityWebRequest("https://overtake-904f8-default-rtdb.firebaseio.com/users/" + userId + ".json", "PUT");
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonObj.ToString());
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        
        if (request.result == UnityWebRequest.Result.Success)
        {
            OnRegistrationSuccess.Invoke();
            RefreshMenu();
            registrationMessage.SetText("Account created!");
        }
        else
        {
            warningLogin.SetText("Database Error");
            Debug.Log(request.error);
        }
    }

    //Async
    IEnumerator ResetPasswordFirebase()
    {
        //JSON object created with necessary fields
        JObject jsonObj = new JObject(new JProperty("email", emailReset.text), new JProperty("requestType", "PASSWORD_RESET"));

        UnityWebRequest request = new UnityWebRequest("https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key=" + StaticVars.APIKEY, "POST");
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonObj.ToString());
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            OnResetPasswordSuccess.Invoke();
            RefreshMenu();
            registrationMessage.SetText("Reset link sent");
        }
        else if (request.result == UnityWebRequest.Result.ProtocolError)
        {
            JObject responsenObj = JObject.Parse(request.downloadHandler.text);
            string errorMessage = responsenObj["error"]["message"].ToString();
            Debug.Log(errorMessage);
            if (errorMessage.Contains("INVALID_EMAIL"))
            {
                warningReset.SetText("Invalid email");
            }
            else if (errorMessage.Contains("EMAIL_NOT_FOUND"))
            {
                warningReset.SetText("Email not found");
            }
            else
            {
                warningReset.SetText(errorMessage);
            }
            Debug.Log(request.error);
        }
        else
        {
            warningSignUp.SetText("Networking Error");
            Debug.Log(request.error);
        }
    }

    //Async function to change nickname in database
    IEnumerator ChangeNickname(string userId)
    {
        UnityWebRequest request = new UnityWebRequest("https://overtake-904f8-default-rtdb.firebaseio.com/users/" + userId + "/nickname.json", "PUT");
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes("\"" + nicknameChange.text + "\"");
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();


        if (request.result == UnityWebRequest.Result.Success)
        {
            StaticVars.currentNickname = nicknameChange.text;
            OnChangeNicknameSuccess.Invoke();
        }
        else
        {
            warningNicknameChange.SetText("Database Error");
            Debug.Log(request.error);
            Debug.Log(request.downloadHandler.text);
        }
    }

    //Async function to get all leaderboard from database
    IEnumerator GetLeaderboard()
    {
        UnityWebRequest request = new UnityWebRequest("https://overtake-904f8-default-rtdb.firebaseio.com/leaderboard.json", "GET");
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            JObject responsenObj = JObject.Parse(request.downloadHandler.text);

            Dictionary<string, float> scoresDict = new Dictionary<string, float>();
            foreach (var child in responsenObj.Children().Children())
            {
                scoresDict.Add(child["userId"].ToString(), float.Parse(child["score"].ToString()));
                Debug.Log(child["score"].ToString());
            }

            var orderedScores = from pair in scoresDict orderby pair.Value ascending select pair;

            foreach (var score in orderedScores)
            {
                Debug.Log("userId: " + score.Key);
                Debug.Log("score: " + score.Value);
            }
        }
        else
        {
            warningLogin.SetText("Database Error");
            Debug.Log(request.error);
        }
    }
}