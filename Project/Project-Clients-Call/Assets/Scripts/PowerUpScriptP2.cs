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
            if (Input.GetButtonDown("FireP2"))
            {
                switch (_powerUp)
                {
                    case Powerup.Boost:
                        GameObject.FindObjectOfType<Player2LevelScript>().IncreaseSpeed = true;
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
