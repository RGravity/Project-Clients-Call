using UnityEngine;
using System.Collections;

public class FireWallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == GameObject.FindObjectOfType<Player1MoveScript>().name)
        {
            //GameObject.FindObjectOfType<ScoreScript>().P1ScoreType = ScoreScript.ScoreType.Coin;
            //GameObject.FindGameObjectWithTag("CoinPickUp").GetComponent<AudioSource>().Play();
            //respawn = true;
            GameObject.FindObjectOfType<TutorialScript>().Firewall = true;
            Destroy(this.gameObject);
        }
        
    }
}
