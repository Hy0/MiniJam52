using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Button startbut;
	public Button creditsbut;
	public Button quitbut;
	public Button mainbut;
	
	public Text creditstext;
	public Text titletext;
	public Text controlstext;
	
	public EventSystem EventSystem;
		
	void Start()
	{
		creditstext.gameObject.SetActive(false);
		titletext.gameObject.SetActive(true);
		controlstext.gameObject.SetActive(true);
		startbut.gameObject.SetActive(true);
		creditsbut.gameObject.SetActive(true);
		quitbut.gameObject.SetActive(true);
		mainbut.gameObject.SetActive(false);
	}	
		
	public void startGame()
	{
		Application.LoadLevel(1);
	}
	
	public void quitGame()
	{
		Application.Quit();
	}
	
	public void mainMenu()
	{
		startbut.gameObject.SetActive(true);
		EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(startbut.gameObject);
		
		creditstext.gameObject.SetActive(false);
		creditsbut.gameObject.SetActive(true);
		controlstext.gameObject.SetActive(true);
		quitbut.gameObject.SetActive(true);
		titletext.gameObject.SetActive(true);
		mainbut.gameObject.SetActive(false);
		

	}
	
	public void credits()
	{
		mainbut.gameObject.SetActive(true);
		EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(mainbut.gameObject);
	
		startbut.gameObject.SetActive(false);
		creditsbut.gameObject.SetActive(false);
		quitbut.gameObject.SetActive(false);
		controlstext.gameObject.SetActive(false);
		titletext.gameObject.SetActive(false);
		creditstext.gameObject.SetActive(true);


	}
}
