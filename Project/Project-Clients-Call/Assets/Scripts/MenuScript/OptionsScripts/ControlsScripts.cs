using UnityEngine;
using System.Collections;

public class ControlsScripts : MonoBehaviour {

    private GameObject _camera;
    private GameObject _backButton;
    private bool _rotation = false;
    private float _degrees = 270;
	// Use this for initialization
	void Start () 
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
        _backButton = GameObject.FindGameObjectWithTag("BackButton");
	}
	
	// Update is called once per frame
	void Update () 
    {

        if (_rotation == true)
        {
            _degrees = _degrees - 1;
            _camera.transform.rotation = Quaternion.Euler(_degrees, 90, 0);

            if (_degrees == 225)
            {
                _backButton.transform.position = new Vector3(-1334, 221, -444);
                _backButton.transform.rotation = Quaternion.Euler(358.1851f, 344.3429f, 173.8438f);
            }

            if (_degrees == 180)
            {
                _rotation = false;
                _camera.transform.rotation = Quaternion.Euler(180, 90, 0);
                _degrees = 270;
            }
        }
	
	}

    void OnMouseDown()
    {
        _rotation = true;

    }
}
