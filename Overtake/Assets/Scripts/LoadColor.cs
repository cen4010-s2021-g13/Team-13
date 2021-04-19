using UnityEngine;

public class LoadColor : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    //The Color to be assigned to the Renderer’s Material
    Color m_NewColor;
	string m_PlayerColor;

    void Start()
    {
        GetColor();
		//Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
		m_SpriteRenderer.color = Color.cyan;
		//Set the GameObject's Color, white = plain
		if (m_PlayerColor == "red")
		{m_SpriteRenderer.color = Color.white;}
       	if (m_PlayerColor == "blue")
		{m_SpriteRenderer.color = Color.blue;}
		if (m_PlayerColor == "green")
		{m_SpriteRenderer.color = Color.green;}
		if (m_PlayerColor == "null")
		{m_SpriteRenderer.color = Color.yellow;}
	
    }
	
	void GetColor()
	{
		m_PlayerColor = PlayerPrefs.GetString("Color","null");
	}

}