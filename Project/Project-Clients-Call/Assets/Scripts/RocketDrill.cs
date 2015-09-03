using UnityEngine;
using System.Collections;

public class RocketDrill : MonoBehaviour {

    private bool _rocketDrillP1 = false;

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
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (_rocketDrillP1)
        {
            GameObject drill = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            Camera camera = GameObject.FindObjectOfType<Player2LevelScript>().GetComponent<Camera>();
            Vector3 position;
            position = camera.transform.position + camera.transform.forward + new Vector3(Random.Range(-2, 2), 1, 30);
            drill.transform.position = position;
        }
        if (_rocketDrillP2)
        {

        }
	
	}
}
