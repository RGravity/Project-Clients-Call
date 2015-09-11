using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class Player1LevelScript : MonoBehaviour {

    private float _speed = 1f;
    private bool _slowSpeed = false;
    private bool _increaseSpeed = false;
    private int _iteration = 0;
    private bool _stopSpeed = false;
    private float _oldTime = 0;
    private bool _finished = false;
    private float _stopTime = 0;
    private bool _stopDrill = false;
    private bool _levelStarted = false;

    public bool SlowSpeed { get { return _slowSpeed; } set { _slowSpeed = value; } }
    public bool StopSpeed { get { return _stopSpeed; } set { _stopSpeed = value; } }
    public float StopTime { get { return _stopTime; } set { _stopTime = value; } }
    public bool StopDrill { get { return _stopDrill; } set { _stopDrill = value; } }
    public bool IncreaseSpeed { get { return _increaseSpeed; } set { _increaseSpeed = value; } }
    public bool Finsihed { get { return _finished; } set { _finished = value; } }
    public float Speed { get { return _speed; } }
    public bool LevelStarted { get { return _levelStarted; } }


    // Update is called once per frame
    void Update()
    {
        MoveWorld();
        ResolveCollision();
    }

    private void MoveWorld()
    {
        if (!Input.GetKey(KeyCode.Space) && _finished == false && _stopSpeed == false && _levelStarted)
        {
            _speed += 0.05f;
            gameObject.transform.position = transform.position - (transform.forward * _speed * Time.deltaTime);
        }
        else if (!_levelStarted)
        {
            if (Time.time > (_stopTime + 3))
            {
                _oldTime = Time.time;
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
        if (_stopSpeed)
        {
            float slowDown = _speed - 1;
            _speed = _speed - (slowDown / 2);
            _iteration++;
            if (_iteration >= 10)
            {
                _stopSpeed = false;
                _iteration = 0;
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

            if (Time.time > (_stopTime + 3))
            {
                _oldTime = Time.time;
                _speed = oldSpeed / 2;
                _stopDrill = false;
            }
        }
    }
}
