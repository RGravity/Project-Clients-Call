using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private Rigidbody _body;
    private GameObject _planeP1;
    private GameObject _planeP2;
    private bool _isPlayer1 = false;
    private Camera _playerCameraP1;
    private Camera _playerCameraP2;
    private float distance = 1.0f;

	// Use this for initialization
	void Start () {
        _body = GetComponent<Rigidbody>();
        _body.position = transform.position;

        _planeP1 = GameObject.FindObjectOfType<Player1LevelScript>().gameObject;
        _planeP2 = GameObject.FindObjectOfType<Player2LevelScript>().gameObject;
        _playerCameraP1 = GameObject.FindObjectOfType<Player1MoveScript>().GetComponentInChildren<Camera>();
        _playerCameraP2 = GameObject.FindObjectOfType<Player2MoveScript>().GetComponentInChildren<Camera>();

	}
	
	// Update is called once per frame
	void Update () {
        _body.velocity = new Vector3(0, 0, 50);

	}
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("Cube"))
        {
            if (_isPlayer1)
            {
                GameObject otherCube = Instantiate(other.gameObject);
                otherCube.transform.position = _playerCameraP2.transform.position + _playerCameraP2.transform.forward * distance;
                otherCube.transform.rotation = new Quaternion(0.0f, _playerCameraP2.transform.rotation.y, 0.0f, _playerCameraP2.transform.rotation.w);
                //otherCube.transform.position = new Vector3(other.transform.position.x, -other.transform.position.y, other.transform.position.z);
                //otherCube.transform.rotation = new Quaternion(other.transform.rotation.x, 180, other.transform.rotation.z, 1);
                //otherCube.transform.position = new Vector3(100, 100, 100);
                //otherCube.transform.parent = _planeP2.transform;
            }
            else if (_isPlayer1 == false)
            {
                GameObject otherCube = Instantiate(other.gameObject);
                //otherCube.transform.position = new Vector3(other.transform.position.x, -other.transform.position.y, other.transform.position.z);
                otherCube.transform.parent = _planeP1.transform;
            }
            //GameObject otherCube = Instantiate(other.gameObject);
            //otherCube.transform.position = new Vector3(other.transform.position.x, -other.transform.position.y, other.transform.position.z);
            //otherCube.transform.parent = _plane.transform;

            Destroy(other.transform.gameObject);
            Destroy(this.transform.gameObject);
        }
    }

    public void Player (bool isPlayer1)
    {
        _isPlayer1 = isPlayer1;
        Debug.Log(isPlayer1);
    }

}
