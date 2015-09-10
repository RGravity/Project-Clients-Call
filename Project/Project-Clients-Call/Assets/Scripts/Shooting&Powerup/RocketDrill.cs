using UnityEngine;
using System.Collections;

public class RocketDrill : MonoBehaviour {

    private bool _rocketDrillP1 = false;
    public GameObject _rocketPrefab;

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
    
	// Use this for initialization
	void Start () {
        _planeP1 = GameObject.FindObjectOfType<Player1LevelScript>().gameObject;
        _planeP2 = GameObject.FindObjectOfType<Player2LevelScript>().gameObject;
	}
	
	// Update is called once per frame
	void Update () {

        if (_rocketDrillP1)
        {
            _rocketDrillP1 = false;
            //GameObject drill = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            GameObject drill = Instantiate(_rocketPrefab);
            Camera camera = GameObject.FindObjectOfType<Player2MoveScript>().GetComponentInChildren<Camera>();
            Vector3 position;
            position = camera.transform.position + camera.transform.forward + new Vector3(0, 1, 2);
            drill.transform.position = position;
            drill.transform.parent = _planeP2.transform;
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
        }
	
	}

   
}
