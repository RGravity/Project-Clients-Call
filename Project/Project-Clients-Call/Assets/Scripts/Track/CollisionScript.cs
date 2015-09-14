using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour {

    bool P1Finished = false;
    bool P2Finished = false;
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
            GameObject.FindObjectOfType<Player1LevelScript>().SlowSpeed = true;
            GameObject.FindObjectOfType<ScoreScript>().P1ScoreType = ScoreScript.ScoreType.Wall;
            Destroy(this.gameObject);
        }
        if (other.gameObject.name == GameObject.FindObjectOfType<Player2MoveScript>().name && !GameObject.FindObjectOfType<PowerUpScriptP1>().Invulnerable)
        {
            GameObject.FindObjectOfType<Player2LevelScript>().SlowSpeed = true;
            GameObject.FindObjectOfType<ScoreScript>().P2ScoreType = ScoreScript.ScoreType.Wall;
            Destroy(this.gameObject);
        }
        if (this.gameObject.name == "Finish" && other.gameObject.name == GameObject.FindObjectOfType<Player1MoveScript>().name)
        {
            P1Finished = true;
            GameObject.FindObjectOfType<Player1LevelScript>().Finsihed = true;
            if (P2Finished)
            {
                if (P1Finished)
                {
                    GameObject.FindObjectOfType<Player2LevelScript>().Finsihed = true;
                }   
            }
        }
        if (this.gameObject.name == "Finish" && other.gameObject.name == GameObject.FindObjectOfType<Player2MoveScript>().name)
        {
            P2Finished = true;
            GameObject.FindObjectOfType<Player2LevelScript>().Finsihed = true;
            if (P1Finished)
            {
                if (P2Finished)
                {
                    GameObject.FindObjectOfType<Player1LevelScript>().Finsihed = true;
                }
            }
        }
    }
}
