﻿using UnityEngine;
using System.Collections;

public class Player2LevelScript : MonoBehaviour {

    private float _speed = 10f;
    private float _originalSpeed = 10f;
    private bool _slowSpeed = false;
    private bool _increaseSpeed = false;
    private int _iteration = 0;

    public bool SlowSpeed { get { return _slowSpeed; } set { _slowSpeed = value; } }
    public bool IncreaseSpeed { get { return _increaseSpeed; } set { _increaseSpeed = value; } }

    // Update is called once per frame
    void Update()
    {
        MoveWorld();
        ResolveCollision();
    }

    private void MoveWorld()
    {
        if (!Input.GetKey(KeyCode.Space))
        {
            _speed += 0.05f;
            _originalSpeed += 0.05f;
            gameObject.transform.position = transform.position - (transform.forward * _speed * Time.deltaTime);
        }
    }

    private void ResolveCollision()
    {
        if (_slowSpeed)
        {
            float slowDown = _speed - 10;
            _speed = _speed - (slowDown/2);
            _slowSpeed = false;
        }
        if (_increaseSpeed)
        {
            float boost = _speed - 10;
            _speed = _speed + (boost);
            _iteration++;
            if (_iteration >= 5)
            {
                _speed = _originalSpeed;
                _increaseSpeed = false;
                _iteration = 0;
            }
        }
    }
}
