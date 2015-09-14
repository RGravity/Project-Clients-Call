using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour {

    private Rigidbody _body;
    private GameObject _planeP1;
    private GameObject _planeP2;
    private bool _isPlayer1 = false;
    private Camera _playerCameraP1;
    private Camera _playerCameraP2;
    private float distance = 30.0f;
    private List<float> spawnPoints = new List<float>(){-4,-2,0,2,4};
    private GameObject _pointBlock;

	// Use this for initialization
	void Start () {
        _body = GetComponent<Rigidbody>();
        _body.position = transform.position;

        _planeP1 = GameObject.FindObjectOfType<Player1LevelScript>().gameObject;
        _planeP2 = GameObject.FindObjectOfType<Player2LevelScript>().gameObject;
        _playerCameraP1 = GameObject.FindObjectOfType<Player1MoveScript>().GetComponentInChildren<Camera>();
        _playerCameraP2 = GameObject.FindObjectOfType<Player2MoveScript>().GetComponentInChildren<Camera>();

        _pointBlock = GameObject.Find("PointBlock");
	}
	
	// Update is called once per frame
	void Update () {
        _body.velocity = new Vector3(0, 0, 40);

	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Cube") || other.gameObject.name.Contains("TrackWall"))
        {
            if (_isPlayer1)
            {
                GameObject otherCube = Instantiate(other.gameObject);
                //Vector3 oldScale = other.gameObject.transform.localScale;
                //Vector3 hitScale = other.GetComponent<BoxCollider>().size;
                //otherCube.GetComponent<BoxCollider>().size = hitScale;
                //otherCube.gameObject.transform.localScale = oldScale;
                Vector3 position;
                Collider[] hit;
                do
                {
                    //position = _playerCameraP2.transform.position + _playerCameraP2.transform.forward + new Vector3(2, 1, 30);
                    position = new Vector3(_pointBlock.transform.position.x + spawnPoints[Random.Range(0,spawnPoints.Count)], _planeP2.transform.position.y-1, _playerCameraP2.transform.forward.z + 30);
                    hit = Physics.OverlapSphere(position, otherCube.transform.localScale.x * 2);
                }
                while (hit.Length == 1);
                //otherCube.transform.localScale = new Vector3(2, 1, 1);
                otherCube.transform.position = position;
                otherCube.transform.rotation = new Quaternion(0.0f, _playerCameraP2.transform.rotation.y, 0.0f, _playerCameraP2.transform.rotation.w);
                //otherCube.transform.position = new Vector3(other.transform.position.x, -other.transform.position.y, other.transform.position.z);
                //otherCube.transform.rotation = new Quaternion(other.transform.rotation.x, 180, other.transform.rotation.z, 1);
                //otherCube.transform.position = new Vector3(100, 100, 100);
                otherCube.transform.parent = _planeP2.transform;
            }
            else if (_isPlayer1 == false)
            {
                GameObject otherCube = Instantiate(other.gameObject);
                Vector3 oldScale = other.gameObject.transform.localScale;
                Vector3 hitScale = other.GetComponent<BoxCollider>().size;
                Vector3 position;
                Collider[] hit;
                do
                {
                    //position = _playerCameraP1.transform.position + _playerCameraP1.transform.forward + new Vector3(0, -1, 30);
                    position = new Vector3(_pointBlock.transform.position.x + spawnPoints[Random.Range(0, spawnPoints.Count)], _planeP2.transform.position.y+0.6f, _playerCameraP2.transform.forward.z + 30);
                    hit = Physics.OverlapSphere(position, otherCube.transform.localScale.x * 2);
                }
                while (hit.Length == 1);
                otherCube.transform.localScale = new Vector3(2, 1, 1);
                otherCube.transform.position = position;
                otherCube.transform.rotation = new Quaternion(0.0f, _playerCameraP1.transform.rotation.y, 0.0f, _playerCameraP1.transform.rotation.w);
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
