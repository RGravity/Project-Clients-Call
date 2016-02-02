using UnityEngine;
using System.Collections;

public class BankingP2Script : MonoBehaviour {

    //Vector3 CameraPosition;
    Quaternion CameraPosition;
    //Vector3 CameraPosition;
    Vector3 PlayerPosition;
    Vector3 moveRot = Vector3.zero;
    float timer = 0;
    float counter = 0;
    Vector3 trackback = Vector3.zero;
    float trackbackCount = 0;

    private GameObject _camera;
    private Player2LevelScript _player2LevelScript;

	// Use this for initialization
	void Start () {
        CameraPosition = GameObject.Find("P2 Camera").GetComponent<Camera>().transform.localRotation;
        PlayerPosition = gameObject.transform.localEulerAngles;

        _camera = GameObject.Find("P2 Camera");
        _player2LevelScript = GameObject.FindObjectOfType<Player2LevelScript>();

    }
	
	// Update is called once per frame
	void Update () {;
        ////Sync stuff

        if (_player2LevelScript.LevelStarted)
        {
            if (Input.GetAxis("Horizontal P2") > 0.1f)
            {
                //moveRot.y = -(Input.GetAxis("Horizontal P1") * 12);
                moveRot.y = -counter;
                if (Time.time > (timer + 0.01f))
                {
                    timer = Time.time;
                    if (counter >= 12)
                    {
                        counter = 12;
                    }
                    else
                    {
                        counter++;
                    }
                }
                gameObject.transform.localEulerAngles = PlayerPosition + moveRot * 3;
                _camera.GetComponent<Camera>().transform.localEulerAngles = _camera.GetComponent<Camera>().transform.localEulerAngles + moveRot / 5;

            }
            if (Input.GetAxis("Horizontal P2") < -0.1f)
            {
                moveRot.y = counter;
                if (Time.time > (timer + 0.01f))
                {
                    timer = Time.time;
                    if (counter <= -12)
                    {
                        counter = -12;
                    }
                    else
                    {
                        counter--;
                    }
                }
                gameObject.transform.localEulerAngles = PlayerPosition - moveRot * 3;

                _camera.GetComponent<Camera>().transform.localEulerAngles = _camera.GetComponent<Camera>().transform.localEulerAngles - moveRot / 5;

            }
            else if (Input.GetAxis("Horizontal P2") == 0)
            {
                moveRot.y = counter;
                if (Time.time > (timer + 0.01f))
                {
                    timer = Time.time;
                    if (counter > 0)
                    {
                        counter--;
                    }
                    if (counter < 0)
                    {
                        counter++;
                    }
                    if (counter == 0)
                    {
                        counter = 0;
                    }

                    if (_camera.GetComponent<Camera>().transform.localEulerAngles.y > 180)
                    {
                        trackback.y = -5;
                        _camera.GetComponent<Camera>().transform.localEulerAngles = _camera.GetComponent<Camera>().transform.localEulerAngles + trackback / 5;
                    }
                    if (_camera.GetComponent<Camera>().transform.localEulerAngles.y < 181)
                    {
                        trackback.y = 5;
                        _camera.GetComponent<Camera>().transform.localEulerAngles = _camera.GetComponent<Camera>().transform.localEulerAngles + trackback / 5;
                    }

                }
                gameObject.transform.localEulerAngles = PlayerPosition - moveRot * 3;

            }
            if (_camera.GetComponent<Camera>().transform.localEulerAngles.y > 195)
            {
                _camera.GetComponent<Camera>().transform.localEulerAngles = _camera.GetComponent<Camera>().transform.localEulerAngles = new Vector3(GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localEulerAngles.x, 195, GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localEulerAngles.z); //+ moveRot;
            }
            if (_camera.GetComponent<Camera>().transform.localEulerAngles.y < 165)
            {
                _camera.GetComponent<Camera>().transform.localEulerAngles = _camera.GetComponent<Camera>().transform.localEulerAngles = new Vector3(GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localEulerAngles.x, 165, GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localEulerAngles.z); //+ moveRot;
            }
        }
	}
}
