using UnityEngine;
using System.Collections;

public class Jumpscript : MonoBehaviour
{

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

    private Player1MoveScript _player1MoveScript;
    private BankingP1Script _bankingP1Script;
    private Player2MoveScript _player2MoveScript;
    private BankingP2Script _bankingP2Script;


    public bool JumpP1 { set { _jumpP1 = value; } get { return _jumpP1; } }
    public bool JumpP2 { set { _jumpP2 = value; } get { return _jumpP2; } }
    void Start () 
    {
        _defaultPlayer1Y = GameObject.FindObjectOfType<Player1MoveScript>().transform.position.y;
        _jumpHeightP1 = _defaultPlayer1Y;
        _sinus = Mathf.Sin(0.1f);
        _defaultRotationP1 = GameObject.FindObjectOfType<BankingP1Script>().transform.rotation.y;
        _rotationP1 = _defaultRotationP1;
        _player1Rotation = GameObject.FindObjectOfType<BankingP1Script>().transform.rotation;
        if (GameObject.FindObjectOfType<ConfirmScript>().Tutorial == false)
        {
        _player2Rotation = GameObject.FindObjectOfType<BankingP2Script>().transform.rotation;
            _defaultPlayer2Y = GameObject.FindObjectOfType<Player2MoveScript>().transform.position.y;
            _defaultRotationP2 = GameObject.FindObjectOfType<BankingP2Script>().transform.rotation.y;
            _jumpHeightP2 = _defaultPlayer2Y;

            _rotationP2 = _defaultRotationP2;
	    }

        _player1MoveScript = GameObject.FindObjectOfType<Player1MoveScript>();
        _bankingP1Script = GameObject.FindObjectOfType<BankingP1Script>();
        _player2MoveScript = GameObject.FindObjectOfType<Player2MoveScript>();
        _bankingP2Script = GameObject.FindObjectOfType<BankingP2Script>();
    }
	
	// Update is called once per frame
    void Update()
    {
        Jumping();
	}


    void Jumping()
    {
        if (_jumpP1)
        {
            if (_goingUp1)
            {
                _jumpHeightP1 += (((_jumpHeightP1 + _sinus) + 1) / 2) / 7;
                _rotationP1 += 0.2f;

                if (_jumpHeightP1 >= 1.8f)
                {
                    _goingUp1 = false;
                    _rotationP1 = _defaultRotationP1;
                }
            }
            else if (!_goingUp1)
            {
                _jumpHeightP1 -= (((_jumpHeightP1 - _sinus) + 1) / 2) / 7;

                if (_jumpHeightP1 <= _defaultPlayer1Y)
                {
                    _jumpHeightP1 = _defaultPlayer1Y;
                    _rotationP1 = _defaultRotationP1;
                    _jumpP1 = false;
                    _goingUp1 = true;

            }
            Vector3 PlayerPosition = _player1MoveScript.transform.position;


            _player1MoveScript.transform.position = new Vector3(PlayerPosition.x, _jumpHeightP1, PlayerPosition.z);
            _bankingP1Script.transform.rotation = Quaternion.Euler(_player1Rotation.x, _rotationP1, _player1Rotation.z);
            
        }
        if (_jumpP2)
        {
            if (_goingUp2)
            {
                    _jumpHeightP2 += (((_jumpHeightP2 + _sinus) + 1) / 2) / 7;
                _rotationP2 += 0.2f;

                if (_jumpHeightP2 <= -3.05f)
                {
                    _goingUp2 = false;
                    _rotationP2 = _defaultRotationP2;
                }
            }
            else if (!_goingUp2)
            {
                    _jumpHeightP2 -= (((_jumpHeightP2 - _sinus) - 1) / 2) / 7;


                if (_jumpHeightP2 >= _defaultPlayer2Y)
                {
                    _jumpHeightP2 = _defaultPlayer2Y;
                    _rotationP2 = _defaultRotationP2;
                    _jumpP2 = false;
                    _goingUp2 = true;
                }

            }
            Vector3 PlayerPosition = _player2MoveScript.transform.position;

            _player2MoveScript.transform.position = new Vector3(PlayerPosition.x, _jumpHeightP2, PlayerPosition.z);
            _bankingP2Script.transform.Rotate(_player2Rotation.x, _rotationP2, _player2Rotation.z);
        }
    
    }
    }
}



