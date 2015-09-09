using UnityEngine;
using System.Collections;

public class BackButtonScript : MonoBehaviour {

    // Use this for initialization
    private GameObject _camera;
    private GameObject _creditScreen;
    private GameObject _controls;
    private GameObject _sounds;

    private bool _rotation = false;
    private bool _rotationOptions = false;
    private float _degrees = 270;

	void Start () 
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
        _creditScreen = GameObject.FindGameObjectWithTag("CreditScreen");
        _controls = GameObject.FindGameObjectWithTag("Controls");
        _sounds = GameObject.FindGameObjectWithTag("Sounds");
	}
	
	// Update is called once per frame
	void Update () 
    {
        
        if (_rotation == true)
        {
            
            _degrees = _degrees + 1;
            _camera.transform.rotation = Quaternion.Euler(_degrees, 90, 0);

            if (_degrees == 300)
            {

                _creditScreen.transform.position = new Vector3(0, 1846, 0);
                _controls.transform.position = new Vector3(81, 1846, 0);
                _sounds.transform.position = new Vector3(-75, 1846, 0);
                this.gameObject.transform.position = new Vector3(206, 1846, -489);
                
            }
            if (_degrees == 360 )
            {
                _rotation = false;
                _camera.transform.rotation = Quaternion.Euler(0, 90, 0);
                _degrees = 270;
            }

            

        }
        if (_rotationOptions == true)
        {
            _degrees = _degrees + 1;
            _camera.transform.rotation = Quaternion.Euler(_degrees, 90, 0);

            if (_degrees == 225)
            {
                _controls.transform.position = new Vector3(81, 1500, 0);
                _sounds.transform.position = new Vector3(-75, 1500, 0);
                this.gameObject.transform.position = new Vector3(206, 1386, -489);
                this.gameObject.transform.rotation = Quaternion.Euler(343.9586f, 1.106766f, 84.13269f);

            }


            if (_degrees == 270)
            {
                _rotationOptions = false;
                _camera.transform.rotation = Quaternion.Euler (270,90,0);
                
            }
        
        }
	
	}

    void OnMouseDown()
    {
        Debug.Log(true);
        if (this.transform.position == new Vector3(206, 1386, -489))
        {
            _rotation = true;

        }
        if (this.transform.position == new Vector3(-1334, 221, -444))
        {
            _rotationOptions = true;
            _degrees = 180;
        }

    }
}
