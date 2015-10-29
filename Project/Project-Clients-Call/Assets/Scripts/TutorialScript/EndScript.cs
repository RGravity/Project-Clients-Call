using UnityEngine;
using System.Collections;

public class EndScript : MonoBehaviour {

	// Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == GameObject.FindObjectOfType<Player1MoveScript>().name)
        {
            //GameObject.FindObjectOfType<ScoreScript>().P1ScoreType = ScoreScript.ScoreType.Coin;
            //GameObject.FindGameObjectWithTag("CoinPickUp").GetComponent<AudioSource>().Play();
            //respawn = true;
            GameObject.FindObjectOfType<TutorialScript>().End = true;
        }
    }
}
