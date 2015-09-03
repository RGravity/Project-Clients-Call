using UnityEngine;
using System.Collections;

public class BackButtonScript : MonoBehaviour {

    // Use this for initialization
    private GameObject _camera;
    float timer = 0;
    private bool _rotation = false;
    float degrees = 270;

	void Start () 
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () 
    {
        
        if (_rotation == true)
        {
            Debug.Log(degrees);
            degrees = degrees + 1;
            _camera.transform.rotation = Quaternion.Euler(degrees, 90, 0);


            if (degrees == 360 )
            {
                _rotation = false;
                _camera.transform.rotation = Quaternion.Euler(0, 90, 0);
                degrees = 270;
            }

        }
	
	}

    void OnMouseDown()
    {
        _rotation = true;

    }
}
