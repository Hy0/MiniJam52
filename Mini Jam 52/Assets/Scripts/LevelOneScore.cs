using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOneScore : MonoBehaviour {

	public int score;
	public Text scoreText;

	public bool complete = false;

	void Update()
    {
		scoreText.text = score.ToString();

		if (score >= 300)
		{
			complete = true;
		}
    }
}
