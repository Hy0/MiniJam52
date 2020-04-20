using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float speed;
	

	// Use this for initialization
	void Start () 
	{
		speed = Random.Range(-2, -7);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "EnemyCatcher")
		{
			Destroy(gameObject);
		}
	}
}
