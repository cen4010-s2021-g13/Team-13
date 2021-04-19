using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorPicker : MonoBehaviour
{
    public static Color playerColor = new Color(1f, 1f, 1f);
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
                playerColor = new Color(1f, 1f, 1f);
                break;
            case "Blue":
                playerColor = new Color(0f, 0.333f, 1f);
                break;
            case "Green":
                playerColor = new Color(0f, 1f, 0f);
                break;
            case "Orange":
                playerColor = new Color(0.866f, 1f, 0f);
                break;
            default:
                playerColor = new Color(1f, 1f, 1f);
                break;
                
        }
    }
}
