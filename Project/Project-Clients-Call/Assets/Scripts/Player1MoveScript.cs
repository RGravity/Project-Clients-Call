using UnityEngine;
using System.Collections;

public class Player1MoveScript : MonoBehaviour {

    private Vector3 _startPosition;
    private Vector3 _startCamera;
    private Animator _animator;

	// Use this for initialization
	void Start () {
        _startPosition = transform.position;
        _animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 moveDir = Vector3.zero;
        moveDir.x = Input.GetAxis("Horizontal P1") * 12; // get result of AD keys in X
        moveDir.z = Input.GetAxis("Vertical P1") * 12;
        transform.position += moveDir * Time.deltaTime;

        if (transform.position.x > (_startPosition.x + 4f))
        {
            Vector3 newPos = new Vector3(0, 0, 0);
            newPos.x = _startPosition.x + 4f;
            newPos.y = transform.position.y;
            newPos.z = transform.position.z;
            transform.position = newPos;
        }
        else if (transform.position.x < (_startPosition.x - 4))
        {
            Vector3 newPos = new Vector3(0, 0, 0);
            newPos.x = _startPosition.x - 4f;
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
	}

    void Animation()
    {

    }
}
