using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLogin : MonoBehaviour
{
	public GameObject loginPanel;
	public GameObject mainPanel;
    // Start is called before the first frame update
    void Start()
    {
        if (StaticVars.currentNickname != "" && StaticVars.currentUserId != "")
		{
			loginPanel.SetActive(false);
			mainPanel.SetActive(true);
		}

    }
}
