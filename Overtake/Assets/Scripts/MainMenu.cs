using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    TMP_Text textUI;
    void Awake()
    {
        textUI = GetComponent<TMP_Text>();
    }
    public void UpdateUser()
    {
        textUI.SetText(StaticVars.currentUsername);
    }
}
