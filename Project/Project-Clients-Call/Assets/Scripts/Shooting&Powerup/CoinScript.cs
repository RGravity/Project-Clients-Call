using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == GameObject.FindObjectOfType<Player1MoveScript>().name)
        {
            GameObject.FindObjectOfType<ScoreScript>().P1ScoreType = ScoreScript.ScoreType.Coin;
            
            Destroy(this.gameObject);
        }
        else if (other.gameObject.name == GameObject.FindObjectOfType<Player2MoveScript>().name)
        {
            GameObject.FindObjectOfType<ScoreScript>().P2ScoreType = ScoreScript.ScoreType.Coin;

            Destroy(this.gameObject);
        }
    }
}
