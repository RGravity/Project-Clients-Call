﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Checkpoints : MonoBehaviour {

    Checkpoints[] checkpoints;
	// Use this for initialization
	void Start () 
    {
        checkpoints = GameObject.FindObjectsOfType<Checkpoints>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == GameObject.FindObjectOfType<Player1MoveScript>().gameObject.name)
        {
            foreach (Checkpoints checkpoint in checkpoints)
            {
                if (this.gameObject.name == checkpoint.gameObject.name)
                {
                    Player1LevelScript p1 = GameObject.FindObjectOfType<Player1LevelScript>();
                    this.gameObject.GetComponent<BoxCollider>().enabled = false;
                    this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    p1.StopSpeed = true;
                    p1.StopTime = Time.time;
                }
            }
        }
        if (other.gameObject.name == GameObject.FindObjectOfType<Player2MoveScript>().gameObject.name)
        {
            foreach (Checkpoints checkpoint in checkpoints)
            {
                if (this.gameObject.name == checkpoint.gameObject.name)
                {
                    Player2LevelScript p2 = GameObject.FindObjectOfType<Player2LevelScript>();
                    this.gameObject.GetComponent<BoxCollider>().enabled = false;
                    this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    p2.StopSpeed = true;
                    p2.StopTime = Time.time;
                }
            }
        }
    }
}