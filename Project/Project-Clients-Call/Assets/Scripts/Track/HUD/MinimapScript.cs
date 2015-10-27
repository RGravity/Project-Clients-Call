using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MinimapScript : MonoBehaviour {

    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private Vector3 _player1Position;
    private Vector3 _player2Position;
    private Vector3 _levelDifference;
    private Vector3 _player1Difference;
    private Vector3 _player2Difference;
    private float _barWidth;
    private float _barP1Progress;
    private float _barP2Progress;
    private float _totalDist;
    private float _startPositionIconP1;
    private float _startPositionIconP2;

	// Use this for initialization
	void Start () {
        _startPosition = GameObject.FindObjectOfType<Player1MoveScript>().transform.position;
        _endPosition = GameObject.FindObjectOfType<Finish>().transform.position;
        _levelDifference = _endPosition - _startPosition;
        // get level distance by subtracting start and end
        _totalDist = _levelDifference.z;
        _barWidth = 1820;
        _startPositionIconP1 = GameObject.Find("Player1MinimapIcon").GetComponent<Transform>().position.x;
        _startPositionIconP2 = GameObject.Find("Player2MinimapIcon").GetComponent<Transform>().position.x;
	}
	
	// Update is called once per frame
	void Update () {
        MovePlayerMinimap();
	}

    void MovePlayerMinimap()
    {
        #region Player1
        _player1Position = GameObject.FindObjectOfType<Player1MoveScript>().transform.position;
        _player1Difference = _player1Position - _startPosition;
        // get player distance from start in X axis only so slopes / height doesn't affect result
        float player1Dist = _player1Difference.z;
 
        //get player's progress as a percentage of the whole distance
        float player1Progress = player1Dist / _totalDist * 100;
 
        //turn the playerProgress percentage back into the scale of barWidth
        _barP1Progress = player1Progress / 100 * _barWidth;

        float xToShow = _startPositionIconP1 + _barP1Progress;

        GameObject.Find("Player1MinimapIcon").GetComponent<RectTransform>().position = new Vector3(xToShow, this.transform.position.y, this.transform.position.z);
        #endregion

        #region Player2
        _player2Position = GameObject.FindObjectOfType<Player2MoveScript>().transform.position;
        _player2Difference = _player2Position - _startPosition;
        // get player distance from start in X axis only so slopes / height doesn't affect result
        float player2Dist = _player2Difference.z;

        //get player's progress as a percentage of the whole distance
        float player2Progress = player2Dist / _totalDist * 100;

        //turn the playerProgress percentage back into the scale of barWidth
        _barP2Progress = player2Progress / 100 * _barWidth;

        xToShow = _startPositionIconP2 + _barP2Progress;

        GameObject.Find("Player2MinimapIcon").GetComponent<Transform>().position = new Vector3(xToShow, this.transform.position.y, this.transform.position.z);
        #endregion
    }
}
