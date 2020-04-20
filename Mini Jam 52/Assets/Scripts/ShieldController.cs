using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {


	Animator myAnimator;
	SpriteRenderer mySpriteRenderer;
	PlayerController player;
	public new Vector2 spawnPos;

	CircleCollider2D myCollider;



	public bool usingShield;


	void Start()
	{
		myAnimator = gameObject.GetComponent<Animator>();
		mySpriteRenderer = GetComponent<SpriteRenderer>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		myCollider = GetComponent<CircleCollider2D>();
		myCollider.enabled = false;
	}


	void Update()
	{
		if (usingShield && player != null)
		{
			this.transform.position = player.transform.position;
		}
	}

	public void useShield()
	{
		if (myAnimator != null)
		{
			myCollider.enabled = true;
			myAnimator.SetBool("shieldUsed", true);
			this.transform.position = spawnPos;
			StartCoroutine(shieldEnd());
			usingShield = true;
			player.canTakeDamage = false;
		}
	}

	IEnumerator shieldEnd()
	{
		yield return new WaitForSeconds(4.9f);
		myAnimator.SetBool("shieldUsed", false);
		usingShield = false;
		myCollider.enabled = false;
		player.canTakeDamage = true;
	}
}
