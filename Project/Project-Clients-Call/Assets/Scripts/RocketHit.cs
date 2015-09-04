using UnityEngine;
using System.Collections;

public class RocketHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == GameObject.FindObjectOfType<Player1MoveScript>().name && !GameObject.FindObjectOfType<PowerUpScriptP1>().Invulnerable)
        {
            GameObject.FindObjectOfType<Player1LevelScript>().StopSpeed = true;
            Destroy(this.gameObject);
        }
        if (other.gameObject.name == GameObject.FindObjectOfType<Player2MoveScript>().name && !GameObject.FindObjectOfType<PowerUpScriptP1>().Invulnerable)
        {
            GameObject.FindObjectOfType<Player2LevelScript>().StopSpeed = true;
            Destroy(this.gameObject);
        }
    }
}
