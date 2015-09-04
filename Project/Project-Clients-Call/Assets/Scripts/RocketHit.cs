using UnityEngine;
using System.Collections;

public class RocketHit : MonoBehaviour {

    private bool _hitted = false;
    private float _oldTime = 0;
    private bool _isPlayer1 = false;
    private float _hittedTime = 0;
    private bool _timerSet = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (_hitted == true)
        {
            if (_hitted == true && _timerSet == false)
            {
               // _hittedTime = Time.time;
                _oldTime = Time.time;
                _timerSet = true;
            }
            if (Time.time > (_oldTime + 1.5f) && _isPlayer1 == true)
            {
                _oldTime = Time.time;
                GameObject.FindObjectOfType<Player1LevelScript>().StopSpeed = true;
                _isPlayer1 = false;
                _hitted = false;
                _timerSet = false;
                Destroy(this.gameObject);
            }
            else if (Time.time > (_oldTime + 1.5f) && _isPlayer1 == false)
            {
                _oldTime = Time.time;
                _isPlayer1 = false;
                GameObject.FindObjectOfType<Player2LevelScript>().StopSpeed = true;
                _hitted = false;
                _timerSet = false;
                Destroy(this.gameObject);
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == GameObject.FindObjectOfType<Player1MoveScript>().name && !GameObject.FindObjectOfType<PowerUpScriptP1>().Invulnerable)
        {
            _isPlayer1 = true;
            _hitted = true;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        if (other.gameObject.name == GameObject.FindObjectOfType<Player2MoveScript>().name && !GameObject.FindObjectOfType<PowerUpScriptP1>().Invulnerable)
        {
            _isPlayer1 = false;
            _hitted = true;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
