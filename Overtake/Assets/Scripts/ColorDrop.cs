
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDrop : MonoBehaviour
{
	string m_PlayerColor = "red";
	
	public void Start()
	{
	//Set default color as red
	PlayerPrefs.SetString("Color", m_PlayerColor);
	PlayerPrefs.Save();
	}

	//get color if dropdown is used
    public void HandleInputData(int val)
    {
	if (val == 0)
		{m_PlayerColor = "red";}
	if (val == 1)
		{m_PlayerColor = "blue";}
	if (val == 2)
		{m_PlayerColor = "green";}
	
	PlayerPrefs.SetString("Color", m_PlayerColor);
	PlayerPrefs.Save();
    }  
}