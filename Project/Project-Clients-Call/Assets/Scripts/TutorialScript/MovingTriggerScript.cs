using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovingTriggerScript : MonoBehaviour {

    private GameObject _textBox;
	// Use this for initialization
	void Start () {
        _textBox = GameObject.Find("MovingTriggerText");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player 1")
        {
            _textBox.GetComponent<Image>().enabled = true;
        }
    }
}
