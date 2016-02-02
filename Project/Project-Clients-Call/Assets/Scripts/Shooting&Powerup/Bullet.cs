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
    //private List<float> spawnPoints = new List<float>(){-4,-2,0,2,4};
    private List<float> spawnPoints = new List<float>(){7.4f,5.4f,3.4f,1.4f,-0.6f,-2.6f,-4.6f};
    private GameObject _pointBlock;
    private float shootingWallTimer = 0;
    private float shootingWallCount = 0;
    private GameObject otherCube;
    private GameObject hitted;

    public bool IsPlayer1 { get { return _isPlayer1; } }

	// Use this for initialization
	void Start () {
        _body = GetComponent<Rigidbody>();
        _body.position = transform.position;

        if (GameObject.FindObjectOfType<ConfirmScript>().Tutorial == false)
        {
            _planeP1 = GameObject.FindObjectOfType<Player1LevelScript>().gameObject;
            _planeP2 = GameObject.FindObjectOfType<Player2LevelScript>().gameObject;
            _playerCameraP1 = GameObject.FindObjectOfType<Player1MoveScript>().GetComponentInChildren<Camera>();
            _playerCameraP2 = GameObject.FindObjectOfType<Player2MoveScript>().GetComponentInChildren<Camera>();
        }
        else
        {
            _planeP1 = GameObject.FindObjectOfType<Player1LevelScript>().gameObject;
            _playerCameraP1 = GameObject.FindObjectOfType<Player1MoveScript>().GetComponentInChildren<Camera>();
        }
       

        _pointBlock = GameObject.Find("PointBlock");
	}
	
	// Update is called once per frame
	void Update () 
    {
        _body.velocity = new Vector3(0, 0, 40);
        //WallAnimation();
    }

    void WallAnimation()
    {
        //if (hitted != null)
        //{
        //    if (Time.time > (shootingWallTimer + 1f))
        //    {
        //        shootingWallTimer = Time.time;
        //        shootingWallCount++;
        //    }
        //    if (hitted.gameObject.GetComponent<MeshRenderer>().enabled == true)
        //    {
        //        hitted.gameObject.GetComponent<MeshRenderer>().enabled = false;
        //    }
        //    else if (hitted.gameObject.GetComponent<MeshRenderer>().enabled == false)
        //    {
        //        hitted.gameObject.GetComponent<MeshRenderer>().enabled = true;
        //    }
        //    else
        //    {
        //        //shootingWallCount = 0;
        //    }

        //}
        //if (otherCube != null)
        //{
        //    if (Time.time > (shootingWallTimer + 1f))
        //    {
        //        shootingWallTimer = Time.time;
        //        shootingWallCount++;
        //    }
        //    if (otherCube.gameObject.GetComponent<MeshRenderer>().enabled == true)
        //    {
        //        otherCube.gameObject.GetComponent<MeshRenderer>().enabled = false;
        //    }
        //    else if (otherCube.gameObject.GetComponent<MeshRenderer>().enabled == false)
        //    {
        //        otherCube.gameObject.GetComponent<MeshRenderer>().enabled = true;
        //    }
        //    else
        //    {
        //        //shootingWallCount = 0;
        //    }
        //}
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Cube") || other.gameObject.name.Contains("Wall"))
        {
            if (_isPlayer1)
            {
                hitted = other.gameObject;
                //WallAnimation();
                Vector3 position;
                Collider[] hit;
                do
                {
                    //position = _playerCameraP2.transform.position + _playerCameraP2.transform.forward + new Vector3(2, 1, 30);
                    position = new Vector3(spawnPoints[Random.Range(0,spawnPoints.Count)], other.gameObject.transform.localPosition.y - 3.9f, other.gameObject.transform.localPosition.z);
                    otherCube = (GameObject)Instantiate(other.gameObject, position, Quaternion.identity);
                    hit = Physics.OverlapSphere(position, otherCube.transform.localScale.x * 2);
                }
                while (hit.Length == 1);

                //otherCube.gameObject.transform.localPosition = other.gameObject.transform.localPosition;
                //otherCube.gameObject.transform.localPosition = new Vector3(other.gameObject.transform.localPosition.x, other.gameObject.transform.localPosition.y - 6, other.gameObject.transform.localPosition.z);
                //otherCube.transform.localEulerAngles = new Vector3(0, 90, 0);
                if (GameObject.FindObjectOfType<ConfirmScript>().Tutorial == false)
                {
                Vector3 oldScale = other.gameObject.transform.localScale;
                Vector3 hitScale = other.GetComponent<BoxCollider>().size;

                //otherCube.transform.localScale = new Vector3(2, 1, 1);
                
                    otherCube.transform.position = position;
                    otherCube.transform.rotation = new Quaternion(0.0f, _playerCameraP2.transform.rotation.y, 0.0f, _playerCameraP2.transform.rotation.w);
                    //otherCube.transform.position = new Vector3(other.transform.position.x, -other.transform.position.y, other.transform.position.z);
                    //otherCube.transform.rotation = new Quaternion(other.transform.rotation.x, 180, other.transform.rotation.z, 1);
                    //otherCube.transform.position = new Vector3(100, 100, 100);
                    otherCube.transform.parent = GameObject.Find("TrackBlocks2").gameObject.transform;
                    otherCube.transform.localEulerAngles = new Vector3(0, 90, 0);
                    //                    other.gameObject.GetComponent<Finish>().WallAnimation(true);

                    GameObject newWallParticleObject = otherCube.GetComponent<CollisionScript>().DisappearWall;
                    newWallParticleObject.GetComponent<ParticleSystem>().gravityModifier = 1.44f;
                    GameObject GO = (GameObject)Instantiate(newWallParticleObject, otherCube.transform.position, Quaternion.identity);
                    other.GetComponent<TrackBlockScript>().OnBecameInvisible();
                    //GameObject.FindObjectOfType<TrackBlockScript>().OnBecameInvisible();
                }
                else
                {
                    Destroy(other.gameObject);
                }
               // WallAnimation();

               
            }
            else if (_isPlayer1 == false)
            {
                //GameObject otherCube = Instantiate(other.gameObject);
               // otherCube.gameObject.transform.localPosition = other.gameObject.transform.localPosition;
                //other.gameObject.transform.localPosition = new Vector3(other.gameObject.transform.localPosition.x, other.gameObject.transform.localPosition.y + 6, other.gameObject.transform.localPosition.z);
                //Vector3 oldScale = other.gameObject.transform.localScale;
                //Vector3 hitScale = other.GetComponent<BoxCollider>().size;

                //WallAnimation();
                hitted = other.gameObject;
                Vector3 position;
                Collider[] hit;
                do
                {
                    //position = _playerCameraP1.transform.position + _playerCameraP1.transform.forward + new Vector3(0, -1, 30);
                    position = new Vector3(spawnPoints[Random.Range(0, spawnPoints.Count)], other.gameObject.transform.localPosition.y + 3.6f, other.gameObject.transform.localPosition.z);
                    otherCube = (GameObject)Instantiate(other.gameObject, position, Quaternion.identity);
                    hit = Physics.OverlapSphere(position, otherCube.transform.localScale.x * 2);
                }
                while (hit.Length == 1);
                //otherCube.transform.localScale = new Vector3(2, 1, 1);
                otherCube.transform.position = position;
                otherCube.transform.rotation = new Quaternion(0.0f, _playerCameraP1.transform.rotation.y, 0.0f, _playerCameraP1.transform.rotation.w);
                //otherCube.transform.position = new Vector3(other.transform.position.x, -other.transform.position.y, other.transform.position.z);
                otherCube.transform.parent = GameObject.Find("TrackBlocks1").gameObject.transform;
                otherCube.transform.localEulerAngles = new Vector3(0, 90, 0);
                //other.gameObject.GetComponent<Finish>().WallAnimation(true);

                GameObject newWallParticleObject = otherCube.GetComponent<CollisionScript>().DisappearWall;
                newWallParticleObject.GetComponent<ParticleSystem>().gravityModifier = -1.44f;
                Instantiate(newWallParticleObject, otherCube.transform.position, Quaternion.identity);
                other.GetComponent<TrackBlockScript>().OnBecameInvisible();
                //WallAnimation();
            }
            //GameObject otherCube = Instantiate(other.gameObject);
            //otherCube.transform.position = new Vector3(other.transform.position.x, -other.transform.position.y, other.transform.position.z);
            //otherCube.transform.parent = _plane.transform;

            //Destroy(other.transform.gameObject);
            Destroy(this.transform.gameObject);
        }
        if (other.gameObject.name.Contains("Particle System"))
        {
            Destroy(this);
            Destroy(other.gameObject);
        }
    }

    public void Player (bool isPlayer1)
    {
        _isPlayer1 = isPlayer1;
        //Debug.Log(isPlayer1);
    }

}
