using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{

	PlayerCutsceneController player;
	FrogWizCutsceneController frog;

	public Sprite frogHead;
	public Sprite witchHead;

	public GameObject[] frogE;
	Camera camera;
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
	public bool summonFrogs;

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
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCutsceneController>();
		frog = GameObject.FindGameObjectWithTag("FrogWiz").GetComponent<FrogWizCutsceneController>();
		frogE = GameObject.FindGameObjectsWithTag("Enemy");
		camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		myAnimator = gameObject.GetComponentInChildren<Animator>();
		frog.gameObject.SetActive(false);
		headshots.color = new Color(headshots.color.r, headshots.color.g, headshots.color.b, 0f);

		for (int j = 0; j < frogE.Length; j++)
		{
			frogE[j].SetActive(false);
		}
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
				if (player.transform.position.x > 5.6)
				{
					fadeBlack();
				}
			}
		}

		if (frogWizTime)
		{
			if (frog.transform.position.x < 1.4)
			{
				if (i == 13)
				{
					headshots.color = new Color(headshots.color.r, headshots.color.g, headshots.color.b, 1f);
					headshots.sprite = frogHead;
					dialogue.text = "Doesn't she know that thousands of frogs die every year from spinning uncontrollably into the void of space?";
				}
				haveControl = true;
				if (Input.GetKeyDown(KeyCode.DownArrow) && haveControl)
				{
					i++;
					if (i == 14)
					{
						dialogue.text = "This insolence will not stand! Frogs, after her!";
						summonFrogs = true;
						for (int j = 0; j < frogE.Length; j++)
						{
							frogE[j].SetActive(true);
						}
					}
					if (i == 15)
					{
						dialogue.text = "I’d like to see that welp survive my ribbiting hordes. 300 should be more than enough.";
						endCutscene = true;
					}
				}
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
				dialogue.text = "It’s so peaceful tonight.";
			}
			if (Input.GetKeyDown(KeyCode.DownArrow) && haveControl)
			{
				i++;
				if (i == 1)
				{
					dialogue.text = "Granted, this is the dead expanse of space, but still.";
				}
				if (i == 2)
				{
					dialogue.text = "....Wait, what’s that coming this way?";
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
					dialogue.text = "For an asteroid, it’s surprisingly green.";
				}
				if (i == 4)
				{
					headshots.sprite = frogHead;
					dialogue.text = "Mind if I hop in for but a moment?";
				}
				if (i == 5)
				{
					headshots.sprite = witchHead;
					dialogue.text = "The frog wizard! How are you alive? I thought you died when I slowly boiled you to death in that pot on my stove!";
				}
				if (i == 6)
				{
					headshots.sprite = frogHead;
					dialogue.text = "We amphibians have always been adept at slipping out of sticky situations.";
				}
				if (i == 7)
				{
					dialogue.text = "Perhaps I should put your skills to the test?";
				}
				if (i == 8)
				{
					headshots.sprite = witchHead;
					dialogue.text = "What are you planning, you spinach-skinned brat. World domination?";
				}
				if (i == 9)
				{
					headshots.sprite = frogHead;
					dialogue.text = "Not really, just passing by to spread a plague on some egyptians. Orders from up top and all.";
				}
				if (i == 10)
				{
					dialogue.text = "They’ll all have croaked by the time me and my amphibious friends are done with them.";
				}
				if (i == 11)
				{
					headshots.sprite = witchHead;
					dialogue.text = "While your evil plan does sound delightful, those puns are inexcusable.";
				}
				if (i == 12)
				{
					dialogue.text = "Have at you, you putrid, onerous, toad of a man!";
				}
				if (i == 13)
				{
					headshots.color = new Color(headshots.color.r, headshots.color.g, headshots.color.b, 0f);
					headshots.sprite = null;
					dialogue.text = "";
					player.cont = true;
					haveControl = false;
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
			Destroy(this.gameObject);
			Application.LoadLevel(2);
		}
	}
}
