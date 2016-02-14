using UnityEngine;
using System.Collections;

public class TutorialSkipScript : MonoBehaviour {

    // Use this for initialization
    ConfirmScript confirmScript;
    float oldTime = 0;
	void Start () {
        confirmScript = GameObject.FindObjectOfType<ConfirmScript>();
        oldTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > oldTime + 5)
        {
            //show text
            if (Input.GetButtonDown("SkipTutorial"))
            {
                confirmScript.DoTutorial = false;
                Application.LoadLevel(3);
            }
        }
        else
        {
            //hide text
        }


	
	}
}
