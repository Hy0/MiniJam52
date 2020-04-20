using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCutsceneController : MonoBehaviour {

	public float cutsceneTimer;
	public float curCutsceneTimer;

	CutsceneController cutCon;

	public bool sceneOne;

	public bool cont;
	public bool playerInPos;

	public new Vector3 initialPos;

	public new Vector2 cutscenePos1;
	public new Vector2 cutscenePos2;

	// Use this for initialization
	void Start () 
	{
		cont = false;
		sceneOne = true;
		transform.position = initialPos;
		cutCon = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CutsceneController>();

		if (curCutsceneTimer > 0)
		{
			curCutsceneTimer = curCutsceneTimer - Time.deltaTime;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (curCutsceneTimer <= 0)
		{
			if (sceneOne)
			{
				transform.position = Vector2.Lerp(transform.position, cutscenePos1, .006f);
				if (transform.position.x > -3.5)
				{
					playerInPos = true;
				}

				if (cont && playerInPos)
				{
					cutCon.haveControl = false;
					transform.position = Vector2.Lerp(transform.position, cutscenePos2, .006f);
					if (transform.position.x > 8)
					{
						playerInPos = false;
					}
				}

			}
		}
	}



}
