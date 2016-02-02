using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class FeedBackScript : MonoBehaviour {

    private int _checkpointTimerP1 = 0;
    private int _checkpointTimerP2 = 0;

    private bool _showPowerupFbP1 = false;
    private bool _showPowerupFbP2 = false;

    private Image _imageCheckPointP1;
    private Image _imageCheckPointP2;
    private Image _imageSpeedUpFBP1;
    private Image _imageFireWallFBP1;
    private Image _imageShieldFBP1;
    private Image _imageSpeedUpFBP2;
    private Image _imageFireWallFBP2;
    private Image _imageShieldFBP2;

    public bool ShowPowerupFbP1 { set { _showPowerupFbP1 = value; } }
    public bool ShowPowerupFbP2 { set { _showPowerupFbP2 = value; } }

	// Use this for initialization
	void Start () {
        _imageCheckPointP1 = GameObject.Find("CheckPointP1").GetComponent<Image>();
        _imageCheckPointP2 = GameObject.Find("CheckPointP2").GetComponent<Image>();
        _imageSpeedUpFBP1 = GameObject.Find("SpeedUpFBP1").GetComponent<Image>();
        _imageFireWallFBP1 = GameObject.Find("FireWallFBP1").GetComponent<Image>();
        _imageShieldFBP1 = GameObject.Find("ShieldFBP1").GetComponent<Image>();
        _imageSpeedUpFBP2 = GameObject.Find("SpeedUpFBP2").GetComponent<Image>();
        _imageFireWallFBP2 = GameObject.Find("FireWallFBP2").GetComponent<Image>();
        _imageShieldFBP2 = GameObject.Find("ShieldFBP2").GetComponent<Image>();
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
            _imageCheckPointP1.enabled = true;

            if (_checkpointTimerP1 >= Application.targetFrameRate * 2)
            {
                _checkpointTimerP1 = 0;
                GameObject.FindObjectOfType<Checkpoints>().CheckPointP1Hit = false;
                _imageCheckPointP1.enabled = false;
            }
        }
        if (GameObject.FindObjectOfType<Checkpoints>().CheckPointP2Hit)
        {
            _checkpointTimerP2++;
            _imageCheckPointP2.enabled = true;

            if (_checkpointTimerP2 >= Application.targetFrameRate * 2)
            {
                _checkpointTimerP2 = 0;
                GameObject.FindObjectOfType<Checkpoints>().CheckPointP2Hit = false;
                _imageCheckPointP2.enabled = false;
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
                    _imageSpeedUpFBP1.enabled = true;
                    if (_checkpointTimerP1 >= Application.targetFrameRate * 2)
                    {
                        _checkpointTimerP1 = 0;
                        _showPowerupFbP1 = false;
                        _imageSpeedUpFBP1.enabled = false;
                    }
                    break;
                case PowerUpScriptP1.Powerup.Drill:
                    _checkpointTimerP1++;
                    _imageFireWallFBP1.enabled = true;
                    if (_checkpointTimerP1 >= Application.targetFrameRate * 2)
                    {
                        _checkpointTimerP1 = 0;
                        _showPowerupFbP1 = false;
                        _imageFireWallFBP1.enabled = false;
                    }
                    break;
                case PowerUpScriptP1.Powerup.Invulnerability:
                    _checkpointTimerP1++;
                    _imageShieldFBP1.enabled = true;
                    if (_checkpointTimerP1 >= Application.targetFrameRate * 2)
                    {
                        _checkpointTimerP1 = 0;
                        _showPowerupFbP1 = false;
                        _imageShieldFBP1.enabled = false;
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
                        _imageSpeedUpFBP2.enabled = true;
                        if (_checkpointTimerP2 >= Application.targetFrameRate * 2)
                        {
                            _checkpointTimerP2 = 0;
                            _showPowerupFbP2 = false;
                            _imageSpeedUpFBP2.enabled = false;
                        }
                        break;
                    case PowerUpScriptP2.Powerup.Drill:
                        _checkpointTimerP2++;
                        _imageFireWallFBP2.enabled = true;
                        if (_checkpointTimerP2 >= Application.targetFrameRate * 2)
                        {
                            _checkpointTimerP2 = 0;
                            _showPowerupFbP2 = false;
                            _imageFireWallFBP2.enabled = false;
                        }
                        break;
                    case PowerUpScriptP2.Powerup.Invulnerability:
                        _checkpointTimerP2++;
                        _imageShieldFBP2.enabled = true;
                        if (_checkpointTimerP1 >= Application.targetFrameRate * 2)
                        {
                            _checkpointTimerP2 = 0;
                            _showPowerupFbP2 = false;
                            _imageShieldFBP2.enabled = false;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
