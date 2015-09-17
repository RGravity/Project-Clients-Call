using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseScript : MonoBehaviour {

	public bool pauseGame = false;
    private bool _moving = false;

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
                GameObject.Find("Canvas").GetComponent<Image>().enabled = true;
                GameObject.Find("ResumeArrows").GetComponent<Image>().enabled = true;
                GameObject.Find("QuitArrows").GetComponent<Image>().enabled = false;
				Time.timeScale = 0;
				pauseGame = true;
			}
		}
		
		if (pauseGame == false)
		{
            GameObject.Find("QuitArrows").GetComponent<Image>().enabled = false;
            GameObject.Find("Canvas").GetComponent<Image>().enabled = false;
            GameObject.Find("ResumeArrows").GetComponent<Image>().enabled = false;
			Time.timeScale = 1;
            pauseGame = false;
		}
        Selection();
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
        if (pauseGame && GameObject.Find("ResumeArrows").GetComponent<Image>() == enabled && Input.GetButton ("FireP1") ||
            pauseGame && GameObject.Find("ResumeArrows").GetComponent<Image>() == enabled && Input.GetButton("FireP2"))
        {
            pauseGame = false;

        }

        if (pauseGame && GameObject.Find("ResumeArrows").GetComponent<Image>() == enabled && Input.GetButton("FireP1") ||
            pauseGame && GameObject.Find("ResumeArrows").GetComponent<Image>() == enabled && Input.GetButton("FireP2"))
        {
            Application.LoadLevel(2);
            GameObject.FindObjectOfType<MusicScript>().Play2 = true;
            GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer1 = 0;
            GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer2 = 0;
            GameObject.FindObjectOfType<ConfirmScript>().SavedP1Score = 0;
            GameObject.FindObjectOfType<ConfirmScript>().SavedP2Score = 0;
        }
    }
}
