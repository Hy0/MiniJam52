using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float health;

	public bool isMoving;
	public bool isFlying;
	public bool isHurt;
	public bool canTakeDamage;

	public Animator myAnimator;
	SpriteRenderer mySpriteRenderer;

	// Use this for initialization
	void Start () 
	{
		myAnimator = gameObject.GetComponent<Animator>();
		mySpriteRenderer = GetComponent<SpriteRenderer>();
		canTakeDamage = true;
	}

	// Update is called once per frame
	void Update()
	{
		if (!isFlying)
		{
			float Dirx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

			if (Dirx > 0) //If positive, right
			{
				mySpriteRenderer.flipX = false;
			}
			else if (Dirx < 0) //If negative, left
			{
				mySpriteRenderer.flipX = true;
			}

			transform.position = new Vector2(transform.position.x + Dirx, transform.position.y);

			myAnimator.SetBool("isMoving", true);

			if (Dirx == 0)
			{
				myAnimator.SetBool("isMoving", false);
			}
		}




		if (isFlying)
		{
			float Dirx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
			float Diry = Input.GetAxis("Vertical") * speed * Time.deltaTime;

			if (Dirx > 0) //If positive, right
			{
				mySpriteRenderer.flipX = false;
			}
			else if (Dirx < 0) //If negative, left
			{
				mySpriteRenderer.flipX = true;
			}

			transform.position = new Vector2(transform.position.x + Dirx, transform.position.y + Diry);
			myAnimator.SetBool("isFlying", true);

		}

		if (health == 0)
		{
			Destroy(this.gameObject);
		}
	}


	void OnCollisionEnter2D(Collision2D col)
	{
		if (canTakeDamage && col.gameObject.tag == "Enemy")
		{
			health -= 1;
			canTakeDamage = false;
			myAnimator.SetBool("isHurt", true);
			StartCoroutine(HurtAnimation());
		}		

		if (canTakeDamage && col.gameObject.tag == "FrogWiz")
		{
			Debug.Log("FrogWizard hit me!");
			health -= 1;
			canTakeDamage = false;
			myAnimator.SetBool("isHurt", true);
			StartCoroutine(HurtAnimation());
		}
	}

	IEnumerator HurtAnimation()
	{
		yield return new WaitForSeconds(1);
		myAnimator.SetBool("isHurt", false);
		canTakeDamage = true;
	}
}
