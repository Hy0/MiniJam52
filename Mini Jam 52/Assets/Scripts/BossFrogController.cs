using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Timeline;

public class BossFrogController : MonoBehaviour
{

	PlayerController player;
	BoltController bolt;
	ShieldController shield;
	public Animator myAnimator;

	public GameObject enemyPrefab;

	public float health;
	public float lerpSpeed;

	public float spell1Cool;
	public float spell1CoolTimer;
	public float spell2Cool;
	public float spell2CoolTimer;
	public float spell3Cool;
	public float spell3CoolTimer;

	public int max;
	public bool setMax;


	public float random;

	public Vector2 myPos;
	public Vector2 endPos;

	public bool pickNewAttack;
	public bool canTakeDamage;

	public bool go;
	public bool end;

	public float timeToMove;
	public float timeToMoveTimer;



	// Use this for initialization
	void Start()
	{
		spell1Cool = spell1CoolTimer;
		spell2Cool = spell2CoolTimer;
		spell3Cool = spell3CoolTimer;

		spell1CoolTimer = 3;
		spell2CoolTimer = 5;
		spell3CoolTimer = 2;
		timeToMoveTimer = 1;

		max = 0;
		lerpSpeed = 006f;
		health = 9;

		pickNewAttack = true;
		canTakeDamage = true;
		setMax = false;

		go = true;
		end = false;

		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		bolt = GameObject.FindGameObjectWithTag("Spell").GetComponent<BoltController>();
		myAnimator = gameObject.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
			if (pickNewAttack)
			{
				random = Random.Range(1, 10);
				pickNewAttack = false;
			}

			if (spell1Cool > 0)
			{
				spell1Cool = spell1Cool - Time.deltaTime;
				setMax = false;
				max = 0;
			}
			if (spell2Cool > 0)
			{
				spell2Cool = spell2Cool - Time.deltaTime;
				go = true;
				end = false;
			}			
			if (spell3Cool > 0)
			{
				spell3Cool = spell3Cool - Time.deltaTime;
				timeToMove = timeToMoveTimer;
			}

			if (random <= 3 && spell1Cool <= 0 && canTakeDamage)
			{
				summonFrogs();
				spell1Cool = spell1CoolTimer;
			}
			if (random > 3 && random <= 6 && spell2Cool <= 0 && canTakeDamage)
			{
				charge();
			}
			if (random > 6 && random <= 9 && spell3Cool <= 0 && canTakeDamage)
			{
				reposition();
			}

			if (health == 0)
			{
				pickNewAttack = false;
				myAnimator.SetBool("Hit", true);
			}
	}

	public void summonFrogs()
	{
		if (max == 0 && !setMax)
		{
			if (health > 6) //Phase 1, 789
			{
				Debug.Log("We should be setting max here");
				max = Random.Range(3, 5);
				setMax = true;
			}
			if (health > 3 && health <= 6) //Phase 2, 456
			{
				Debug.Log("We should be setting max here");
				max = Random.Range(6, 9);
				setMax = true;
				spell1CoolTimer = 2.5f;
			}
			if (health > 0 && health <= 3)//Phase 3, 123
			{
				Debug.Log("We should be setting max here");
				max = Random.Range(9, 12);
				setMax = true;
				spell1CoolTimer = 2f;
			}

		}

		for (int i = 0; i < max; i++)
		{
			myPos = new Vector2(Random.Range(3, 5), (Random.Range(-2.8f, 3)));
			Instantiate(enemyPrefab, myPos, Quaternion.identity);
		}

		spell1Cool = spell1CoolTimer;
		pickNewAttack = true;
		myPos.x = 0;
		myPos.y = 0;
	}

	public void charge()
	{
		if (health > 6) //Phase 1, 789
		{
			lerpSpeed = .003f;
		}
		if (health > 3 && health <= 6) //Phase 2, 456
		{
			lerpSpeed = .006f;
			spell2CoolTimer = 4.5f;
		}
		if (health > 0 && health <= 3)//Phase 3, 123
		{
			lerpSpeed = .008f;
			spell2CoolTimer = 3.5f;
		}

		//First, store mypos
		if (myPos.x == 0)
		{
			myPos = new Vector2(transform.position.x, transform.position.y);
		}

		//Set endpos somewhere off screen
		endPos.x = myPos.x - 40;
		endPos.y = myPos.y;

		//Lerp to endpos
		if (go)
		{
			transform.position = Vector2.Lerp(transform.position, endPos, lerpSpeed);
			Debug.Log("We're lerping to endpos");
		}


		//Warp to right side of screen
		if (transform.position.x < -5 && go)
		{

			transform.position = new Vector2(myPos.x + 10, myPos.y);
			Debug.Log("We're warping to offscreen right");
			go = false;
		}

		//Begin lerping in
		if (transform.position.x > 5 && !go)
		{
			transform.position = Vector2.Lerp(transform.position, new Vector2(myPos.x - 1, myPos.y), lerpSpeed);
			Debug.Log("We're lerping back on screen");
		}

		if (transform.position.x < 5 && !go)
		{
			end = true;
		}

		if (end)
		{
			spell2Cool = spell2CoolTimer;
			pickNewAttack = true;
			myPos.x = 0;
			myPos.y = 0;
			endPos.x = 0;
			endPos.y = 0;
		}
	}

	public void reposition()
	{

		if (health > 6) //Phase 1, 789
		{
			lerpSpeed = .006f;
			spell3CoolTimer = 2f;

		}
		if (health > 3 && health <= 6) //Phase 2, 456
		{
			lerpSpeed = .010f;
			spell3CoolTimer = 1f;
		}
		if (health > 0 && health <= 3)//Phase 3, 123
		{
			lerpSpeed = .015f;
			spell3CoolTimer = .5f;
		}

		if (endPos.x == 0)
		{
			endPos = new Vector2(Random.Range(1, 5), transform.position.y - Random.Range(-2.8f, 2.8f));
		}

		if (endPos.x > 5)
		{
			endPos.x = 5;
		}
		if (endPos.y > 2.8)
		{
			endPos.y = 2.8f;
		}
		if (endPos.y < -2.8)
		{
			endPos.y = -2.8f;
		}

		timeToMove = timeToMove - Time.deltaTime;

		if (timeToMove > 0)
		{
			transform.position = Vector2.Lerp(transform.position, endPos, .006f);
		}

		if (timeToMove <= 0)
		{
			spell3Cool = spell3CoolTimer;
			pickNewAttack = true;
			myPos.x = 0;
			myPos.y = 0;
			endPos.x = 0;
			endPos.y = 0;
		}

	}



	IEnumerator RepositionMove()
	{
		yield return new WaitForSeconds(1.5f);

	}




	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Spell" && canTakeDamage)
		{
			health -= 1;
			myAnimator.SetBool("Hit", true);
			canTakeDamage = false;
			StartCoroutine(HurtAnimation());
		}
	}

	IEnumerator HurtAnimation()
	{
		yield return new WaitForSeconds(1);
		myAnimator.SetBool("Hit", false);
		canTakeDamage = true;
	}


}
