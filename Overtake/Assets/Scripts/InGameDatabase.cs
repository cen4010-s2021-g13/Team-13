using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using Newtonsoft.Json.Linq;

public class InGameDatabase : MonoBehaviour
{
    public TMP_Text scoreMessage;

    //SaveNewScore Function
    public void SaveScore(float newScore)
    {
        //Check if its a new high score or new personal best
        if (newScore > float.Parse(StaticVars.currentHighScore))
        {
            StaticVars.currentHighScore = newScore.ToString();
            StaticVars.currentPersonalBest = newScore.ToString();
            scoreMessage.SetText("New High Score!!");
            StartCoroutine(SavePersonalBestDataBase(StaticVars.currentUserId, newScore.ToString()));
            StartCoroutine(InsertScoreDatabase(StaticVars.currentUserId, newScore.ToString(), true));
        }
        else if (newScore > float.Parse(StaticVars.currentPersonalBest))
        {
            StaticVars.currentPersonalBest = newScore.ToString();
            scoreMessage.SetText("New Personal Best!");
            StartCoroutine(SavePersonalBestDataBase(StaticVars.currentUserId, newScore.ToString()));
            StartCoroutine(InsertScoreDatabase(StaticVars.currentUserId, newScore.ToString(), false));
        }
        else
        {
            StartCoroutine(InsertScoreDatabase(StaticVars.currentUserId, newScore.ToString(), false));
        }
    }

    //Async saving new personal highscore on database
    IEnumerator SavePersonalBestDataBase(string userId, string score)
    {
        UnityWebRequest request = new UnityWebRequest("https://overtake-904f8-default-rtdb.firebaseio.com/users/" + userId + "/personalBest.json", "PUT");
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes("\"" + score + "\"");
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();


        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
            Debug.Log(request.downloadHandler.text);
        }
    }

    //Async adding score to leaderboard on database
    IEnumerator InsertScoreDatabase(string userId, string score, bool isHighScore)
    {
        //JSON object created with necessary fields
        JObject jsonObj = new JObject(new JProperty("userId", userId), new JProperty("score", score));

        UnityWebRequest request = new UnityWebRequest("https://overtake-904f8-default-rtdb.firebaseio.com/leaderboard/.json", "POST");
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonObj.ToString());
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            if (isHighScore)
            {
                JObject responseObj = JObject.Parse(request.downloadHandler.text);
                //Debug.Log(responseObj["name"].ToString());
                StartCoroutine(UpdateHighScoreDatabase(responseObj["name"].ToString(), score));
            }
        }
        else
        {
            Debug.Log(request.error);
            Debug.Log(request.downloadHandler.text);
        }
    }

    //Async updating high score on database
    IEnumerator UpdateHighScoreDatabase(string scoreId, string score)
    {
        //JSON object created with necessary fields
        JObject jsonObj = new JObject(new JProperty("scoreId", scoreId), new JProperty("score", score));

        UnityWebRequest request = new UnityWebRequest("https://overtake-904f8-default-rtdb.firebaseio.com/highscore.json", "PUT");
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonObj.ToString());
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
            Debug.Log(request.downloadHandler.text);
        }
    }
}
