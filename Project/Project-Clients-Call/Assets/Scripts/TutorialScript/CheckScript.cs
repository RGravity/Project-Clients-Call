using UnityEngine;
using System.Collections;

public class CheckScript : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == GameObject.FindObjectOfType<Player1MoveScript>().name)
        {
            //GameObject.FindObjectOfType<ScoreScript>().P1ScoreType = ScoreScript.ScoreType.Coin;
            //GameObject.FindGameObjectWithTag("CoinPickUp").GetComponent<AudioSource>().Play();
            //respawn = true;
            GameObject.FindObjectOfType<TutorialScript>().Checkpoint = true;
        }
    }
}
