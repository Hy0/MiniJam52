using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackPanelController : MonoBehaviour {

	public LevelOneScore score;
	public Animator myAnimator;
	public BossFrogController bossFrog;

	public float timer;

	// Use this for initialization
	void Start ()
	{
		score = GameObject.FindWithTag("Canvas").GetComponent<LevelOneScore>();
		myAnimator = gameObject.GetComponent<Animator>();
		bossFrog = GameObject.FindWithTag("FrogWiz").GetComponent<BossFrogController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (score != null)
		{
			if (score.score >= 300)
			{
				myAnimator.SetBool("fadeIn", true);

				if (timer <= 0)
				{
					Application.LoadLevel(3);
				}
				if (timer > 0)
				{
					timer = timer - Time.deltaTime;
				}
			}
		}

		if (bossFrog != null && bossFrog.health == 0)
		{
			myAnimator.SetBool("fadeIn", true);
			if (timer <= 0)
			{
				Application.LoadLevel(5);
			}
			if (timer > 0)
			{
				timer = timer - Time.deltaTime;
			}
		}
		
	}
}
