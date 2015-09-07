using UnityEngine;
using System.Collections;

public class StartGameScript : MonoBehaviour {

//    private GameObject _camera;
//    private bool _rotation = false;
//   float degrees = 0;
//    void Start()
//    {
//        _camera = GameObject.FindGameObjectWithTag("MainCamera");
//    }

    // Update is called once per frame
    void Update()
    {
        //if (_rotation == true)
        //{

        //    degrees = degrees - 1;
        //    _camera.transform.rotation = Quaternion.Euler(degrees, 90, 0);


        //    if (degrees <= -90)
        //    {
        //        _rotation = false;
        //        _camera.transform.rotation = Quaternion.Euler(270, 90, 0);
        //        degrees = 0;
        //    }

        //}

    }

    void OnMouseDown()
    {
        Application.LoadLevel(1);
    }
}
