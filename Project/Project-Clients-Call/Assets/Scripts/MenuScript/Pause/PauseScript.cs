using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseScript : MonoBehaviour {

	public bool pauseGame = false;
    private bool _moving = false;
    private float _speedP1 = 0;
    private float _speedP2 = 0;

    private bool _backToMenu = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        CheckPause();
	}

    void CheckPause()
    {
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7) || Input.GetKeyDown(KeyCode.Joystick2Button7))
		{
			pauseGame = !pauseGame;
			
			if (pauseGame == true)
			{
                _speedP1 = GameObject.FindObjectOfType<Player1LevelScript>().Speed;
                _speedP2 = GameObject.FindObjectOfType<Player2LevelScript>().Speed;
                GameObject.FindObjectOfType<Player1LevelScript>().Speed = 0;
                GameObject.FindObjectOfType<Player2LevelScript>().Speed = 0;
                GameObject.Find("Canvas").GetComponent<Image>().enabled = true;
                GameObject.Find("ResumeArrows").GetComponent<Image>().enabled = true;
                GameObject.Find("QuitArrows").GetComponent<Image>().enabled = false;
				Time.timeScale = 0;
				pauseGame = true;
			}
		if (pauseGame == false)
		{
                GameObject.FindObjectOfType<Player1LevelScript>().Speed = _speedP1;
                GameObject.FindObjectOfType<Player2LevelScript>().Speed = _speedP2;
            GameObject.Find("QuitArrows").GetComponent<Image>().enabled = false;
            GameObject.Find("Canvas").GetComponent<Image>().enabled = false;
            GameObject.Find("ResumeArrows").GetComponent<Image>().enabled = false;
			Time.timeScale = 1;
            pauseGame = false;
		}
		}
        if (pauseGame == true)
        {
            GameObject.FindObjectOfType<Player1LevelScript>().Speed = 0;
            GameObject.FindObjectOfType<Player2LevelScript>().Speed = 0;
        }

        Selection();
        Choice();
        BackToMenu();
    }

    void Selection ()
    {
        if (pauseGame && Input.GetAxis("Vertical P1") < -0.5f || pauseGame && Input.GetAxis("Vertical P2") < -0.5f)
        {
            GameObject.Find("Canvas").GetComponent<Image>().enabled = true;
            GameObject.Find("ResumeArrows").GetComponent<Image>().enabled = false;
            GameObject.Find("QuitArrows").GetComponent<Image>().enabled = true;
        
        }

        if (pauseGame && Input.GetAxis("Vertical P1") > 0.5f || pauseGame && Input.GetAxis("Vertical P2") > 0.5f)
        {
            
            GameObject.Find("Canvas").GetComponent<Image>().enabled = true;
            GameObject.Find("ResumeArrows").GetComponent<Image>().enabled = true;
            GameObject.Find("QuitArrows").GetComponent<Image>().enabled = false;
        }

    }

    void Choice()
    {
        if (pauseGame && GameObject.Find("ResumeArrows").GetComponent<Image>() != enabled && Input.GetButton("FireP1") ||
           pauseGame && GameObject.Find("ResumeArrows").GetComponent<Image>() != enabled && Input.GetButton("FireP2"))
        {
            pauseGame = false;
            Time.timeScale = 1;
            _backToMenu = true;

        }
        if (pauseGame && GameObject.Find("ResumeArrows").GetComponent<Image>() == enabled && Input.GetButton("FireP1") ||
            pauseGame && GameObject.Find("ResumeArrows").GetComponent<Image>() == enabled && Input.GetButton("FireP2"))
        {
            _backToMenu = true;
            Time.timeScale = 1;
        }

    }

    void BackToMenu()
    {
        if (_backToMenu == true)
        {
            Application.LoadLevel(2);
            GameObject.FindObjectOfType<MusicScript>().Play2 = true;
            GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer1 = 0;
            GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer2 = 0;
            GameObject.FindObjectOfType<ConfirmScript>().SavedP1Score = 0;
            GameObject.FindObjectOfType<ConfirmScript>().SavedP2Score = 0;
            _backToMenu = false;
        }
       
    }
}
