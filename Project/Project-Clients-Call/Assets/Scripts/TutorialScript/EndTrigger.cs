using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EndTrigger : MonoBehaviour {


    // Use this for initialization
    private ConfirmScript _confirmScript;
    void Start()
    {
        _confirmScript = FindObjectOfType<ConfirmScript>();
        
    }


    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player 1")
        {
            if (FindObjectOfType<ConfirmScript>().RedoTutorial == true)
            {
                FindObjectOfType<ConfirmScript>().Tutorial = true;
                FindObjectOfType<ConfirmScript>().DoTutorial = true;
                FindObjectOfType<ConfirmScript>().RedoTutorial = false;
                FindObjectOfType<ConfirmScript>().SavedP1Score = 0;
                Application.LoadLevel(3);
            }
            else
            {
                Application.LoadLevel(3);
                _confirmScript.Tutorial = false;
                _confirmScript.SavedP1Score = 0;
            }
        }
    }
}