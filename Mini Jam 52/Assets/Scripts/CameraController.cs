using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public Vector3 offset;

	public bool flyLevel;

	// Use this for initialization
	void Start () 
	{
		offset = transform.position - player.transform.position;
		
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		if (flyLevel)
		{
			transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, 0, 0),
			Mathf.Clamp(transform.position.y, 0, 0),
			Mathf.Clamp(transform.position.z, -10, -10));
		}
		else
		{
			transform.position = player.transform.position + offset;
		}


	}
}
