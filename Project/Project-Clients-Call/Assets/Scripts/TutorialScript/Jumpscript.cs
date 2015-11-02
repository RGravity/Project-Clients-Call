﻿using UnityEngine;
using System.Collections;

public class Jumpscript : MonoBehaviour {

	// Use this for initialization

    private bool _jumpP1 = false;
    private bool _jumpP2 = false;

    private bool _goingUp1 = true;
    private bool _goingUp2 = true;
    private float _jumpHeightP1;
    private float _jumpHeightP2;
    private float _defaultRotationP1;
    private float _defaultRotationP2;
    private float _rotationP1;
    private float _rotationP2;

    private float _defaultPlayer1Y;
    private float _defaultPlayer2Y;
    private float _sinus;
    private Quaternion _player1Rotation;
    private Quaternion _player2Rotation;


    public bool JumpP1 { set { _jumpP1 = value; } }
    public bool JumpP2 { set { _jumpP2 = value; } }
    void Start () 
    {
        _defaultPlayer1Y = GameObject.FindObjectOfType<Player1MoveScript>().transform.position.y;
        _defaultPlayer2Y = GameObject.FindObjectOfType<Player2MoveScript>().transform.position.y;
        _jumpHeightP1 = _defaultPlayer1Y;
        _jumpHeightP2 = _defaultPlayer2Y;
        _sinus = Mathf.Sin(0.1f);
        _defaultRotationP1 = GameObject.FindObjectOfType<BankingP1Script>().transform.rotation.y;
        _defaultRotationP2 = GameObject.FindObjectOfType<BankingP2Script>().transform.rotation.y;
        _rotationP1 = _defaultRotationP1;
        _rotationP2 = _defaultRotationP2;
        _player1Rotation = GameObject.FindObjectOfType<BankingP1Script>().transform.rotation;
        _player2Rotation = GameObject.FindObjectOfType<BankingP2Script>().transform.rotation;

	}
	
	// Update is called once per frame
	void Update () 
    {
        Jumping();
	}


    void Jumping()
    {
        if (_jumpP1)
        {
            if (_goingUp1)
            {
                _jumpHeightP1 += (((_jumpHeightP1 + _sinus) + 1) / 2) / 8;
                _rotationP1 += 0.2f;

                if (_jumpHeightP1 >= 1.8f)
                {
                    _goingUp1 = false;
                    _rotationP1 = _defaultRotationP1;
                }
            }
            else if (!_goingUp1)
            {
                _jumpHeightP1 -= (((_jumpHeightP1 - _sinus) + 1) / 2) / 8;

                if (_jumpHeightP1 <= _defaultPlayer1Y)
                {
                    _jumpHeightP1 = _defaultPlayer1Y;
                    _rotationP1 = _defaultRotationP1;
                    _jumpP1 = false;
                    _goingUp1 = true;
                }

            }
            Vector3 PlayerPosition = GameObject.FindObjectOfType<Player1MoveScript>().transform.position;
          

            GameObject.FindObjectOfType<Player1MoveScript>().transform.position = new Vector3(PlayerPosition.x, _jumpHeightP1, PlayerPosition.z);
            GameObject.FindObjectOfType<BankingP1Script>().transform.rotation = Quaternion.Euler(_player1Rotation.x, _rotationP1, _player1Rotation.z);
            
        }
        if (_jumpP2)
        {
            if (_goingUp2)
            {
                _jumpHeightP2 += (((_jumpHeightP2 + _sinus) + 1) / 2) / 8;
                _rotationP2 += 0.2f;

                if (_jumpHeightP2 <= -3.05f)
                {
                    _goingUp2 = false;
                    _rotationP2 = _defaultRotationP2;
                }
            }
            else if (!_goingUp2)
            {
                _jumpHeightP2 -= (((_jumpHeightP2 - _sinus) - 1) / 2) / 8;


                if (_jumpHeightP2 >= _defaultPlayer2Y)
                {
                    _jumpHeightP2 = _defaultPlayer2Y;
                    _rotationP2 = _defaultRotationP2;
                    _jumpP2 = false;
                    _goingUp2 = true;
                }

            }
            Vector3 PlayerPosition = GameObject.FindObjectOfType<Player2MoveScript>().transform.position;
          

            GameObject.FindObjectOfType<Player2MoveScript>().transform.position = new Vector3(PlayerPosition.x, _jumpHeightP2, PlayerPosition.z);
            GameObject.FindObjectOfType<BankingP2Script>().transform.rotation = Quaternion.Euler(_player2Rotation.x, _rotationP2, _player2Rotation.z);
            
        }
    
    }


}