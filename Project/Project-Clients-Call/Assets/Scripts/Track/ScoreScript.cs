using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {

    public enum ScoreType
    {
        None,
        Coin,
        Wall,
        Checkpoint,
        ShootWall,
        ShootSuperWall,
        HitSuperWall,
        PickUp,
    }
    private int _p1Score = 0;
    private int _p2Score = 0;

    private ScoreType _p1ScoreType = ScoreType.None;
    private ScoreType _p2ScoreType = ScoreType.None;

    public ScoreType P1ScoreType { set { _p1ScoreType = value; } }
    public ScoreType P2ScoreType { set { _p2ScoreType = value; } }

    public int P1Score { get { return _p1Score; } set { _p1Score = value; } }
    public int P2Score { get { return _p2Score; } set { _p2Score = value; } }


	// Use this for initialization
	void Start () {
        if (GameObject.FindObjectOfType<ConfirmScript>())
        {
            _p1Score = GameObject.FindObjectOfType<ConfirmScript>().SavedP1Score;
            _p2Score = GameObject.FindObjectOfType<ConfirmScript>().SavedP2Score;
        }
	}
	
	// Update is called once per frame
	void Update () {
        ExternalScoring();
        NormalScoring();
        UpdateHUD();
	}

    private void ExternalScoring()
    {
        switch (_p1ScoreType)
        {
            case ScoreType.None:
                break;
            case ScoreType.Coin:
                _p1Score += 2500;
                _p1ScoreType = ScoreType.None;
                break;
            case ScoreType.Wall:
                _p1Score -= 1000;
                _p1ScoreType = ScoreType.None;
                break;
            case ScoreType.Checkpoint:
                _p1Score += 3000;
                _p1ScoreType = ScoreType.None;
                break;
            case ScoreType.ShootWall:
                _p1Score += 2500;
                _p1ScoreType = ScoreType.None;
                break;
            case ScoreType.ShootSuperWall:
                _p1Score += 5000;
                _p1ScoreType = ScoreType.None;
                break;
            case ScoreType.HitSuperWall:
                _p1Score -= 2500;
                _p1ScoreType = ScoreType.None;
                break;
            case ScoreType.PickUp:
                _p1Score += 2000;
                _p1ScoreType = ScoreType.None;
                break;
        }
        if (_p1Score < 0)
        {
            _p1Score = 0;
        }
        switch (_p2ScoreType)
        {
            case ScoreType.None:
                break;
            case ScoreType.Coin:
                _p2Score += 2500;
                _p2ScoreType = ScoreType.None;
                break;
            case ScoreType.Wall:
                _p2Score -= 1000;
                _p2ScoreType = ScoreType.None;
                break;
            case ScoreType.Checkpoint:
                _p2Score += 3000;
                _p2ScoreType = ScoreType.None;
                break;
            case ScoreType.ShootWall:
                _p2Score += 2500;
                _p2ScoreType = ScoreType.None;
                break;
            case ScoreType.ShootSuperWall:
                _p2Score += 5000;
                _p2ScoreType = ScoreType.None;
                break;
            case ScoreType.HitSuperWall:
                _p2Score -= 2500;
                _p2ScoreType = ScoreType.None;
                break;
            case ScoreType.PickUp:
                _p2Score += 2000;
                _p2ScoreType = ScoreType.None;
                break;
        }
        if (_p2Score < 0)
        {
            _p2Score = 0;
        }
    }

    private void NormalScoring()
    {
        if (GameObject.FindObjectOfType<Player1LevelScript>().LevelStarted)
        {
            if (!GameObject.FindObjectOfType<Finish>().P1Finished && !GameObject.FindObjectOfType<PauseScript>().pauseGame)
            {
                _p1Score += (int)(GameObject.FindObjectOfType<Player1LevelScript>().Speed / 6) * 100;
            }
            if (!GameObject.FindObjectOfType<Finish>().P2Finished && !GameObject.FindObjectOfType<PauseScript>().pauseGame)
            {
                _p2Score += ((int)GameObject.FindObjectOfType<Player2LevelScript>().Speed / 6) * 100;
            }
        }
    }

    private void UpdateHUD()
    {
        GameObject.Find("P1 Text").GetComponent<Text>().text = _p1Score.ToString();
        GameObject.Find("P2 Text").GetComponent<Text>().text = _p2Score.ToString();
        if (GameObject.FindObjectOfType<ConfirmScript>())
        {
            GameObject.FindObjectOfType<ConfirmScript>().SavedP1Score = _p1Score;
            GameObject.FindObjectOfType<ConfirmScript>().SavedP2Score = _p2Score; 
        }
    }
}
