using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {

    private int _zBlocks;
    public int ZBlocks { set { _zBlocks = value; } }
    private bool respawn = false;

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
            GameObject.FindGameObjectWithTag("CoinPickUp").GetComponent<AudioSource>().Play();
            respawn = true;
            Destroy(this.gameObject);
        }
        else if (other.gameObject.name == GameObject.FindObjectOfType<Player2MoveScript>().name)
        {
            GameObject.FindObjectOfType<ScoreScript>().P2ScoreType = ScoreScript.ScoreType.Coin;
            GameObject.FindGameObjectWithTag("CoinPickUp").GetComponent<AudioSource>().Play();
            respawn = true;
            Destroy(this.gameObject);
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
        respawn = true;
        Destroy(gameObject);
    }
}
