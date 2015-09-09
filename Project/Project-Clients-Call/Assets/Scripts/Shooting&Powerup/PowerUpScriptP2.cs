using UnityEngine;
using System.Collections;

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

    public bool PowerUpAvailable { get { return _availablePowerup; } set { _availablePowerup = value; } }
    public Powerup PowerUp { get { return _powerUp; } set { _powerUp = value; } }
    public bool Invulnerable { get { return _inVulnerable; } set { _inVulnerable = value; } }
	
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
                        break;
                    case Powerup.Drill:
                        GameObject.FindObjectOfType<RocketDrill>().RocketDrillP2 = true;
                        break;
                    case Powerup.Invulnerability:
                        _inVulnerable = true;
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
