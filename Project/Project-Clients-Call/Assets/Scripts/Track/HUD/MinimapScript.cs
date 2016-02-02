using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MinimapScript : MonoBehaviour {

    private float _currentSpeedP1;
    private float _currentSpeedP2;
    private float _scale = 2.55f;

    private Texture2D _red;
    private Texture2D _blue;
    private Texture2D _orange;
    private Texture2D _green;

    private Player1LevelScript _player1LevelScript;
    private Player2LevelScript _player2LevelScript;
    private GameObject _player1Minimap;
    private GameObject _player2Minimap;


    // Use this for initialization
    void Start () {
        _red = (Texture2D)Resources.Load("MinimapColor/player_red");
        _blue = (Texture2D)Resources.Load("MinimapColor/player_blue");
        _orange = (Texture2D)Resources.Load("MinimapColor/player_orange");
        _green = (Texture2D)Resources.Load("MinimapColor/player_green");

        Sprite red = Sprite.Create(_red,new Rect(0,0,_red.width,_red.height),new Vector2(0.5f,0.5f));
        Sprite blue = Sprite.Create(_blue, new Rect(0, 0, _red.width, _red.height), new Vector2(0.5f, 0.5f));
        Sprite orange = Sprite.Create(_orange, new Rect(0, 0, _red.width, _red.height), new Vector2(0.5f, 0.5f));
        Sprite green = Sprite.Create(_green, new Rect(0, 0, _red.width, _red.height), new Vector2(0.5f, 0.5f));


        int choiceP1 = GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer1;
        switch (choiceP1)
        {
            case 0:
                GameObject.Find("Player1MinimapIcon").GetComponent<Image>().sprite = green;
                break;
            case 1:
                GameObject.Find("Player1MinimapIcon").GetComponent<Image>().sprite = red;
                break;
            case 2:
                GameObject.Find("Player1MinimapIcon").GetComponent<Image>().sprite = blue;
                break;
            case 3:
                GameObject.Find("Player1MinimapIcon").GetComponent<Image>().sprite = orange;
                break;
            default:
                break;
        }
        int choiceP2 = GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer2;
        switch (choiceP2)
        {
            case 0:
                GameObject.Find("Player2MinimapIcon").GetComponent<Image>().sprite = green;

                break;
            case 1:
                GameObject.Find("Player2MinimapIcon").GetComponent<Image>().sprite = red;

                break;
            case 2:
                GameObject.Find("Player2MinimapIcon").GetComponent<Image>().sprite = blue;

                break;
            case 3:
                GameObject.Find("Player2MinimapIcon").GetComponent<Image>().sprite = orange;

                break;
            default:
                break;
        }

        _player1LevelScript = GameObject.FindObjectOfType<Player1LevelScript>();
        _player2LevelScript = GameObject.FindObjectOfType<Player2LevelScript>();
        _player1Minimap = GameObject.Find("Player1MinimapIcon");
        _player2Minimap = GameObject.Find("Player2MinimapIcon");
    }
	
	// Update is called once per frame
	void Update () {
        MovePlayerMinimap();
      
	}

    void MovePlayerMinimap()
    {
        if (_player1LevelScript.LevelStarted && !_player1LevelScript.Finsihed)
        {
            _currentSpeedP1 = _player1LevelScript.Speed * _scale;
            _player1Minimap.GetComponent<RectTransform>().position = _player1Minimap.GetComponent<RectTransform>().position + (transform.right * _currentSpeedP1 * Time.deltaTime);
            
            
        }
        if (_player2LevelScript.LevelStarted && !_player2LevelScript.Finsihed)
        {
            _currentSpeedP2 = _player2LevelScript.Speed * _scale;
            _player2Minimap.GetComponent<RectTransform>().position = _player2Minimap.GetComponent<RectTransform>().position + (transform.right * _currentSpeedP2 * Time.deltaTime);

        }
    }
}
