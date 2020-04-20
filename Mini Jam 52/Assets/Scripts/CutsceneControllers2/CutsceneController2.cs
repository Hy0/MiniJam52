using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneController2 : MonoBehaviour
{

	PlayerCutsceneController2 player;
	FrogWizCutsceneController2 frog;

	public Sprite frogHead;
	public Sprite witchHead;

	public Camera camera;
	public Animator myAnimator;

	public Text dialogue;
	public Image headshots;

	public float cameraZoomTimer;
	public float cameraZoomTarget;
	public float fadeDelayTimer;
	public float fadeLoadTimer;

	public bool completed;
	public bool haveControl;
	public bool endCutscene;
	public bool frogWizTime;

	public int i = 0;



	// Use this for initialization
	void Start()
	{
		fadeDelayTimer = 2f;
		fadeLoadTimer = .9f;
		completed = false;
		haveControl = true;
		endCutscene = false;
		frogWizTime = false;
		i = 0;
		cameraZoomTimer = 1.5f;

		headshots = GameObject.FindGameObjectWithTag("Headshots").GetComponent<Image>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCutsceneController2>();
		frog = GameObject.FindGameObjectWithTag("FrogWiz").GetComponent<FrogWizCutsceneController2>();
		camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		myAnimator = gameObject.GetComponentInChildren<Animator>();
		frog.gameObject.SetActive(false);
		headshots.color = new Color(headshots.color.r, headshots.color.g, headshots.color.b, 0f);
	}

	// Update is called once per frame
	void Update()
	{
		if (player.playerInPos)
		{
			if (!completed)
			{
				cutsceneOne();
			}
			else if (completed && !frogWizTime)
			{
				cutsceneTwo();
			}

		}

		if (endCutscene)
		{
			if (fadeDelayTimer > 0)
			{
				fadeDelayTimer = fadeDelayTimer - Time.deltaTime;
			}
			if (fadeDelayTimer <= 0)
			{
				fadeBlack();
			}
		}
	}

	void cutsceneOne()
	{
		cameraZoomTarget = 2.5f;

		if (cameraZoomTimer > 0)
		{
			cameraZoomTimer = cameraZoomTimer - Time.deltaTime;
			camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, cameraZoomTarget, Time.deltaTime);
		}
		else if (cameraZoomTimer <= 0)
		{
			haveControl = true;

			if (i == 0)
			{
				headshots.color = new Color(headshots.color.r, headshots.color.g, headshots.color.b, 1f);
				headshots.sprite = witchHead;
				dialogue.text = "Finally got away from all those frogs...";
			}
			if (Input.GetKeyDown(KeyCode.DownArrow) && haveControl)
			{
				i++;
				if (i == 1)
				{
					dialogue.text = "Now where is that slimey wizard?";
				}
				if (i == 2)
				{
					headshots.color = new Color(headshots.color.r, headshots.color.g, headshots.color.b, 0f);
					dialogue.text = "";
					cameraZoomTarget = 3f;
					cameraZoomTimer = 1.5f;
					completed = true;
					i = 2;
					haveControl = false;
				}

			}
		}
	}


	void cutsceneTwo()
	{
		if (cameraZoomTimer > 0)
		{
			cameraZoomTimer = cameraZoomTimer - Time.deltaTime;
			camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, cameraZoomTarget, Time.deltaTime);
			frog.gameObject.SetActive(true);
		}
		else if (cameraZoomTimer <= 0)
		{
			haveControl = true;
			if (Input.GetKeyDown(KeyCode.DownArrow) && haveControl)
			{
				i++;
				if (i == 3)
				{
					headshots.color = new Color(headshots.color.r, headshots.color.g, headshots.color.b, 1f);
					headshots.sprite = frogHead;
					dialogue.text = "You survived my horde of frogs? How!";
				}
				if (i == 4)
				{
					dialogue.text = "...I guess I should have employed more than just basic frogs...";
				}
				if (i == 5)
				{
					headshots.sprite = witchHead;
					dialogue.text = "You evil wart! You should have stopped when I smacked you before.";
				}
				if (i == 6)
				{
					headshots.sprite = frogHead;
					dialogue.text = "Ah, but you see witch, I find you quite ribbiting...";
				}
				if (i == 7)
				{
					headshots.sprite = witchHead;
					dialogue.text = "These puns are terrible.";
				}
				if (i == 8)
				{
					headshots.sprite = frogHead;
					dialogue.text = "You know, I've been toad that before.";
				}
				if (i == 9)
				{
					dialogue.text = "Do you know why they say frogs always win?";
				}
				if (i == 10)
				{
					dialogue.text = "They just eat whatever bugs them!";
				}
				if (i == 11)
				{
					dialogue.text = " And you're looking delicious!";
				}
				if (i == 12)
				{
					headshots.sprite = witchHead;
					dialogue.text = "Was that supposed to be funny? I guess I frogot to laugh.";
				}
				if (i == 13)
				{
					headshots.sprite = frogHead;
					dialogue.text = "...";
				}
				if (i == 14)
				{
					dialogue.text = "Hey c'mon making frog puns is my entire job.";
				}
				if (i == 15)
				{
					headshots.sprite = witchHead;
					dialogue.text = "Alright, enough of this. Time for you to be boiled once again!";
				}
				if (i == 16)
				{
					endCutscene = true;
				}
			}
		}
	}







	void fadeBlack()
	{
		headshots.color = new Color(headshots.color.r, headshots.color.g, headshots.color.b, 0f);
		dialogue.text = "";

		myAnimator.SetBool("fadeIn", true);

		if (fadeLoadTimer > 0)
		{
			fadeLoadTimer = fadeLoadTimer - Time.deltaTime;
		}
		if (fadeLoadTimer <= 0)
		{
			Application.LoadLevel(4);
		}
	}
}
