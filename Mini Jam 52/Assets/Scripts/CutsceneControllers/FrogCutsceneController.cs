using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogCutsceneController : MonoBehaviour {

	CutsceneController cutCon;
	SpriteRenderer mySpriteRenderer;

	public Vector2 offscreenPos;
	public Vector2 cutscenePos;

	// Use this for initialization
	void Start ()
	{
		cutCon = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CutsceneController>();
		mySpriteRenderer = GetComponent<SpriteRenderer>();
		mySpriteRenderer.flipX = true;
		cutscenePos = new Vector2((1.33f + Random.Range(-1f, 1f)), (-.74f + Random.Range(.2f, .5f)));
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (cutCon.summonFrogs)
		{
			transform.position = Vector2.Lerp(transform.position, cutscenePos, .009f);
			if (transform.position.y > -.8)
			{
				transform.position = Vector2.Lerp(transform.position, offscreenPos, .009f);
			}

		}
	}
}
