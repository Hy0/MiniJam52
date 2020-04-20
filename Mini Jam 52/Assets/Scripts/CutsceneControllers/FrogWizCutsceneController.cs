using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogWizCutsceneController : MonoBehaviour {

	PlayerCutsceneController player;
	Camera camera;
	CutsceneController cutCon;
	public Animator myAnimator;
	SpriteRenderer mySpriteRenderer;

	public Vector2 cutscenePos;
	public Vector2 offScreenPos;
	public Vector2 cutscenePos2;

	public bool frogHit;
	public bool frogPartTwo;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCutsceneController>();
		camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		myAnimator = gameObject.GetComponent<Animator>();
		cutCon = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CutsceneController>();
		mySpriteRenderer = GetComponent<SpriteRenderer>();
		transform.position = cutscenePos;
		frogHit = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(cutCon.i == 2)
		{
			this.gameObject.SetActive(true);
			mySpriteRenderer.flipX = true;

		}

		if (frogHit)
		{
			transform.position = Vector2.Lerp(transform.position, offScreenPos, .006f);
			Debug.Log("FrogWizard should move");
			if (transform.position.y < -3.5)
			{
				frogHit = false;
				frogPartTwo = true;
			}
		}

		if (frogPartTwo)
		{
			myAnimator.SetBool("Hit", false);
			cutCon.frogWizTime = true;
			transform.position = Vector2.Lerp(transform.position, cutscenePos2, .006f);
			mySpriteRenderer.flipX = false;
		}
	}


	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == ("Player"))
		{
			Debug.Log("Made Contact");
			myAnimator.SetBool("Hit", true);
			frogHit = true;
		}	
	}
}
