using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Version : MonoBehaviour
{
    void Start()
    {
        GetComponent<TMP_Text>().SetText("Ver. " + Application.version);
    }
}
