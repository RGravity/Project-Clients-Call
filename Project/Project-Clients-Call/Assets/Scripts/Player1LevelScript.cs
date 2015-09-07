using UnityEngine;
using System.Collections;

public class Player1LevelScript : MonoBehaviour {

    private float _speed = 1f;
    private bool _slowSpeed = false;
    private bool _increaseSpeed = false;
    private int _iteration = 0;
    private bool _stopSpeed = false;
    private float _oldTime = 0;
    private bool _finished = false;

    public bool SlowSpeed { get { return _slowSpeed; } set { _slowSpeed = value; } }
    public bool StopSpeed { get { return _stopSpeed; } set { _stopSpeed = value; } }
    public bool IncreaseSpeed { get { return _increaseSpeed; } set { _increaseSpeed = value; } }
    public bool Finsihed { get { return _finished; } set { _finished = value; } }

    // Update is called once per frame
    void Update()
    {
        MoveWorld();
        ResolveCollision();
    }

    private void MoveWorld()
    {
        if (!Input.GetKey(KeyCode.Space) && _finished == false)
        {
            //_speed += 0.05f;
            //gameObject.transform.position = transform.position - (transform.forward * _speed * Time.deltaTime);
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
            if (_iteration >= 3)
            {
                _increaseSpeed = false;
                _iteration = 0;
            }
        }
        if (_stopSpeed)
        {
            float stopSpeed = 0;
            float oldSpeed = _speed;
            _speed = stopSpeed;

            if (Time.time > (_oldTime + 7))
            {
                _speed = oldSpeed / 2;
                _stopSpeed = false;
            }
        }
    }
}
