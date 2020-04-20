using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltController : MonoBehaviour {

	public float boltSpeed;

	Animator myAnimator;
	SpriteRenderer mySpriteRenderer;
	PlayerController player;
	public new Vector2 spawnPos;
	public new Vector3 endPos;

	public bool canMove;

	// Use this for initialization
	void Start () 
	{
		myAnimator = gameObject.GetComponent<Animator>();
		mySpriteRenderer = GetComponent<SpriteRenderer>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player != null)
		{
			spawnPos = player.transform.position;
		}


		if (canMove)
		{
			transform.position = new Vector2(transform.position.x + (boltSpeed * Time.deltaTime), transform.position.y);
			if (this.transform.position.x >= 6)
			{
				myAnimator.SetBool("boltUsed", false);
				canMove = false;
			}
		}
	}



	public void useBolt()
	{
		if (myAnimator != null)
		{
			myAnimator.SetBool("boltUsed", true);
			this.transform.position = spawnPos;
			endPos = new Vector3(spawnPos.x + 10, spawnPos.y, 0);
			canMove = true;
		}
	}


	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == ("Enemy"))
		{
			Destroy(col.gameObject);
		}
		if (col.gameObject.tag == ("FrogWiz"))
		{
			transform.position = new Vector2 (10, 10);
		}
	}
}
