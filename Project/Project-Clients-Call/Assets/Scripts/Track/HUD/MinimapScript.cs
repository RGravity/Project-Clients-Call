using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MinimapScript : MonoBehaviour {

    private float _currentSpeedP1;
    private float _currentSpeedP2;
    private float _scale = 2.7f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        MovePlayerMinimap();
	}

    void MovePlayerMinimap()
    {
        if (GameObject.FindObjectOfType<Player1LevelScript>().LevelStarted && !GameObject.FindObjectOfType<Player1LevelScript>().Finsihed)
        {
            _currentSpeedP1 = GameObject.FindObjectOfType<Player1LevelScript>().Speed * _scale;
            GameObject.Find("Player1MinimapIcon").GetComponent<RectTransform>().position = GameObject.Find("Player1MinimapIcon").GetComponent<RectTransform>().position + (transform.right * _currentSpeedP1 * Time.deltaTime); 
        }
        if (GameObject.FindObjectOfType<Player2LevelScript>().LevelStarted && !GameObject.FindObjectOfType<Player2LevelScript>().Finsihed)
        {
            _currentSpeedP2 = GameObject.FindObjectOfType<Player2LevelScript>().Speed * _scale;
            GameObject.Find("Player2MinimapIcon").GetComponent<RectTransform>().position = GameObject.Find("Player2MinimapIcon").GetComponent<RectTransform>().position + (transform.right * _currentSpeedP2 * Time.deltaTime);
        }
    }
}
