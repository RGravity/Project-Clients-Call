using UnityEngine;
using System.Collections;

public class InventoryScript : MonoBehaviour {

    private PowerUpScriptP1.Powerup _p1Powerup;
    private PowerUpScriptP2.Powerup _p2Powerup;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetPowerup();
        ShowRightPowerup();
	}

    void GetPowerup()
    {
        _p1Powerup = GameObject.FindObjectOfType<PowerUpScriptP1>().PowerUp;
        _p2Powerup = GameObject.FindObjectOfType<PowerUpScriptP2>().PowerUp;
    }

    void ShowRightPowerup()
    {
        switch (_p1Powerup)
        {
            case PowerUpScriptP1.Powerup.Empty:
                //ShowEmptyImage
                break;
            case PowerUpScriptP1.Powerup.Boost:
                break;
            case PowerUpScriptP1.Powerup.Drill:
                break;
            case PowerUpScriptP1.Powerup.Invulnerability:
                break;
        }

        switch (_p2Powerup)
        {
            case PowerUpScriptP2.Powerup.Empty:
                //ShowEmptyImage
                break;
            case PowerUpScriptP2.Powerup.Boost:
                break;
            case PowerUpScriptP2.Powerup.Drill:
                break;
            case PowerUpScriptP2.Powerup.Invulnerability:
                break;
        }
    }
}
