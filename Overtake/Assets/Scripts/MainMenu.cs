using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_Text nicknameUI;
    public TMP_Text personalBestUI;

    public void UpdateUser()
    {
        nicknameUI.SetText(StaticVars.currentNickname);
        personalBestUI.SetText("Personal Best: " + StaticVars.currentPersonalBest);
    }
}
