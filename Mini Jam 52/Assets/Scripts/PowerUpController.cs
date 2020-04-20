using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpController : MonoBehaviour {

	public float boltCool;
	public float shieldCool;
	public float dashBackCool;

	public float boltCoolRemaining;
	public float shieldCoolRemaining;
	public float dashBackCoolRemaining;

	public bool canUseBolt;
	public bool canUseShield;
	public bool canUseDashBack;

	public Image overlayBoltCooldown;
	public Image overlayShieldCooldown;
	
	public BoltController boltCon;
	public ShieldController shieldCon;

	// Use this for initialization
	void Start () 
	{
		boltCon = GameObject.Find("BoltController").GetComponent<BoltController>();
		shieldCon = GameObject.Find("ShieldController").GetComponent<ShieldController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (boltCoolRemaining > 0)
		{
			canUseBolt = false;
			overlayBoltCooldown.GetComponent<Image>().fillAmount = boltCoolRemaining / boltCool;
			boltCoolRemaining = boltCoolRemaining - Time.deltaTime;
		}
		if (boltCoolRemaining <= 0)
		{
			canUseBolt = true;
		}
		if (shieldCoolRemaining > 0)
		{
			canUseShield = false;
			overlayShieldCooldown.GetComponent<Image>().fillAmount = shieldCoolRemaining / shieldCool;
			shieldCoolRemaining = shieldCoolRemaining - Time.deltaTime;
		}
		if (shieldCoolRemaining <= 0)
		{
			canUseShield = true;
		}

		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			if (canUseBolt)
			{
				boltCon.useBolt();
				canUseBolt = false;
				boltCoolRemaining = boltCool;
			}
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			if (canUseShield)
			{
				shieldCon.useShield();
				canUseShield = false;
				shieldCoolRemaining = shieldCool;
			}
		}
	}
}
