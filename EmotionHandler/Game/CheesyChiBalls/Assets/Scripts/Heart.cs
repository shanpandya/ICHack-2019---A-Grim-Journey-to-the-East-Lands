using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {

    Player player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if(player.lives == 4)
        {
            Destroy(GameObject.FindGameObjectWithTag("heart1"));
        } else if (player.lives == 2)
        {
            Destroy(GameObject.FindGameObjectWithTag("heart2"));
        } else if (player.lives == 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("heart3"));
        }
    }
}
