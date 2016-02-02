using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Finish : MonoBehaviour {

    public bool P1Finished = false;
    public bool P2Finished = false;
    bool startTimer = false;

    int round = 2;

    float timer = 0;
    float secondsLeftP1 = 5;
    float secondsLeftP2 = 5;
    bool isActivated = false;
    float shootingWallTimer = 0;
    int shootingWallCount = 0;

    float reloadTime = 0;
    bool showTime = true;
    bool endTime = true;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindObjectOfType<ConfirmScript>().Tutorial == false)
        {
            if (P1Finished)
            {
                if (secondsLeftP1 > 0)
                {
                    GameObject.Find("FinishP1").GetComponent<Image>().enabled = true;
                }
                else
                {
                    GameObject.Find("dnfP1").GetComponent<Image>().enabled = true;
                }
                if (Time.time > (timer + 1))
                {
                    timer = Time.time;
                    secondsLeftP2--;
                }
            }
            if (P2Finished)
            {
                if (secondsLeftP2 > 0)
                {
                    GameObject.Find("FinishP2").GetComponent<Image>().enabled = true;
                }
                else
                {
                    GameObject.Find("dnfP2").GetComponent<Image>().enabled = true;
                }
                if (Time.time > (timer + 1))
                {
                    timer = Time.time;
                    secondsLeftP1--;
                }
            }
            if (P1Finished && P2Finished)
            {
                //Application.LoadLevel(3);
                GameObject.FindObjectOfType<ConfirmScript>().Round++;
                if (GameObject.FindObjectOfType<ConfirmScript>().Round < 6)
                {
                    GameObject.FindObjectOfType<ConfirmScript>().Round+=2;
                    Application.LoadLevel(3);
                }
                else
                {
                    if ((GameObject.Find("WinnaarP2").GetComponent<Image>().enabled == true || GameObject.Find("WinnaarP1").GetComponent<Image>().enabled == true) && endTime == true)
                    {
                        reloadTime = Time.time;
                        endTime = false;
                    }
                    if (Time.time > (reloadTime + 3))
                    {
                        GameObject.FindObjectOfType<MusicScript>().Play2 = true;
                        GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer1 = 0;
                        GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer2 = 0;
                        GameObject.FindObjectOfType<ConfirmScript>().SavedP1Score = 0;
                        GameObject.FindObjectOfType<ConfirmScript>().SavedP2Score = 0;
                        Application.LoadLevel("MenuEliasMichiel");
                    }
                    //reloadTime = Time.time;
                    round = GameObject.FindObjectOfType<ConfirmScript>().Round;
                    GameObject.Find("dnfP2").GetComponent<Image>().enabled = false;
                    GameObject.Find("dnfP1").GetComponent<Image>().enabled = false;
                    GameObject.Find("FinishP1").GetComponent<Image>().enabled = false;
                    GameObject.Find("FinishP2").GetComponent<Image>().enabled = false;
                    if (GameObject.FindObjectOfType<ScoreScript>().P1Score > GameObject.FindObjectOfType<ScoreScript>().P2Score && GameObject.FindObjectOfType<ConfirmScript>().Round > 6)
                    {
                        GameObject.Find("WinnaarP1").GetComponent<Image>().enabled = true;
                        GameObject.Find("WinnaarP2").GetComponent<Image>().enabled = false;
                    }
                    else if (GameObject.FindObjectOfType<ScoreScript>().P1Score > GameObject.FindObjectOfType<ScoreScript>().P2Score && GameObject.FindObjectOfType<ConfirmScript>().Round > 6)
                    {
                        GameObject.Find("WinnaarP2").GetComponent<Image>().enabled = true;
                        GameObject.Find("WinnaarP1").GetComponent<Image>().enabled = false;
                    }
                }
            }
            if (secondsLeftP1 < 0 && round < 7)
            {
                //P1 lost
                if (showTime == true)
                {
                    reloadTime = Time.time;
                    if (Time.time > (reloadTime + 5))
                    {
                        showTime = false;
                    }
                    else
                    {
                        GameObject.Find("dnfP1").GetComponent<Image>().enabled = true;
                        GameObject.FindObjectOfType<Player1LevelScript>().Finsihed = true;
                        P1Finished = true;
                    }
                }
                else
                {
                    //GameObject.FindObjectOfType<Player1LevelScript>().Finsihed = true;
                    // P1Finished = true;
                }

            }
            if (secondsLeftP2 < 0 && round < 7)
            {
                //P2 lost

                if (showTime == true)
                {
                    reloadTime = Time.time;
                    if (Time.time > (reloadTime + 5))
                    {
                        showTime = false;
                    }
                    else
                    {
                        GameObject.Find("dnfP2").GetComponent<Image>().enabled = true;
                        GameObject.FindObjectOfType<Player2LevelScript>().Finsihed = true;
                        P2Finished = true;
                    }
                }
                else
                {
                    //GameObject.FindObjectOfType<Player2LevelScript>().Finsihed = true;
                    //P2Finished = true;
                }
            }
        }
        //WallAnimation(isActivated);
	}
    void OnTriggerExit(Collider other)
    {
       
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
        //    //GameObject.FindObjectOfType<ConfirmScript>().Round++;
        //    //Application.LoadLevel(3);
        //    Application.LoadLevel(Application.loadedLevel);
        //}
    }

    //public void WallAnimation(bool activate = false)
    //{
    //    if (activate)
    //    {
    //        isActivated = true;
    //        if (Time.time > (shootingWallTimer + 0.5f))
    //        {
    //            shootingWallTimer = Time.time;
    //            shootingWallCount++;
    //            if (this.gameObject.GetComponent<MeshRenderer>().enabled == true)
    //            {
    //                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    //            }
    //            else if (this.gameObject.GetComponent<MeshRenderer>().enabled == false)
    //            {
    //                this.gameObject.GetComponent<MeshRenderer>().enabled = true;
    //            }
    //        }
    //        if (shootingWallCount == 4)
    //        {
    //            isActivated = false;
    //        }
    //    }
    //}
}
