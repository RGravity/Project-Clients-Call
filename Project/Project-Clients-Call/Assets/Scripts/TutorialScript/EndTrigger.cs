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
            Application.LoadLevel(3);
            _confirmScript.Tutorial = false;
            _confirmScript.SavedP1Score = 0;
        }
    }
}