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
    }
    private int _p1Score = 0;
    private int _p2Score = 0;

    private ScoreType _p1ScoreType = ScoreType.None;
    private ScoreType _p2ScoreType = ScoreType.None;

    public ScoreType P1ScoreType { set { _p1ScoreType = value; } }
    public ScoreType P2ScoreType { set { _p2ScoreType = value; } }


	// Use this for initialization
	void Start () {
	
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
                _p1Score += 250;
                _p1ScoreType = ScoreType.None;
                break;
            case ScoreType.Wall:
                _p1Score -= 300;
                _p1ScoreType = ScoreType.None;
                break;
            case ScoreType.Checkpoint:
                _p1Score += 200;
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
                _p2Score += 250;
                _p2ScoreType = ScoreType.None;
                break;
            case ScoreType.Wall:
                _p2Score -= 300;
                _p2ScoreType = ScoreType.None;
                break;
            case ScoreType.Checkpoint:
                _p2Score += 200;
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
        _p1Score += (int)GameObject.FindObjectOfType<Player1LevelScript>().Speed / 6;
        _p2Score += (int)GameObject.FindObjectOfType<Player2LevelScript>().Speed / 6;
    }

    private void UpdateHUD()
    {
        GameObject.Find("P1 Text").GetComponent<Text>().text = _p1Score.ToString();
        GameObject.Find("P2 Text").GetComponent<Text>().text = _p2Score.ToString();
    }
}
