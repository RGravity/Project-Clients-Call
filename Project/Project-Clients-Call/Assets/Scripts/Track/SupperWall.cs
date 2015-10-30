using UnityEngine;
using System.Collections;

public class SupperWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.name.Contains("Bullet") && other.transform.name == GameObject.FindObjectOfType<Player1MoveScript>().transform.name)
        {
            
        }
        if (other.transform.name.Contains("Bullet") && other.transform.name == GameObject.FindObjectOfType<Player2MoveScript>().transform.name)
        {

        }
        if (other.transform.name == GameObject.FindObjectOfType<Player1MoveScript>().transform.name)
        {
           // GameObject.FindObjectOfType<Player1LevelScript>().Speed = 0;
           // GameObject.FindObjectOfType<Player1LevelScript>().SuperWallHit = true;
        }
        if (other.transform.name == GameObject.FindObjectOfType<Player2MoveScript>().transform.name)
        {
           // GameObject.FindObjectOfType<Player2LevelScript>().Speed = 0;
           // GameObject.FindObjectOfType<Player2LevelScript>().SuperWallHit = true;
        }
    }

   
}
