using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;

	// Update is called once per frame
	void Start()
	{
		StartCoroutine(spawnEnemy());
	}

	IEnumerator spawnEnemy()
	{	
		int delay = Random.Range(0, 2);
		yield return new WaitForSeconds(delay);
		Vector3 spawnPos = new Vector3(6f, Random.Range(-2.88f, 2.82f), 0);
		Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
		StartCoroutine(spawnEnemy());
	}


}

