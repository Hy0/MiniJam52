using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour {

	public bool paused;
	public bool canUnpause;
	public bool canPause;

	public Button restart;
	public Button quitToMenu;
	public Button resume;
	public Text pauseText;

	private int curLevel;

	public EventSystem EventSystem;

	void Start () 
	{
		curLevel = Application.loadedLevel;
		paused = false;
		canUnpause = false;
		canPause = true;
		Time.timeScale = 1;
		restart.gameObject.SetActive(false);
		quitToMenu.gameObject.SetActive(false);
		resume.gameObject.SetActive(false);
		pauseText.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.DownArrow) && canPause)
		{
			paused = !paused;

			if (paused)
			{
				canUnpause = true;
				canPause = false;
				restart.gameObject.SetActive(true);
				resume.gameObject.SetActive(true);
				quitToMenu.gameObject.SetActive(true);
				pauseText.gameObject.SetActive(true);
				EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(resume.gameObject);
				Time.timeScale = 0;


			}
		}
	}

	public void Unpause()
	{
		if (canUnpause)
		{
			Debug.Log("Unpause activated");
			Time.timeScale = 1;
			canUnpause = false;
			restart.gameObject.SetActive(false);
			resume.gameObject.SetActive(false);
			quitToMenu.gameObject.SetActive(false);
			pauseText.gameObject.SetActive(false);
			paused = false;
			StartCoroutine(pauseEnabler());
		}

	}

	public void quitToMain()
	{
		Time.timeScale = 1;
		Application.LoadLevel(0);
	}

	public void restartLevel()
	{
		Time.timeScale = 1;
		Application.LoadLevel(curLevel);

	}

	public void GameOver()
	{
		restart.gameObject.SetActive(true);
		quitToMenu.gameObject.SetActive(true);
		EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(restart.gameObject);
		canUnpause = false;
		canPause = false;
		Time.timeScale = 0;
	}

	IEnumerator pauseEnabler()
	{
		yield return new WaitForSeconds(.1f);
		canPause = true;
	}
}
