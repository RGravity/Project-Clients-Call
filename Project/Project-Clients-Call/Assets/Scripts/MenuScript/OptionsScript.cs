using UnityEngine;
using System.Collections;

public class OptionsScript : MonoBehaviour {

    private GameObject _camera;
    private GameObject _backButton;
    private GameObject _controls;
    private GameObject _sounds;
    private bool _rotation = false;
    private float _degrees = 0;
    void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
        _backButton = GameObject.FindGameObjectWithTag("BackButton");
        _controls = GameObject.FindGameObjectWithTag("Controls");
        _sounds = GameObject.FindGameObjectWithTag("Sounds");
    }

    // Update is called once per frame
    void Update()
    {
        if (_rotation == true)
        {

            _degrees = _degrees - 1;
            _camera.transform.rotation = Quaternion.Euler(_degrees, 90, 0);

            if (_degrees == -45)
            {
                _controls.transform.position = new Vector3(81, 1500, 0);
                _sounds.transform.position = new Vector3(-75, 1500, 0);
                _backButton.transform.position = new Vector3(206, 1386, -489);
                _backButton.transform.rotation = Quaternion.Euler(343.9586f, 1.106766f, 84.13269f);


            }

            if (_degrees <= -90)
            {
                _rotation = false;
                _camera.transform.rotation = Quaternion.Euler(270, 90, 0);
                _degrees = 0;
            }

        }

    }

    void OnMouseDown()
    {
        _rotation = true;

    }
}
