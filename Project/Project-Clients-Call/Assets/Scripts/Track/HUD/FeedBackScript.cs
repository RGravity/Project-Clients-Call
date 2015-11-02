using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class FeedBackScript : MonoBehaviour {

    private int _checkpointTimerP1 = 0;
    private int _checkpointTimerP2 = 0;

    private bool _showPowerupFbP1 = false;
    private bool _showPowerupFbP2 = false;

    public bool ShowPowerupFbP1 { set { _showPowerupFbP1 = value; } }
    public bool ShowPowerupFbP2 { set { _showPowerupFbP2 = value; } }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        CheckCheckpointFB();
        CheckPowerupFB();
	}

    void CheckCheckpointFB()
    {
        if (GameObject.FindObjectOfType<Checkpoints>().CheckPointP1Hit)
        {
            _checkpointTimerP1++;
            GameObject.Find("CheckPointP1").GetComponent<Image>().enabled = true;

            if (_checkpointTimerP1 >= Application.targetFrameRate * 2)
            {
                _checkpointTimerP1 = 0;
                GameObject.FindObjectOfType<Checkpoints>().CheckPointP1Hit = false;
                GameObject.Find("CheckPointP1").GetComponent<Image>().enabled = false;
            }
        }
        if (GameObject.FindObjectOfType<Checkpoints>().CheckPointP2Hit)
        {
            _checkpointTimerP2++;
            GameObject.Find("CheckPointP2").GetComponent<Image>().enabled = true;

            if (_checkpointTimerP2 >= Application.targetFrameRate * 2)
            {
                _checkpointTimerP2 = 0;
                GameObject.FindObjectOfType<Checkpoints>().CheckPointP2Hit = false;
                GameObject.Find("CheckPointP2").GetComponent<Image>().enabled = false;
            }
        }
    }

    void CheckPowerupFB()
    {
        if (_showPowerupFbP1)
        {
            switch (GameObject.FindObjectOfType<PowerUpScriptP1>().PowerUp)
            {
                case PowerUpScriptP1.Powerup.Boost:
                    _checkpointTimerP1++;
                    GameObject.Find("SpeedUpFBP1").GetComponent<Image>().enabled = true;
                    if (_checkpointTimerP1 >= Application.targetFrameRate * 2)
                    {
                        _checkpointTimerP1 = 0;
                        _showPowerupFbP1 = false;
                        GameObject.Find("SpeedUpFBP1").GetComponent<Image>().enabled = false;
                    }
                    break;
                case PowerUpScriptP1.Powerup.Drill:
                    _checkpointTimerP1++;
                    GameObject.Find("FireWallFBP1").GetComponent<Image>().enabled = true;
                    if (_checkpointTimerP1 >= Application.targetFrameRate * 2)
                    {
                        _checkpointTimerP1 = 0;
                        _showPowerupFbP1 = false;
                        GameObject.Find("FireWallFBP1").GetComponent<Image>().enabled = false;
                    }
                    break;
                case PowerUpScriptP1.Powerup.Invulnerability:
                    _checkpointTimerP1++;
                    GameObject.Find("ShieldFBP1").GetComponent<Image>().enabled = true;
                    if (_checkpointTimerP1 >= Application.targetFrameRate * 2)
                    {
                        _checkpointTimerP1 = 0;
                        _showPowerupFbP1 = false;
                        GameObject.Find("ShieldFBP1").GetComponent<Image>().enabled = false;
                    }
                    break;
                default:
                    break;
            }

            if (_showPowerupFbP2)
            {
                switch (GameObject.FindObjectOfType<PowerUpScriptP2>().PowerUp)
                {
                    case PowerUpScriptP2.Powerup.Boost:
                        _checkpointTimerP2++;
                        GameObject.Find("SpeedUpFBP2").GetComponent<Image>().enabled = true;
                        if (_checkpointTimerP2 >= Application.targetFrameRate * 2)
                        {
                            _checkpointTimerP2 = 0;
                            _showPowerupFbP2 = false;
                            GameObject.Find("SpeedUpFBP2").GetComponent<Image>().enabled = false;
                        }
                        break;
                    case PowerUpScriptP2.Powerup.Drill:
                        _checkpointTimerP2++;
                        GameObject.Find("FireWallFBP2").GetComponent<Image>().enabled = true;
                        if (_checkpointTimerP2 >= Application.targetFrameRate * 2)
                        {
                            _checkpointTimerP2 = 0;
                            _showPowerupFbP2 = false;
                            GameObject.Find("FireWallFBP2").GetComponent<Image>().enabled = false;
                        }
                        break;
                    case PowerUpScriptP2.Powerup.Invulnerability:
                        _checkpointTimerP2++;
                        GameObject.Find("ShieldFBP2").GetComponent<Image>().enabled = true;
                        if (_checkpointTimerP1 >= Application.targetFrameRate * 2)
                        {
                            _checkpointTimerP2 = 0;
                            _showPowerupFbP2 = false;
                            GameObject.Find("ShieldFBP2").GetComponent<Image>().enabled = false;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
