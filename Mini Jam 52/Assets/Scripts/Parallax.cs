﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
	private float length;
	private float startpos;
	public GameObject cam;
	public float parallaxEffect;


	// Use this for initialization
	void Start () 
	{
		startpos = transform.position.x;
		length = GetComponent<SpriteRenderer>().bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float loop = (cam.transform.position.x * (1 - parallaxEffect));
		float distance = (cam.transform.position.x * parallaxEffect);

		transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);

		if (loop > (startpos + length))
		{
			startpos += length;
		}
		else if (loop < (startpos - length))
		{
			startpos -= length;
		}
	}
}
