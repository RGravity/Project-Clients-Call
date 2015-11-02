using UnityEngine;
using System;
using System.Collections;

public class Octagon : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void OnTriggerEnter(Collider Player)
    {
        if (Player.name == "Player 1")
        {
            GameObject.FindObjectOfType<Player1LevelScript>().OctagonCollision = true;
        }
        else if (Player.name == "Player 2")
        {
            GameObject.FindObjectOfType<Player2LevelScript>().OctagonCollision = true;
        }
    }
}
