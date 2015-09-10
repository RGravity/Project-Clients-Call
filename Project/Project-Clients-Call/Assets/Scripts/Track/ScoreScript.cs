using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

    public enum ScoreType
    {
        None,
        Coin,
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
	}

    private void ExternalScoring()
    {
        switch (_p1ScoreType)
        {
            case ScoreType.None:
                break;
            case ScoreType.Coin:
                _p1Score += 50;
                _p1ScoreType = ScoreType.None;
                break;
        }
        switch (_p2ScoreType)
        {
            case ScoreType.None:
                break;
            case ScoreType.Coin:
                _p2Score += 50;
                _p2ScoreType = ScoreType.None;
                break;
        }
    }

    private void NormalScoring()
    {
        _p1Score += (int)GameObject.FindObjectOfType<Player1LevelScript>().Speed / 6;
        Debug.Log(_p1Score);
    }
}
