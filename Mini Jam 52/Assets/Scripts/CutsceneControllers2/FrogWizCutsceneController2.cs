using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogWizCutsceneController2 : MonoBehaviour {

	public Animator myAnimator;
	SpriteRenderer mySpriteRenderer;

	public Vector2 cutscenePos;
	public Vector2 offScreenPos;
	public Vector2 cutscenePos2;

	// Use this for initialization
	void Start () 
	{
		myAnimator = gameObject.GetComponent<Animator>();
		mySpriteRenderer = GetComponent<SpriteRenderer>();
		transform.position = cutscenePos;
		mySpriteRenderer.flipX = true;
	}
}
