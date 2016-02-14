using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinishTrigger : MonoBehaviour {

    private GameObject _textBox;
    private GameObject _textBox2;
    private ConfirmScript _confirmScript;
    private bool _isFinished = false;
    private float _oldTime = 0;
    // Use this for initialization
    void Start()
    {
        _textBox = GameObject.Find("TestText");
        _textBox2 = GameObject.Find("FinishText");
        _confirmScript = FindObjectOfType<ConfirmScript>();
    }


    // Update is called once per frame
    void Update()
    {
        if (_isFinished)
        {
            //show text
            if (Time.time > (_oldTime + 10))
            {
                _confirmScript.DoTutorial = true;
            }
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player 1")
        {
            _isFinished = true;
            _oldTime = Time.time;
                _textBox.GetComponent<Image>().enabled = false;
                _textBox2.GetComponent<Image>().enabled = true;
        }
    }
}
