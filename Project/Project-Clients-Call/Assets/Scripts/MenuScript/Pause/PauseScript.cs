using UnityEngine;
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
				Time.timeScale = 0;
				pauseGame = true;
			}
		}
		
		if (pauseGame == false)
		{
			Time.timeScale = 1;
            pauseGame = false;
		}
    }
}
