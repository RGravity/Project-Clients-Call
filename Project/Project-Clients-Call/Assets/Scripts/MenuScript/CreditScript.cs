using UnityEngine;
using System.Collections;

public class CreditScript : MonoBehaviour {

    private GameObject _camera;
    private GameObject _backButton;
    private GameObject _creditScreen;
    private bool _rotation = false;
    private float _degrees = 0;
    void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
        _backButton = GameObject.FindGameObjectWithTag("BackButton");
        _creditScreen = GameObject.FindGameObjectWithTag("CreditScreen");
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
               
                _backButton.transform.position = new Vector3(206, 1386, -489);
                _backButton.transform.rotation = Quaternion.Euler(343.9586f, 1.106766f, 84.13269f);
            
            }

            if (_degrees <= -90)
            {
                _creditScreen.transform.position = new Vector3(486, 1326, 0);
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
