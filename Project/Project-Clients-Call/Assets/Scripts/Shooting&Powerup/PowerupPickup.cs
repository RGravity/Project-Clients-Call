using UnityEngine;
using System.Collections;

public class PowerupPickup : MonoBehaviour {

    Vector3 rotation;
    Vector3 currentRotation;
    private int _zBlocks;
    public int ZBlocks { set { _zBlocks = value; } }
    private bool respawn = false;


    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        //currentRotation = transform.localEulerAngles;
        //rotation = currentRotation + new Vector3(0, 1f, 0);
        //transform.localEulerAngles = rotation; 
    }

    void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindObjectOfType<ConfirmScript>().Tutorial == false)
        {
            if (other.gameObject.name == GameObject.FindObjectOfType<PowerUpScriptP1>().name)
            {
                if (!GameObject.FindObjectOfType<PowerUpScriptP1>().PowerUpAvailable)
                {
                    int Powerup = Random.Range(1, 5);
                    switch (Powerup)
                    {
                        //Boost
                        case 1:
                            GameObject.FindObjectOfType<PowerUpScriptP1>().PowerUp = PowerUpScriptP1.Powerup.Boost;
                            
                            break;
                        //Invulnerable
                        case 2:
                            GameObject.FindObjectOfType<PowerUpScriptP1>().PowerUp = PowerUpScriptP1.Powerup.Invulnerability;
                            break;
                        //Powerdown
                        case 3:
                            //Powerdown
                            break;
                        //Firewall
                        case 4:
                            GameObject.FindObjectOfType<PowerUpScriptP1>().PowerUp = PowerUpScriptP1.Powerup.Drill;
                            break;
                        default:
                            break;
                    }
                    GameObject.FindObjectOfType<PowerUpScriptP1>().PowerUpAvailable = true;
                }
                GameObject.FindObjectOfType<FeedBackScript>().ShowPowerupFbP1 = true;
                GameObject.FindGameObjectWithTag("PowerUp").GetComponent<AudioSource>().Play();
                respawn = true;
                Destroy(gameObject);
            }
            if (other.gameObject.name == GameObject.FindObjectOfType<PowerUpScriptP2>().name)
            {
                if (!GameObject.FindObjectOfType<PowerUpScriptP2>().PowerUpAvailable)
                {
                    int Powerup = Random.Range(1, 5);
                    switch (Powerup)
                    {
                        //Boost
                        case 1:
                            GameObject.FindObjectOfType<PowerUpScriptP1>().PowerUp = PowerUpScriptP1.Powerup.Boost;
                            break;
                        //Invulnerable
                        case 2:
                            GameObject.FindObjectOfType<PowerUpScriptP1>().PowerUp = PowerUpScriptP1.Powerup.Invulnerability;
                            break;
                        //Powerdown
                        case 3:
                            //Powerdown
                            break;
                        //Firewall
                        case 4:
                            GameObject.FindObjectOfType<PowerUpScriptP1>().PowerUp = PowerUpScriptP1.Powerup.Drill;
                            break;
                        default:
                            break;
                    }
                    GameObject.FindObjectOfType<PowerUpScriptP2>().PowerUpAvailable = true;
                }
                GameObject.FindObjectOfType<FeedBackScript>().ShowPowerupFbP2 = true;
                GameObject.FindGameObjectWithTag("PowerUp").GetComponent<AudioSource>().Play();
                respawn = true;
                Destroy(gameObject);

            }
        }
        else
        {
            if (other.gameObject.name == GameObject.FindObjectOfType<PowerUpScriptP1>().name)
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
            GameObject.FindObjectOfType<TrackBuildScript>().SpawnPowerup(newPosition, this.gameObject.transform.parent.gameObject);
        }
    }

    void OnBecameInvisible()
    {
        if (GameObject.FindObjectOfType<ConfirmScript>().Tutorial == false)
        {
            respawn = false;
        }
        Destroy(this.gameObject);

    }
}
