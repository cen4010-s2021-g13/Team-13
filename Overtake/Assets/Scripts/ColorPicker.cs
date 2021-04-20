using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorPicker : MonoBehaviour
{
    TMP_Dropdown dropdown;

    void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();    
    }
    public void GetColor()
    {
        switch (dropdown.options[dropdown.value].text)
        {
            case "Red":
                StaticVars.playerColor = new Color(1f, 1f, 1f);
                break;
            case "Blue":
                StaticVars.playerColor = new Color(0f, 0.333f, 1f);
                break;
            case "Green":
                StaticVars.playerColor = new Color(0f, 1f, 0f);
                break;
            case "Orange":
                StaticVars.playerColor = new Color(0.866f, 1f, 0f);
                break;
            default:
                StaticVars.playerColor = new Color(1f, 1f, 1f);
                break;
                
        }
    }
}
