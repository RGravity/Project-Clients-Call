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

    private ConfirmScript _confirmScript;
    private GameObject _finishP1;
    private GameObject _dnfP1;
    private GameObject _finishP2;
    private GameObject _dnfp2;
    private GameObject _winnaarP2;
    private GameObject _winnaarP1;
    private ScoreScript _scoreScript;
    private MusicScript _musicScript;
    private Player1LevelScript _player1LevelScript;
    private Player2LevelScript _player2LevelScript;
    private Player1MoveScript _player1MoveScript;
    private Player2MoveScript _player2MoveScript;
    private GameObject _raceEnd;

    // Use this for initialization
    void Start () {
        _confirmScript = GameObject.FindObjectOfType<ConfirmScript>();
        _finishP1 = GameObject.Find("FinishP1");
        _dnfP1 = GameObject.Find("dnfP1");
        _finishP2 = GameObject.Find("FinishP2");
        _dnfp2 = GameObject.Find("dnfP2");
        _winnaarP2 = GameObject.Find("WinnaarP2");
        _winnaarP1 = GameObject.Find("WinnaarP1");
        _scoreScript = GameObject.FindObjectOfType<ScoreScript>();
        _musicScript = GameObject.FindObjectOfType<MusicScript>();
        _player1LevelScript = GameObject.FindObjectOfType<Player1LevelScript>();
        _player2LevelScript = GameObject.FindObjectOfType<Player2LevelScript>();
        _player1MoveScript = GameObject.FindObjectOfType<Player1MoveScript>();
        _player2MoveScript = GameObject.FindObjectOfType<Player2MoveScript>();
        _raceEnd = GameObject.FindGameObjectWithTag("RaceEnd");
    }
	
	// Update is called once per frame
	void Update () {
        if (_confirmScript.Tutorial == false)
        {
            if (P1Finished)
            {
                if (secondsLeftP1 > 0)
                {
                    _finishP1.GetComponent<Image>().enabled = true;
                }
                else
                {
                    _dnfP1.GetComponent<Image>().enabled = true;
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
                    _finishP2.GetComponent<Image>().enabled = true;
                }
                else
                {
                    _dnfp2.GetComponent<Image>().enabled = true;
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
                if (_confirmScript.Round < 3)
                {
                    _confirmScript.Round++;
                    Application.LoadLevel(3);
                }
                else
                {
                    if ((_winnaarP2.GetComponent<Image>().enabled == true || _winnaarP1.GetComponent<Image>().enabled == true) && endTime == true)
                    {
                        reloadTime = Time.time;
                        endTime = false;
                    }
                    if (Time.time > (reloadTime + 3))
                    {
                        _musicScript.Play2 = true;
                        _confirmScript.bodyPlayer1 = 0;
                        _confirmScript.bodyPlayer2 = 0;
                        _confirmScript.SavedP1Score = 0;
                        _confirmScript.SavedP2Score = 0;
                        Application.LoadLevel("MenuEliasMichiel");
                    }
                    //reloadTime = Time.time;
                    round = _confirmScript.Round;
                    _dnfp2.GetComponent<Image>().enabled = false;
                    _dnfP1.GetComponent<Image>().enabled = false;
                    _finishP1.GetComponent<Image>().enabled = false;
                    _finishP2.GetComponent<Image>().enabled = false;
                    if (_scoreScript.P1Score > _scoreScript.P2Score && _confirmScript.Round > 6)
                    {
                        _winnaarP1.GetComponent<Image>().enabled = true;
                        _winnaarP2.GetComponent<Image>().enabled = false;
                    }
                    else if (_scoreScript.P1Score > _scoreScript.P2Score && _confirmScript.Round > 6)
                    {
                        _winnaarP2.GetComponent<Image>().enabled = true;
                        _winnaarP1.GetComponent<Image>().enabled = false;
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
                        _dnfP1.GetComponent<Image>().enabled = true;
                        _player1LevelScript.Finsihed = true;
                        P1Finished = true;
                    }
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
                        _dnfp2.GetComponent<Image>().enabled = true;
                        _player2LevelScript.Finsihed = true;
                        P2Finished = true;
                    }
                }
            }
        }
	}
    void OnTriggerExit(Collider other)
    {
       
        if (this.gameObject.name == "Finish" && other.gameObject.name == _player1MoveScript.name)
        {
            _raceEnd.GetComponent<AudioSource>().Play();
            P1Finished = true;
            _player1LevelScript.Finsihed = true;
        }
        if (this.gameObject.name == "Finish" && other.gameObject.name == _player2MoveScript.name)
        {
            _raceEnd.GetComponent<AudioSource>().Play();
            P2Finished = true;
            _player2LevelScript.Finsihed = true;

        }
        if (_player2LevelScript.Finsihed)
        {
            P2Finished = true;
        }
        if (_player1LevelScript.Finsihed)
        {
            P1Finished = true;
        }
    }
}
