using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseScript : MonoBehaviour {

	private bool pauseGame = false;

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
    }
}
