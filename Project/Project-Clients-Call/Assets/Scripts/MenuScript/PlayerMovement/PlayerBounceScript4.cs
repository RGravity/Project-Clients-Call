﻿using UnityEngine;
using System.Collections;

public class PlayerBounceScript4 : MonoBehaviour
{

    private bool _movingUp = false;
    private bool _movingDown = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (this.transform.position.y <= -19.6f)
        {
            _movingUp = true;
            _movingDown = false;
        }
        if (this.transform.position.y >= -17)
        {
            _movingUp = false;
            _movingDown = true;

        }

        if (_movingDown == true)
        {
            this.transform.position -= new Vector3(0, 0.175f, 0);
        }

        if (_movingUp == true)
        {
            this.transform.position += new Vector3(0, 0.175f, 0);
        }
    }
}
