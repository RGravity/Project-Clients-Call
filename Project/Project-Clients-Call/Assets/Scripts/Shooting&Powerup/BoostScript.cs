using UnityEngine;
using System.Collections;

public class BoostScript : MonoBehaviour {

    Vector3 rotation;
    Vector3 currentRotation;
    private int _zBlocks;
    public int ZBlocks { set { _zBlocks = value; } }
    private bool respawn = false;


	// Use this for initialization
	void Start () {
	
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
                    GameObject.FindObjectOfType<PowerUpScriptP1>().PowerUp = PowerUpScriptP1.Powerup.Boost;
                    GameObject.FindObjectOfType<PowerUpScriptP1>().PowerUpAvailable = true;
                }
                GameObject.FindGameObjectWithTag("PowerUp").GetComponent<AudioSource>().Play();
                respawn = true;
                Destroy(gameObject);
            }
            if (other.gameObject.name == GameObject.FindObjectOfType<PowerUpScriptP2>().name)
            {
                if (!GameObject.FindObjectOfType<PowerUpScriptP2>().PowerUpAvailable)
                {
                    GameObject.FindObjectOfType<PowerUpScriptP2>().PowerUp = PowerUpScriptP2.Powerup.Boost;
                    GameObject.FindObjectOfType<PowerUpScriptP2>().PowerUpAvailable = true;
                }
                GameObject.FindGameObjectWithTag("PowerUp").GetComponent<AudioSource>().Play();
                respawn = true;
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
            GameObject.FindObjectOfType<TrackBuildScript>().SpawnPowerup(newPosition, this.gameObject.transform.parent.gameObject);
        }
    }

    void OnBecameInvisible()
    {
        if (GameObject.FindObjectOfType<ConfirmScript>().Tutorial == false)
        {
            respawn = true;
        }
        Destroy(this.gameObject);
        
    }
}
