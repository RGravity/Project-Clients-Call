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


            if (degrees == -45)
            {
                _backButton.gameObject.transform.position = new Vector3(206, 1386, -489);
            
            }

            if (degrees <= -90)
            {
                _rotation = false;
                _camera.transform.rotation = Quaternion.Euler(270, 90, 0);
                degrees = 0;
            }

        }

    }

    void OnMouseDown()
    {
        _rotation = true;

    }
}
