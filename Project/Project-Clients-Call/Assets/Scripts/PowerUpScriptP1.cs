using UnityEngine;
using System.Collections;

public class PowerUpScriptP1 : MonoBehaviour {

    public enum Powerup
    {
        Empty,
        Boost,
        Drill,
        Invulnerability
    }

    private bool _availablePowerup = true;
    private Powerup _powerUp = Powerup.Empty;

    public bool PowerUpAvailable { get { return _availablePowerup; } set { _availablePowerup = value; } }
    public Powerup PowerUp { get { return _powerUp; } set { _powerUp = value; } }
	
	// Update is called once per frame
	void Update () {
        UsePowerup();
	}

    void UsePowerup()
    {
        if (_availablePowerup)
        {
            if (Input.GetButtonDown("FireP1"))
            {
                switch (_powerUp)
                {
                    case Powerup.Boost:
                        GameObject.FindObjectOfType<Player1LevelScript>().IncreaseSpeed = true;
                        break;
                    case Powerup.Drill:
                        break;
                    case Powerup.Invulnerability:
                        break;
                }
                _powerUp = Powerup.Empty;
                _availablePowerup = false;
            }
        }
    }
}
