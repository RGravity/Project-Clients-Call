using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

    private float screenTime = 0;
    // Use this for initialization
    void Start()
    {
        screenTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > (screenTime + 4f))
        {
            if (GameObject.FindObjectOfType<ConfirmScript>().Tutorial == false)
            {
                Application.LoadLevel(4);
                GameObject.FindObjectOfType<MusicScript>().Play = true;
                GameObject.FindObjectOfType<SoundsScript>().Play = true;
            }
            else
            {
                Application.LoadLevel(5);
                GameObject.FindObjectOfType<MusicScript>().Play = true;
                GameObject.FindObjectOfType<SoundsScript>().Play = true;
            }
            
        }
    }
}
