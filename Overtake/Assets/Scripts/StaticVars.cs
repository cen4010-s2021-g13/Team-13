using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVars : MonoBehaviour
{
    //Global Constants
    public const string APIKEY = "AIzaSyBA5OioJEeX7LBs_d0_WwcYCzFMlpQUx-c";
    public const string SECRET = "s3AENhpJDtTutPzdAhFFPWRA5ubHDGJL0znQ5At3";

    //Global Variables
    public static Color playerColor = new Color(1f, 1f, 1f);
    public static string currentUserId = "";
    public static string currentNickname = "";
    public static string currentHighScore = "";
    public static string currentPersonalBest = "";
}