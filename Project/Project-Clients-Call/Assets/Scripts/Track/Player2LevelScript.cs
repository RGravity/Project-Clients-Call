using UnityEngine;
using System.Collections;

public class Player2LevelScript : MonoBehaviour {

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
        Finished();
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
            if (_speed >= 35)
            {
                _speed = 35;
            }
            gameObject.transform.position = transform.position - (transform.forward * _speed * Time.deltaTime);
        }
        else if (!_levelStarted)
        {
            if (Time.time > (_stopTime + 3))
            {
                _stopTime = Time.time;
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
            if (_iteration >= 3)
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
            if (_checkpointSlowCounter != 0)
            {
                if (Time.time > (_checkpointSlowTimer + 0.5))
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

            //float slowDown = _speed - 1;
            //_speed = _speed - (slowDown / 2);
            //_iteration++;
            //if (_iteration >= 6)
            //{
            //    _stopSpeed = false;
            //    _iteration = 0;
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

    void Finished()
    {
        if (_finished)
        {
            
        }
    }
}
