using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryScript : MonoBehaviour {

    private PowerUpScriptP1 _p1Powerup;
    private PowerUpScriptP2 _p2Powerup;
    private ConfirmScript _confirmScript;

    private GameObject _emptyIconP1;
    private GameObject _speedIconP1;
    private GameObject _fireWallIconP1;
    private GameObject _shieldIconP1;

    private GameObject _emptyIconP2;
    private GameObject _speedIconP2;
    private GameObject _fireWallIconP2;
    private GameObject _shieldIconP2;


    // Use this for initialization
    void Start () {
        _p1Powerup = GameObject.FindObjectOfType<PowerUpScriptP1>();
        if (GameObject.FindObjectOfType<ConfirmScript>().Tutorial == false)
        {
            _p2Powerup = GameObject.FindObjectOfType<PowerUpScriptP2>();
        }

        _confirmScript = GameObject.FindObjectOfType<ConfirmScript>();

        _emptyIconP1 = GameObject.Find("EmptyIconP1");
        _speedIconP1 = GameObject.Find("SpeedIconP1");
        _fireWallIconP1 = GameObject.Find("FireWallIconP1");
        _shieldIconP1 = GameObject.Find("ShieldIconP1");

        _emptyIconP2 = GameObject.Find("EmptyIconP2");
        _speedIconP2 = GameObject.Find("SpeedIconP2");
        _fireWallIconP2 = GameObject.Find("FireWallIconP2");
        _shieldIconP2 = GameObject.Find("ShieldIconP2");
    }
	
	// Update is called once per frame
	void Update () {
        ShowRightPowerup();
	}

    void ShowRightPowerup()
    {
        switch (_p1Powerup.PowerUp)
        {
            case PowerUpScriptP1.Powerup.Empty:
                //ShowEmptyImage
                _emptyIconP1.GetComponent<Image>().enabled = true;
                _speedIconP1.GetComponent<Image>().enabled = false;
                _fireWallIconP1.GetComponent<Image>().enabled = false;
                _shieldIconP1.GetComponent<Image>().enabled = false;
                break;
            case PowerUpScriptP1.Powerup.Boost:
                _emptyIconP1.GetComponent<Image>().enabled = false;
                _speedIconP1.GetComponent<Image>().enabled = true;
                _fireWallIconP1.GetComponent<Image>().enabled = false;
                _shieldIconP1.GetComponent<Image>().enabled = false;
                break;
            case PowerUpScriptP1.Powerup.Drill:
                _emptyIconP1.GetComponent<Image>().enabled = false;
                _speedIconP1.GetComponent<Image>().enabled = false;
                _fireWallIconP1.GetComponent<Image>().enabled = true;
                _shieldIconP1.GetComponent<Image>().enabled = false;
                break;
            case PowerUpScriptP1.Powerup.Invulnerability:
                _emptyIconP1.GetComponent<Image>().enabled = false;
                _speedIconP1.GetComponent<Image>().enabled = false;
                _fireWallIconP1.GetComponent<Image>().enabled = false;
                _shieldIconP1.GetComponent<Image>().enabled = true;
                break;
        }

        if (_confirmScript.Tutorial == false)
        {

            switch (_p2Powerup.PowerUp)
            {
                case PowerUpScriptP2.Powerup.Empty:
                    //ShowEmptyImage
                    _emptyIconP2.GetComponent<Image>().enabled = true;
                    _speedIconP2.GetComponent<Image>().enabled = false;
                    _fireWallIconP2.GetComponent<Image>().enabled = false;
                    _shieldIconP2.GetComponent<Image>().enabled = false;
                    break;
                case PowerUpScriptP2.Powerup.Boost:
                    _emptyIconP2.GetComponent<Image>().enabled = false;
                    _speedIconP2.GetComponent<Image>().enabled = true;
                    _fireWallIconP2.GetComponent<Image>().enabled = false;
                    _shieldIconP2.GetComponent<Image>().enabled = false;
                    break;
                case PowerUpScriptP2.Powerup.Drill:
                    _emptyIconP2.GetComponent<Image>().enabled = false;
                    _speedIconP2.GetComponent<Image>().enabled = false;
                    _fireWallIconP2.GetComponent<Image>().enabled = true;
                    _shieldIconP2.GetComponent<Image>().enabled = false;
                    break;
                case PowerUpScriptP2.Powerup.Invulnerability:
                    _emptyIconP2.GetComponent<Image>().enabled = false;
                    _speedIconP2.GetComponent<Image>().enabled = false;
                    _fireWallIconP2.GetComponent<Image>().enabled = false;
                    _shieldIconP2.GetComponent<Image>().enabled = true;
                    break;
            }
        }
    }
}
