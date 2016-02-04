using UnityEngine;
using System.Collections;

public class PowerupPickup : MonoBehaviour {

    Vector3 rotation;
    Vector3 currentRotation;
    private int _zBlocks;
    public int ZBlocks { set { _zBlocks = value; } }
    private bool respawn = false;

    private ConfirmScript _confirmScript;
    private PowerUpScriptP1 _powerUpScriptP1;
    private PowerUpScriptP2 _powerUpScriptP2;
    private FeedBackScript _feedBackScript;
    private GameObject _powerUp;
    private TrackBuildScript _trackbuildScript;


    // Use this for initialization
    void Start()
    {
        _confirmScript = GameObject.FindObjectOfType<ConfirmScript>();
        _powerUpScriptP1 = GameObject.FindObjectOfType<PowerUpScriptP1>();
        _powerUpScriptP2 = GameObject.FindObjectOfType<PowerUpScriptP2>();
        _feedBackScript = GameObject.FindObjectOfType<FeedBackScript>();
        _powerUp = GameObject.FindGameObjectWithTag("PowerUp");
        _trackbuildScript = GameObject.FindObjectOfType<TrackBuildScript>();
    }

    void Update()
    {
        //currentRotation = transform.localEulerAngles;
        //rotation = currentRotation + new Vector3(0, 1f, 0);
        //transform.localEulerAngles = rotation; 
    }

    void OnTriggerEnter(Collider other)
    {
        if (_confirmScript.Tutorial == false)
        {
            if (other.gameObject.name == _powerUpScriptP1.name)
            {
                if (!_powerUpScriptP1.PowerUpAvailable)
                {
                    int Powerup = Random.Range(1, 4);
                    switch (Powerup)
                    {
                        //Boost
                        case 1:
                            _powerUpScriptP1.PowerUp = PowerUpScriptP1.Powerup.Boost;
                            break;
                        //Invulnerable
                        case 2:
                            _powerUpScriptP1.PowerUp = PowerUpScriptP1.Powerup.Invulnerability;
                            break;
                        //Firewall
                        case 3:
                            _powerUpScriptP1.PowerUp = PowerUpScriptP1.Powerup.Drill;
                            break;
                        default:
                            break;
                    }
                    _powerUpScriptP1.PowerUpAvailable = true;
                }
                _feedBackScript.ShowPowerupFbP1 = true;
                _powerUp.GetComponent<AudioSource>().Play();
                respawn = true;
                Destroy(gameObject);
            }
            if (other.gameObject.name == _powerUpScriptP2.name)
            {
                if (!_powerUpScriptP2.PowerUpAvailable)
                {
                    int Powerup = Random.Range(1, 4);
                    switch (Powerup)
                    {
                        //Boost
                        case 1:
                            _powerUpScriptP2.PowerUp = PowerUpScriptP2.Powerup.Boost;
                            break;
                        //Invulnerable
                        case 2:
                            _powerUpScriptP2.PowerUp = PowerUpScriptP2.Powerup.Invulnerability;
                            break;
                        //Firewall
                        case 3:
                            _powerUpScriptP2.PowerUp = PowerUpScriptP2.Powerup.Drill;
                            break;
                        default:
                            break;
                    }
                    _powerUpScriptP2.PowerUpAvailable = true;
                }
                _feedBackScript.ShowPowerupFbP2 = true;
                _powerUp.GetComponent<AudioSource>().Play();
                respawn = true;
                Destroy(gameObject);

            }
        }
        else
        {
            if (other.gameObject.name == _powerUpScriptP1.name)
            {
                GameObject.FindObjectOfType<TutorialScript>().PowerUp = true;
                Destroy(gameObject);
            }
        
        }
    }

    void OnDestroy()
    {
        if (respawn)
        {
            Vector3 newPosition = this.transform.position;
            newPosition.z += _zBlocks;
            newPosition.x = (Random.Range(0, 7) * 2) - 4.25f;
            _trackbuildScript.SpawnPowerup(newPosition, this.gameObject.transform.parent.gameObject);
        }
    }

    void OnBecameInvisible()
    {
        if (_confirmScript.Tutorial == false)
        {
            respawn = false;
        }
        respawn = true;
        Destroy(this.gameObject);

    }
}
