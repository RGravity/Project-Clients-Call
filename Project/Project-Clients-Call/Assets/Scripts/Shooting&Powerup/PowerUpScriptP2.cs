﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpScriptP2 : MonoBehaviour {

    public enum Powerup
    {
        Empty,
        Boost,
        Drill,
        Invulnerability
    }

    private bool _availablePowerup = false;
    private Powerup _powerUp = Powerup.Empty;
    private bool _inVulnerable = false;
    private int _timer = 500;
    private List<string> _pickedUpP2 = new List<string>(); 

    public bool PowerUpAvailable { get { return _availablePowerup; } set { _availablePowerup = value; } }
    public Powerup PowerUp { get { return _powerUp; } set { _powerUp = value; } }
    public bool Invulnerable { get { return _inVulnerable; } set { _inVulnerable = value; } }
    public List<string> PickedUpP2 { get { return _pickedUpP2; } set { _pickedUpP2 = value; } }
	
	// Update is called once per frame
	void Update () {
        UsePowerup();
        Invulnerability();
	}

    void UsePowerup()
    {
        if (_availablePowerup)
        {
            if (Input.GetButtonDown("FireP2"))
            {
                switch (_powerUp)
                {
                    case Powerup.Boost:
                        GameObject.FindObjectOfType<Player2LevelScript>().IncreaseSpeed = true;
                        GameObject.FindGameObjectWithTag("SpeedUp").GetComponent<AudioSource>().Play();
                        break;
                    case Powerup.Drill:
                        GameObject.FindObjectOfType<RocketDrill>().RocketDrillP2 = true;
                        GameObject.FindGameObjectWithTag("DrillExplosion").GetComponent<AudioSource>().Play();
                        break;
                    case Powerup.Invulnerability:
                        _inVulnerable = true; 
                        GameObject.FindGameObjectWithTag("Shield").GetComponent<AudioSource>().Play();
                        break;
                }
                _powerUp = Powerup.Empty;
                _availablePowerup = false;
            }
        }
    }

    void Invulnerability()
    {
        if (_inVulnerable)
        {
            _timer--;
        }

        if (_timer <= 0)
        {
            _inVulnerable = false;
            _timer = 500;
        }
    }
}
