using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialSkipScript : MonoBehaviour {

    // Use this for initialization
    ConfirmScript confirmScript;
    float oldTime = 0;
    bool playTut = false;
    Image skipText;
    void Start () {
        confirmScript = GameObject.FindObjectOfType<ConfirmScript>();
        oldTime = Time.time;
        skipText = GameObject.Find("SkipText").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //show text
        if (Time.time > oldTime + 5)
        {
            playTut = true;
            confirmScript.DoTutorial = false;
            skipText.enabled = false;
        }
        else
        {
            if (playTut == false)
            {
                if (Input.GetButtonDown("SkipTutorial"))
                {
                    confirmScript.DoTutorial = false;
                    confirmScript.Tutorial = false;
                    Application.LoadLevel(3);
                }
            }
            //hide text
        }


	
	}
}
