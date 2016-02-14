using UnityEngine;
using System.Collections;

public class SupperWall : MonoBehaviour {

    Player1LevelScript player1LevelScript;
    Player2LevelScript player2LevelScript;
    Player1MoveScript player1MoveScript;
    Player2MoveScript player2MoveScript;
    ConfirmScript confirmScript;
    // Use this for initialization
    void Start () {

        player1LevelScript = GameObject.FindObjectOfType<Player1LevelScript>();
        player2LevelScript = GameObject.FindObjectOfType<Player2LevelScript>();
        player1MoveScript = GameObject.FindObjectOfType<Player1MoveScript>();
        player2MoveScript = GameObject.FindObjectOfType<Player2MoveScript>();
        confirmScript = GameObject.FindObjectOfType<ConfirmScript>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (!other.name.Contains("Plane"))
        {
            
        }
        if (other.transform.name.Contains("Bullet"))
        {
            if (this.transform.parent.name == player1LevelScript.transform.name)
            {
                player1LevelScript.SuperWallHit = false;
                if (player1LevelScript.Speed == 0)
                {
                    player1LevelScript.Speed = 10;
                }
            }
            if (confirmScript.Tutorial == false)
            {
                if (this.transform.parent.name == player2LevelScript.transform.name)
                {
                    player2LevelScript.SuperWallHit = false;
                    if (player2LevelScript.Speed == 0)
                    {
                        player2LevelScript.Speed = 10;
                    }
                }
            }
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        if (other.transform.name == player1MoveScript.transform.name)
        {
            player1LevelScript.SuperWallHit = true;
            player1LevelScript.Speed = 0;
        }
        if (confirmScript.Tutorial == false)
        {
            if (other.transform.name == player2MoveScript.transform.name)
            {
                player2LevelScript.SuperWallHit = true;
                player2LevelScript.Speed = 0;
            }
        }
    }


   
}
