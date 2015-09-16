﻿using UnityEngine;
using System.Collections;

public class InvulnerableScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == GameObject.FindObjectOfType<PowerUpScriptP1>().name)
        {
            if (!GameObject.FindObjectOfType<PowerUpScriptP1>().PowerUpAvailable)
            {
                GameObject.FindObjectOfType<PowerUpScriptP1>().PowerUp = PowerUpScriptP1.Powerup.Invulnerability;
                GameObject.FindObjectOfType<PowerUpScriptP1>().PowerUpAvailable = true;
            }
            Destroy(gameObject);
        }
        if (other.gameObject.name == GameObject.FindObjectOfType<PowerUpScriptP2>().name)
        {
            if (!GameObject.FindObjectOfType<PowerUpScriptP2>().PowerUpAvailable)
            {
                GameObject.FindObjectOfType<PowerUpScriptP2>().PowerUp = PowerUpScriptP2.Powerup.Invulnerability;
                GameObject.FindObjectOfType<PowerUpScriptP2>().PowerUpAvailable = true;
            }
            Destroy(gameObject);
        }
    }
}
