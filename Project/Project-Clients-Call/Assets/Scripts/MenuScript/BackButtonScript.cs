using UnityEngine;
using System.Collections;

public class BackButtonScript : MonoBehaviour {

    // Use this for initialization
    private GameObject _camera;
    private GameObject _creditScreen;
    private bool _rotation = false;
    float degrees = 270;

	void Start () 
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
        _creditScreen = GameObject.FindGameObjectWithTag("CreditScreen");
	}
	
	// Update is called once per frame
	void Update () 
    {
        
        if (_rotation == true)
        {
            Debug.Log(degrees);
            degrees = degrees + 1;
            _camera.transform.rotation = Quaternion.Euler(degrees, 90, 0);

            if (degrees == 300)
            {

                _creditScreen.transform.position = new Vector3(0, 1846, 0);
                this.gameObject.transform.position = new Vector3(206, 1846, -489);
            }
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
