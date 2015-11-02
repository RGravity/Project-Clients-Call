using UnityEngine;
using System.Collections;

public class Player1MoveScript : MonoBehaviour {

    private Vector3 _startPosition;
    private Vector3 _startCamera;
    private Animator _animator;
    private Animation _fire;
    private float _fireAnimation = 0;
    private float _maxTrackWidth = 6;
    private bool _moveVertical = false;
    private bool _moveHorizontal = false;

    private Animator[] _animatorList;

	// Use this for initialization
	void Start () {
        _startPosition = transform.position;
        _animator = GetComponentInChildren<Animator>();
        _animatorList = GetComponentsInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindObjectOfType<Player1LevelScript>().LevelStarted)
        {
            Vector3 moveDir = Vector3.zero;
            moveDir.x = Input.GetAxis("Horizontal P1") * 12; // get result of AD keys in X
            moveDir.z = Input.GetAxis("Vertical P1") * 12;
            transform.position += moveDir * Time.deltaTime;

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
            AnimationPlayer();
            PlayerSound();
        }
	}

    void PlayerSound()
    {

        if (Input.GetAxisRaw("Vertical P1") != 0)
        {
            if (_moveVertical == false)
            {
                // Call your event function here.
                _moveVertical = true;
                GameObject.FindGameObjectWithTag("PlayerMovement").GetComponent<AudioSource>().Play();
            }
        }
        if (Input.GetAxisRaw("Vertical P1") == 0)
        {
            _moveVertical = false;
        }

        if (Input.GetAxisRaw("Horizontal P1") != 0)
        {
            if (_moveHorizontal == false)
            {
                // Call your event function here.
                _moveHorizontal  = true;
                GameObject.FindGameObjectWithTag("PlayerMovement").GetComponent<AudioSource>().Play();
            }
        }
        if (Input.GetAxisRaw("Horizontal P1") == 0)
        {
            _moveHorizontal = false;
        }    
    }

    void AnimationPlayer()
    {

       
        //if (Input.GetAxis("Vertical P1") > 0)
        //{
        //    if (GameObject.FindObjectOfType<Player1LevelScript>().Speed == 0)
        //    {
        //        _animator.Play("idle");
        //    }
        //    else if (transform.position.z > (_startPosition.z + 3.9f))
        //    {
        //        _animator.Play("speed 1 L");
        //    }
        //    else
        //    {
        //        _animator.Play("speed 1 S");
        //    }
        //}
        //if (GameObject.FindObjectOfType<Player1LevelScript>().Speed == 0)
        //{
        //    _animator.Play("idle");
        //}
        //else if (Input.GetAxis("Vertical P1") < 0)
        //{
        //    //Debug.Log(transform.position.z);
        //    _animator.Play("stop");
        //    if (_startPosition.z < -3.9f)
        //    {
        //        _animator.Play("stop");
        //    }
        //    else if (transform.position.z < (_startPosition.z - 4.0f))
        //    {
        //        _animator.Play("speed 1 L");
        //    }
        //}

        //if (Input.GetButtonDown("Fire2P1"))
        //{
        //    _animator.Play("fire");
        //    _fireAnimation = Time.time+1.5f;
        //}
        //else if (Input.GetAxis("Vertical P1") == 0 && _fireAnimation < Time.time)
        //{
        //    _animator.Play("speed 1 L");
        //}
        if (GameObject.FindObjectOfType<ConfirmScript>().Tutorial == true)
        {
            if (Input.GetAxis("Vertical P1") > 0)
            {
                if (GameObject.FindObjectOfType<Player1LevelScript>().Speed == 0)
                {
                    _animator.Play("idle");
                }
                else if (transform.position.z > (_startPosition.z + 3.9f))
                {
                    _animator.Play("speed 1 L");
                }
                else
                {
                    _animator.Play("speed 1 S");
                }
            }
            if (GameObject.FindObjectOfType<Player1LevelScript>().Speed == 0)
            {
                _animator.Play("idle");
            }
            else if (Input.GetAxis("Vertical P1") < 0)
            {
                //Debug.Log(transform.position.z);
                _animator.Play("stop");
                if (_startPosition.z < -3.9f)
                {
                    _animator.Play("stop");
                }
                else if (transform.position.z < (_startPosition.z - 4.0f))
                {
                    _animator.Play("speed 1 L");
                }
            }

            if (Input.GetButtonDown("Fire2P1"))
            {
                _animator.Play("fire");
                _fireAnimation = Time.time + 1.5f;
            }
            else if (Input.GetAxis("Vertical P1") == 0 && _fireAnimation < Time.time)
            {
                _animator.Play("speed 1 L");
            }
        }
        else
        {
            if (Input.GetAxis("Vertical P1") > 0)
            {
                if (GameObject.FindObjectOfType<Player1LevelScript>().Speed == 0)
                {
                    _animatorList[GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer1].Play("idle");
                }
                else if (transform.position.z > (_startPosition.z + 3.9f))
                {
                    _animatorList[GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer1].Play("speed 1 L");
                }
                else
                {
                    _animatorList[GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer1].Play("speed 1 S");
                }
            }
            if (GameObject.FindObjectOfType<Player1LevelScript>().Speed == 0)
            {
                _animatorList[GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer1].Play("idle");
            }
            else if (Input.GetAxis("Vertical P1") < 0)
            {
                //Debug.Log(transform.position.z);
                _animatorList[GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer1].Play("stop");
                if (_startPosition.z < -3.9f)
                {
                    _animatorList[GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer1].Play("stop");
                }
                else if (transform.position.z < (_startPosition.z - 4.0f))
                {
                    _animatorList[GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer1].Play("speed 1 L");
                }
            }

            if (Input.GetButtonDown("Fire2P1"))
            {
                _animatorList[GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer1].Play("fire");
                _fireAnimation = Time.time + 1.5f;
               
            }
            else if (Input.GetAxis("Vertical P1") == 0 && _fireAnimation < Time.time)
            {
                _animatorList[GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer1].Play("speed 1 L");
            }
        }
    }
}
