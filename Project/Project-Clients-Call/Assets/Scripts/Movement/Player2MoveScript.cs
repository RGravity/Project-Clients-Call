using UnityEngine;
using System.Collections;

public class Player2MoveScript : MonoBehaviour {

    private Vector3 _startPosition;
    private Animator _animator;
    private float _fireAnimation = 0;
    private float _maxTrackWidth = 6;

    private bool _moveVertical = false;
    private bool _moveHorizontal = false;

    private int _bodyPlayer2;
    private Player2LevelScript _p2LevelScript;
    private ConfirmScript _confirmScript;
    private AudioSource _playerMovementAudio;

    private Animator[] _animatorList;

	// Use this for initialization
	void Start () {
        _startPosition = transform.position;
        //_animator = this.GetComponentInChildren<Animator>();
        _animatorList = GetComponentsInChildren<Animator>();

        _bodyPlayer2 = GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer2;
        _confirmScript = GameObject.FindObjectOfType<ConfirmScript>();
        _p2LevelScript = GameObject.FindObjectOfType<Player2LevelScript>();
        _playerMovementAudio = GameObject.FindGameObjectWithTag("PlayerMovement").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (_p2LevelScript.LevelStarted)
        {
            Vector3 moveDir = Vector3.zero;
            moveDir.x = Input.GetAxis("Horizontal P2") * 12; // get result of AD keys in X
            moveDir.z = Input.GetAxis("Vertical P2") * 12; // get result of WS keys in Z
            transform.position -= moveDir * Time.deltaTime;

            if (transform.position.x > (_startPosition.x + _maxTrackWidth))
            {
                Vector3 newPos = new Vector3(0, 0, 0);
                newPos.x = _startPosition.x + _maxTrackWidth;
                newPos.y = transform.position.y;
                newPos.z = transform.position.z;
                transform.position = newPos;
            }
            else if (transform.position.x < (_startPosition.x - _maxTrackWidth))
            {
                Vector3 newPos = new Vector3(0, 0, 0);
                newPos.x = _startPosition.x - _maxTrackWidth;
                newPos.y = transform.position.y;
                newPos.z = transform.position.z;
                transform.position = newPos;
            }
            if (transform.position.z > (_startPosition.z + 4f))
            {
                Vector3 newPos = new Vector3(0, 0, 0);
                newPos.x = transform.position.x;
                newPos.y = transform.position.y;
                newPos.z = _startPosition.z + 4f;
                transform.position = newPos;
            }
            else if (transform.position.z < (_startPosition.z - 4f))
            {
                Vector3 newPos = new Vector3(0, 0, 0);
                newPos.x = transform.position.x;
                newPos.y = transform.position.y;
                newPos.z = _startPosition.z - 4f;
                transform.position = newPos;
            }
            Animation();
            PlayerSound();
        }
	}
    void PlayerSound()
    {

        if (Input.GetAxisRaw("Vertical P2") != 0)
        {
            if (_moveVertical == false)
            {
                // Call your event function here.
                _moveVertical = true;
                _playerMovementAudio.Play();
            }
        }
        if (Input.GetAxisRaw("Vertical P2") == 0)
        {
            _moveVertical = false;
        }

        if (Input.GetAxisRaw("Horizontal P2") != 0)
        {
            if (_moveHorizontal == false)
            {
                // Call your event function here.
                _moveHorizontal = true;
                _playerMovementAudio.Play();
            }
        }
        if (Input.GetAxisRaw("Horizontal P2") == 0)
        {
            _moveHorizontal = false;
        }
    }
    void Animation()
    {
        if (Input.GetAxis("Vertical P2") < 0)
        {
            if (_p2LevelScript.Speed == 0)
            {
                _animatorList[_bodyPlayer2].Play("idle");
            }
            else if (transform.position.z > (_startPosition.z + 3.9f))
            {
                _animatorList[_bodyPlayer2].Play("speed 1 L");
            }
            else
            {
                _animatorList[_bodyPlayer2].Play("speed 1 S");
            }
        }
        if (_p2LevelScript.Speed == 0 && _fireAnimation < Time.time)
        {
            _animatorList[_bodyPlayer2].Play("idle");
        }
        else if (Input.GetAxis("Vertical P2") > 0)
        {
            //Debug.Log(transform.position.z);
            _animatorList[_bodyPlayer2].Play("stop");
            if (_startPosition.z < -3.9f)
            {
                _animatorList[_bodyPlayer2].Play("stop");
            }
            else if (transform.position.z < (_startPosition.z - 4.0f))
            {
                _animatorList[_bodyPlayer2].Play("speed 1 L");
            }
        }

        if (Input.GetButtonDown("Fire2P2"))
        {
            _animatorList[_bodyPlayer2].Play("fire");
            _fireAnimation = Time.time + 1.5f;
        }
        else if (Input.GetAxis("Vertical P2") == 0 && _fireAnimation < Time.time && !_p2LevelScript.SuperWallHit)
        {
            _animatorList[_bodyPlayer2].Play("speed 1 L");
        }
    }
}
