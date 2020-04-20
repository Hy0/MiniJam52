using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

	public float scrollSpeed;
	public Renderer bgRender;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		bgRender.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0f);
		bgRender.sortingLayerName = "Background";
	}
}
