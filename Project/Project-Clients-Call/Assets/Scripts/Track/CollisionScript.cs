using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour
{

    bool P1Finished = false;
    bool P2Finished = false;
    bool startTimer = false;

    int round = 0;

    float timer = 0;
    float secondsLeftP1 = 1;
    float secondsLeftP2 = 1;
    bool isActivated = false;
    float shootingWallTimer = 0;
    int shootingWallCount = 0;

    [SerializeField]
    private GameObject _replacedPrefab;

    // Use this for initialization
    void Start()
    {
                round = GameObject.FindObjectOfType<ConfirmScript>().round;
    }

    // Update is called once per frame
    void Update()
    {
        if (P1Finished)
        {
            if (Time.time > (timer + 1))
            {
                timer = Time.time;
                secondsLeftP2--;
            }
        }
        if (P2Finished)
        {
            if (Time.time > (timer + 1))
            {
                timer = Time.time;
                secondsLeftP1--;
            }
        }
        if (P1Finished && P2Finished)
        {
            GameObject.FindObjectOfType<ConfirmScript>().round++;
            //Application.LoadLevel(3);
            Application.LoadLevel(Application.loadedLevel);
        }
        if (secondsLeftP1 < 0)
        {
            //P1 lost
            GameObject.FindObjectOfType<Player1LevelScript>().Finsihed = true;
            P1Finished = true;
        }
        if (secondsLeftP2 < 0)
        {
            //P2 lost
            GameObject.FindObjectOfType<Player2LevelScript>().Finsihed = true;
            P2Finished = true;
        }
        WallAnimation(isActivated);
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
            //Destroy(this.gameObject);
            if (this.gameObject.name != "Finish")
            {
                GetComponent<TrackBlockScript>().OnBecameInvisible();
            }
        }
        if (other.gameObject.name == GameObject.FindObjectOfType<Player2MoveScript>().name && !GameObject.FindObjectOfType<PowerUpScriptP1>().Invulnerable)
        {
            GameObject.FindObjectOfType<Player2LevelScript>().SlowSpeed = true;
            GameObject.FindObjectOfType<ScoreScript>().P2ScoreType = ScoreScript.ScoreType.Wall;
            GameObject.FindGameObjectWithTag("HittingWall").GetComponent<AudioSource>().Play();
            Instantiate(_replacedPrefab);

            _replacedPrefab.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y - 0.5f, other.gameObject.transform.rotation.z);
            _replacedPrefab.gameObject.transform.rotation = other.gameObject.transform.rotation;
            //Destroy(this.gameObject);
            if (this.gameObject.name != "Finish")
            {
                GetComponent<TrackBlockScript>().OnBecameInvisible();
            }
        }
        if (this.gameObject.name == "Finish" && other.gameObject.name == GameObject.FindObjectOfType<Player1MoveScript>().name)
        {
            GameObject.FindGameObjectWithTag("RaceEnd").GetComponent<AudioSource>().Play();
            P1Finished = true;
            GameObject.FindObjectOfType<Player1LevelScript>().Finsihed = true;
            //startTimer = true;
            //if (GameObject.FindObjectOfType<Player2LevelScript>().Finsihed)
            //{
            //    //P2 won
            //    P2Finished = true;
            //    if (P1Finished && P2Finished)
            //    {
            //        GameObject.FindObjectOfType<Player2LevelScript>().Finsihed = true;
            //    }   
            //}
        }
        //if (!GameObject.FindObjectOfType<Player2LevelScript>().Finsihed && GameObject.FindObjectOfType<Player1LevelScript>().Finsihed)
        //{

        //}
        //if(secondsLeft < 0)
        //{
        //    //P2 not finshed in time
        //    P2Finished = true;
        //    GameObject.FindObjectOfType<Player2LevelScript>().Finsihed = true;
        //}
        if (this.gameObject.name == "Finish" && other.gameObject.name == GameObject.FindObjectOfType<Player2MoveScript>().name)
        {
            GameObject.FindGameObjectWithTag("RaceEnd").GetComponent<AudioSource>().Play();
            P2Finished = true;
            GameObject.FindObjectOfType<Player2LevelScript>().Finsihed = true;
            //startTimer = true;
            //if (GameObject.FindObjectOfType<Player1LevelScript>().Finsihed)
            //{
            //    P1Finished = true;
            //    //P1 won
            //    if (P2Finished && P1Finished)
            //    {
            //        GameObject.FindObjectOfType<Player1LevelScript>().Finsihed = true;
            //    }
            //}
        }
        if (GameObject.FindObjectOfType<Player2LevelScript>().Finsihed)
        {
            P2Finished = true;
        }
        if (GameObject.FindObjectOfType<Player1LevelScript>().Finsihed)
        {
            P1Finished = true;
        }
        //if (!GameObject.FindObjectOfType<Player1LevelScript>().Finsihed && GameObject.FindObjectOfType<Player2LevelScript>().Finsihed)
        //{
        //    if (Time.time > (timer + 1))
        //    {
        //        timer = Time.time;
        //        secondsLeft--;
        //    }
        //}
        //if (secondsLeft < 0)
        //{
        //    //P1 not finished in time
        //    P1Finished = true;
        //    GameObject.FindObjectOfType<Player1LevelScript>().Finsihed = true;
        //}

        //if (P2Finished && P1Finished)
        //{
        //    //GameObject.FindObjectOfType<ConfirmScript>().round++;
        //    //Application.LoadLevel(3);
        //    Application.LoadLevel(Application.loadedLevel);
        //}
    }

    public void WallAnimation(bool activate = false)
    {
        if(activate)
        {
            isActivated = true;
            if (Time.time > (shootingWallTimer + 0.5f))
            {
                shootingWallTimer = Time.time;
                shootingWallCount++;
                if (this.gameObject.GetComponent<MeshRenderer>().enabled == true)
                {
                    this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                }
                else if (this.gameObject.GetComponent<MeshRenderer>().enabled == false)
                {
                    this.gameObject.GetComponent<MeshRenderer>().enabled = true;
                }
            }
            if (shootingWallCount == 4)
            {
                isActivated = false;
            }
        }
    }
}
