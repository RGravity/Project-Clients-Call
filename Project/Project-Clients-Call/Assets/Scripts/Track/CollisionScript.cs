using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour {

    bool P1Finished = false;
    bool P2Finished = false;

    int round = 0;

    float timer = 0;
    float secondsLeft = 5;

    [SerializeField]
    private GameObject _replacedPrefab;

	// Use this for initialization
	void Start () {
//        round = GameObject.FindObjectOfType<ConfirmScript>().round;
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
            GameObject.FindGameObjectWithTag("HittingWall").GetComponent<AudioSource>().Play();
            Instantiate(_replacedPrefab);
            _replacedPrefab.gameObject.transform.position = other.gameObject.transform.position;
            _replacedPrefab.gameObject.transform.rotation = other.gameObject.transform.rotation;
            Destroy(this.gameObject);
        }
        if (other.gameObject.name == GameObject.FindObjectOfType<Player2MoveScript>().name && !GameObject.FindObjectOfType<PowerUpScriptP1>().Invulnerable)
        {
            GameObject.FindObjectOfType<Player2LevelScript>().SlowSpeed = true;
            GameObject.FindObjectOfType<ScoreScript>().P2ScoreType = ScoreScript.ScoreType.Wall;
            GameObject.FindGameObjectWithTag("HittingWall").GetComponent<AudioSource>().Play();
            Instantiate(_replacedPrefab);

            _replacedPrefab.gameObject.transform.position = new Vector3( other.gameObject.transform.position.x,other.gameObject.transform.position.y - 0.5f,other.gameObject.transform.rotation.z);
            _replacedPrefab.gameObject.transform.rotation = other.gameObject.transform.rotation;
            Destroy(this.gameObject);
        }
        if (this.gameObject.name == "Finish" && other.gameObject.name == GameObject.FindObjectOfType<Player1MoveScript>().name)
        {
            GameObject.FindGameObjectWithTag("RaceEnd").GetComponent<AudioSource>().Play();
            P1Finished = true;
            GameObject.FindObjectOfType<Player1LevelScript>().Finsihed = true;
            if (P2Finished)
            {
                //P2 won
                if (Time.time > (timer +1))
                {
                    timer = Time.time;
                    secondsLeft--;
                }
                if (P1Finished && P2Finished)
                {
                    GameObject.FindObjectOfType<Player2LevelScript>().Finsihed = true;
                }   
            }
        }
        else if(secondsLeft < 0)
        {
            //P1 not finshed in time
            P1Finished = true;
            GameObject.FindObjectOfType<Player1LevelScript>().Finsihed = true;
        }
        if (this.gameObject.name == "Finish" && other.gameObject.name == GameObject.FindObjectOfType<Player2MoveScript>().name)
        {
            GameObject.FindGameObjectWithTag("RaceEnd").GetComponent<AudioSource>().Play();
            P2Finished = true;
            GameObject.FindObjectOfType<Player2LevelScript>().Finsihed = true;
            if (P1Finished)
            {
                //P1 won
                if (P2Finished && P1Finished)
                {
                    GameObject.FindObjectOfType<Player1LevelScript>().Finsihed = true;
                }
            }
        }
        else if (secondsLeft < 0)
        {
            //P2 not finished in time
            P2Finished = true;
            GameObject.FindObjectOfType<Player2LevelScript>().Finsihed = true;
        }

        if (P2Finished && P1Finished)
        {
            GameObject.FindObjectOfType<ConfirmScript>().round++;
            Application.LoadLevel(3);
        }
    }
}
