using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

[System.Serializable]
public class HealthManager : MonoBehaviour {

	public PlayerController player;
	public UIController uiCon;
	public Image[] hearts;
	public Sprite fullHeart;
	public Sprite emptyHeart;

	bool callGameover;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		uiCon = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIController>();
		callGameover = true;
	}

	// Update is called once per frame
	void Update()
	{
		for (int i = 0; i < hearts.Length; i++)
		{
			if(i < player.health)
			{
				hearts[i].enabled = true;
				hearts[i].sprite = fullHeart;
			}
			else
			{
				hearts[i].sprite = emptyHeart;
			}
		}


		if (player.health == 0 && callGameover)
		{
			GameOver();
			callGameover = false;
		}
	}


	public void GameOver()
	{
		uiCon.GameOver();
	}
}
