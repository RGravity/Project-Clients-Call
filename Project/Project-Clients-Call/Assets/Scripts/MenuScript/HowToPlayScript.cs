using UnityEngine;
using System.Collections;

public class HowToPlayScript : MonoBehaviour {

    private GameObject _camera;
    private GameObject _backButton;
    private bool _rotation = false;
    float degrees = 0;
    void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
        _backButton = GameObject.FindGameObjectWithTag("BackButton");
    }

    // Update is called once per frame
    void Update()
    {
        if (_rotation == true)
        {

            degrees = degrees - 1;
           
            _camera.transform.rotation = Quaternion.Euler(degrees, 90, 0);
            //_backButton.transform.position = new Vector3(1223.6f, 1489.6f, -229.8f);
          
            

            if (degrees <= -90)
            {
                _rotation = false;
                _camera.transform.rotation = Quaternion.Euler(270, 90, 0);
              //  _backButton.transform.position = new Vector3(213.6f, 1434, -220);
                degrees = 0;
            }

        }

    }

    void OnMouseDown()
    {
        _rotation = true;

    }
}
