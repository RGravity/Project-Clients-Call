using UnityEngine;
using UnityEngine.UI;
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
                //GameObject.Find("FireWallIconP1").GetComponent<Image>().enabled = false;
                GameObject.Find("SpeedIconP1").GetComponent<Image>().enabled = false;
                GameObject.Find("FireWallIconP1").GetComponent<Image>().enabled = false;
                GameObject.Find("ShieldIconP1").GetComponent<Image>().enabled = false;
                break;
            case PowerUpScriptP1.Powerup.Boost:
                GameObject.Find("SpeedIconP1").GetComponent<Image>().enabled = true;
                GameObject.Find("FireWallIconP1").GetComponent<Image>().enabled = false;
                GameObject.Find("ShieldIconP1").GetComponent<Image>().enabled = false;
                break;
            case PowerUpScriptP1.Powerup.Drill:
                GameObject.Find("SpeedIconP1").GetComponent<Image>().enabled = false;
                GameObject.Find("FireWallIconP1").GetComponent<Image>().enabled = true;
                GameObject.Find("ShieldIconP1").GetComponent<Image>().enabled = false;
                break;
            case PowerUpScriptP1.Powerup.Invulnerability:
                GameObject.Find("SpeedIconP1").GetComponent<Image>().enabled = false;
                GameObject.Find("FireWallIconP1").GetComponent<Image>().enabled = false;
                GameObject.Find("ShieldIconP1").GetComponent<Image>().enabled = true;
                break;
        }

        switch (_p2Powerup)
        {
            case PowerUpScriptP2.Powerup.Empty:
                //ShowEmptyImage
                GameObject.Find("SpeedIconP2").GetComponent<Image>().enabled = false;
                GameObject.Find("FireWallIconP2").GetComponent<Image>().enabled = false;
                GameObject.Find("ShieldIconP2").GetComponent<Image>().enabled = false;
                break;
            case PowerUpScriptP2.Powerup.Boost:
                GameObject.Find("SpeedIconP2").GetComponent<Image>().enabled = true;
                GameObject.Find("FireWallIconP2").GetComponent<Image>().enabled = false;
                GameObject.Find("ShieldIconP2").GetComponent<Image>().enabled = false;
                break;
            case PowerUpScriptP2.Powerup.Drill:
                GameObject.Find("SpeedIconP2").GetComponent<Image>().enabled = false;
                GameObject.Find("FireWallIconP2").GetComponent<Image>().enabled = true;
                GameObject.Find("ShieldIconP2").GetComponent<Image>().enabled = false;
                break;
            case PowerUpScriptP2.Powerup.Invulnerability:
                GameObject.Find("SpeedIconP2").GetComponent<Image>().enabled = false;
                GameObject.Find("FireWallIconP2").GetComponent<Image>().enabled = false;
                GameObject.Find("ShieldIconP2").GetComponent<Image>().enabled = true;
                break;
        }
    }
}
