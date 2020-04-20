using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCatcher : MonoBehaviour {

    public LevelOneScore lvlscore;

    void start()
    {
        lvlscore = GameObject.FindGameObjectWithTag("Canvas").GetComponent<LevelOneScore>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
        if (lvlscore != null)
        {
            lvlscore.score = lvlscore.score + 1;
        }
    }







}
