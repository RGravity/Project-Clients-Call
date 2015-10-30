using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class Player1LevelScript : MonoBehaviour {

    private float _speed = 10f;
    private float _acceleration = 0.025f;
    private bool _slowSpeed = false;
    private bool _increaseSpeed = false;
    private int _iteration = 0;
    private bool _checkpointSpeed = false;
    private float _oldTime = 0;
    private bool _finished = false;
    private float _stopTime = 0;
    private bool _stopDrill = false;
    private bool _levelStarted = false;
    public Sprite[] _Countdown;
    private float _checkpointSlowTimer = 0;
    private float _checkpointSlowCounter = 3;
    private bool _superWallHit = false;

    public bool SlowSpeed { get { return _slowSpeed; } set { _slowSpeed = value; } }
    public bool CheckPoint { get { return _checkpointSpeed; } set { _checkpointSpeed = value; } }
    public float StopTime { get { return _stopTime; } set { _stopTime = value; } }
    public bool StopDrill { get { return _stopDrill; } set { _stopDrill = value; } }
    public bool IncreaseSpeed { get { return _increaseSpeed; } set { _increaseSpeed = value; } }
    public bool Finsihed { get { return _finished; } set { _finished = value; } }
    public float Speed { get { return _speed; } set { _speed = value; } }
    public bool LevelStarted { get { return _levelStarted; } }
    public bool SuperWallHit { get { return _superWallHit; } set { _superWallHit = value; } }


    // Update is called once per frame
    void Update()
    {
        MoveWorld();
        ResolveCollision();
    }
    void Start()
    {
        _stopTime = Time.time;
    }

    private void MoveWorld()
    {
        if (!Input.GetKey(KeyCode.Space) && _finished == false && _levelStarted && _superWallHit == false)
        {
            _speed += _acceleration;
            //Debug.Log(_speed);
            if (_speed >= 35)
            {
                _speed = 35;
            }
            gameObject.transform.position = transform.position - (transform.forward * _speed * Time.deltaTime);
            if (Time.time > (_stopTime + 4))
            {
                GameObject.Find("Countdown").GetComponent<Image>().enabled = false;
            }
        }
        else if (!_levelStarted)
        {
            if (GameObject.FindObjectOfType<ConfirmScript>().Tutorial == false)
            {
                if (Time.time > (_stopTime + 0))
                {
                    GameObject.Find("Countdown").GetComponent<Image>().enabled = true;
                    GameObject.Find("Countdown").GetComponent<Image>().sprite = _Countdown[0];
                }
                if (Time.time > (_stopTime + 1))
                {
                    GameObject.Find("Countdown").GetComponent<Image>().sprite = _Countdown[1];
                }
                if (Time.time > (_stopTime + 2))
                {
                    GameObject.Find("Countdown").GetComponent<Image>().sprite = _Countdown[2];
                }
                if (Time.time > (_stopTime + 3))
                {
                    GameObject.Find("Countdown").GetComponent<Image>().sprite = _Countdown[3];
                    _levelStarted = true;
                }
            }
            else
            {
                _levelStarted = true;
            }
        }
    }

    private void ResolveCollision()
    {
        if (_slowSpeed)
        {
            float slowDown = _speed - 10;
            _speed = _speed - (slowDown/2);
            _iteration++;
            if (_iteration >= 5)
            {
                _slowSpeed = false;
                _iteration = 0;
            }
        }
        if (_increaseSpeed)
        {
            float boost = _speed - 10;
            _speed = _speed + (boost);
            _iteration++;
            if (_iteration >= 3)
            {
                _increaseSpeed = false;
                _iteration = 0;
            }
        }
        if (_checkpointSpeed)
        {
            //old
            //float slowDown = _speed - 1;
            //_speed = _speed - (slowDown / 2);
            //_iteration++;
            //if (_iteration >= 5)
            //{
            //    _checkpointSpeed = false;
            //    _iteration = 0;
            //}

            if (_checkpointSlowCounter != 0)
            {
                if (Time.time > (_checkpointSlowTimer + 0.2))
                {
                    _checkpointSlowTimer = Time.time;
                    _checkpointSlowCounter--;

                    if (_checkpointSlowCounter < 3)
                    {
                        _speed = _speed - (_speed / 1.5f);
                    }
                    else if (_checkpointSlowCounter < 5)
                    {
                        _speed = _speed - (_speed / 1.3f);
                    }
                    else if (_checkpointSlowCounter < 8)
                    {
                        _speed = _speed - (_speed / 1.1f);
                    }
                }
            }
            else
            {
                _checkpointSpeed = false;
                _checkpointSlowCounter = 3;
            }

            //float stopSpeed = 0;
            //float oldSpeed = _speed;
            //_speed = stopSpeed;

            //if (Time.time > (_stopTime + 3))
            //{
            //    _oldTime = Time.time;
            //    _speed = oldSpeed / 2;
            //    _stopSpeed = false;
            //}
        }
        if (_stopDrill)
        {
            float stopDrill = 0;
            float oldSpeed = _speed;
            _speed = stopDrill;

            if (Time.time > (_stopTime + 1.5f))
            {
                _oldTime = Time.time;
                _speed = oldSpeed / 2;
                _stopDrill = false;
            }
        }
    }
}
