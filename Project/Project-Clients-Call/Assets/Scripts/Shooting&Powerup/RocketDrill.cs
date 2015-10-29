using UnityEngine;
using System.Collections;

public class RocketDrill : MonoBehaviour {

    private bool _rocketDrillP1 = false;
    public GameObject _rocketPrefab;
    [SerializeField]
    private GameObject _portal;
    [SerializeField]
    private GameObject _bulletPrefab;

    public bool RocketDrillP1
    {
        get { return _rocketDrillP1; }
        set { _rocketDrillP1 = value; }
    }

    private bool _rocketDrillP2 = false;

    public bool RocketDrillP2
    {
        get { return _rocketDrillP2; }
          set { _rocketDrillP2 = value; }
    }
    private GameObject _planeP1;
    private GameObject _planeP2;
    private GameObject _PlayerP1;
    private GameObject _PlayerP2;
    
	// Use this for initialization
	void Start () {
        if (GameObject.FindObjectOfType<ConfirmScript>().Tutorial == false)
        {
            _planeP1 = GameObject.FindObjectOfType<Player1LevelScript>().gameObject;
            _planeP2 = GameObject.FindObjectOfType<Player2LevelScript>().gameObject;
            _PlayerP1 = GameObject.FindObjectOfType<Player1MoveScript>().gameObject;
            _PlayerP2 = GameObject.FindObjectOfType<Player2MoveScript>().gameObject;
        }
        else
        {
            _planeP1 = GameObject.FindObjectOfType<Player1LevelScript>().gameObject;
            _PlayerP1 = GameObject.FindObjectOfType<Player1MoveScript>().gameObject;
        
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (_rocketDrillP1)
        {
            if (GameObject.FindObjectOfType<ConfirmScript>().Tutorial == false)
            {
            _rocketDrillP1 = false;
            //GameObject drill = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            GameObject drill = Instantiate(_rocketPrefab);

            Camera camera = GameObject.FindObjectOfType<Player2MoveScript>().GetComponentInChildren<Camera>();
            Vector3 position;
            position = camera.transform.position + camera.transform.forward + new Vector3(0, 1, 2);
            drill.transform.position = position;
            drill.transform.parent = _planeP2.transform;

           // _portal.gameObject.transform.position = camera.transform.position + camera.transform.forward + new Vector3(0, 6f, 10);

            //_bulletPrefab.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 3);
            //Instantiate(_bulletPrefab).GetComponent<Transform>();
            Vector3 fireWallPos = _PlayerP2.transform.position;
            _portal = (GameObject)Instantiate(_portal,fireWallPos, Quaternion.identity);
            _portal.transform.localEulerAngles = new Vector3(90, 0, 0);
            //_portal.transform.localEulerAngles = new Vector3(0, 90, 0);
            _portal.GetComponent<ParticleSystem>().Play();
            _portal.GetComponent<ParticleSystem>().loop = false;
            }
            else 
            {
            
            }
        }
        if (_rocketDrillP2)
        {
            _rocketDrillP2 = false;
            //GameObject drill = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            GameObject drill = Instantiate(_rocketPrefab);
            Camera camera = GameObject.FindObjectOfType<Player1MoveScript>().GetComponentInChildren<Camera>();
            Vector3 position;
            position = camera.transform.position + camera.transform.forward + new Vector3(0, -1, 2);
            drill.transform.position = position;
            drill.transform.parent = _planeP1.transform;

            //_portal.gameObject.transform.position = camera.transform.position + camera.transform.forward + new Vector3(0, -6f, 10);
            _portal.gameObject.transform.localRotation = new Quaternion(90, _portal.gameObject.transform.rotation.y, _portal.gameObject.transform.rotation.z, _portal.gameObject.transform.rotation.w);

            //_bulletPrefab.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 3);
            //Instantiate(_bulletPrefab).GetComponent<Transform>();
            Vector3 fireWallPos = _PlayerP1.transform.position;
            _portal = (GameObject)Instantiate(_portal, fireWallPos, Quaternion.identity);
            _portal.transform.localEulerAngles = new Vector3(270, 0, 0);
            _portal.GetComponent<ParticleSystem>().Play();
            _portal.GetComponent<ParticleSystem>().loop = false;
        }
	
	}

   
}
