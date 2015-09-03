using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {

	// Use this for initialization
    private GameObject _camera;
    float timer = 0;
    private bool _rotation = false;
    float degrees = 0;
	void Start () 
    {
	 _camera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (_rotation == true)
        {
           
                degrees = degrees - 1;
                _camera.transform.rotation = Quaternion.Euler (degrees, 0, 0);


            if (degrees <=-90)
            {
                _rotation = false;
                _camera.transform.rotation = Quaternion.Euler(270, 0, 0);
                degrees = 0;
            }
   
        }
     
	}

    void OnMouseDown()
    {
       _rotation = true;
        
    }
}
