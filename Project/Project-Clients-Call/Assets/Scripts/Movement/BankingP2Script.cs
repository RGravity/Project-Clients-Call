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

	// Use this for initialization
	void Start () {

        //CameraPosition = GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localEulerAngles;
        CameraPosition = GameObject.Find("P2 Camera").GetComponent<Camera>().transform.localRotation;
        //CameraPosition = GameObject.Find("P1 Camera").GetComponent<Camera>().transform.position;
        PlayerPosition = gameObject.transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3 moveRot = Vector3.zero;
        //moveRot.y = -(Input.GetAxis("Horizontal P2") * 12);
        //gameObject.transform.localEulerAngles = PlayerPosition + moveRot * 3;

        //GameObject.Find("P2 Camera").GetComponent<Camera>().transform.localEulerAngles = CameraPosition + moveRot;
        ////Sync stuff

        if (GameObject.FindObjectOfType<Player2LevelScript>().LevelStarted)
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
                //gameObject.transform.localEulerAngles = gameObject.transform.localEulerAngles + new Vector3(gameObject.transform.localEulerAngles.x, gameObject.transform.localEulerAngles.y + 1, gameObject.transform.localEulerAngles.z);
            }
            else if (Input.GetAxis("Horizontal P2") < -0.1f)
            {
                //moveRot.y = -(Input.GetAxis("Horizontal P1") * 12);
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
                //gameObject.transform.localEulerAngles = gameObject.transform.localEulerAngles + new Vector3(gameObject.transform.localEulerAngles.x, gameObject.transform.localEulerAngles.y + 1, gameObject.transform.localEulerAngles.z);

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
                }
                gameObject.transform.localEulerAngles = PlayerPosition - moveRot * 3;
            } 
        }

        //GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localEulerAngles = CameraPosition + moveRot;
        //GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localRotation = new Quaternion(CameraPosition.x,CameraPosition.y+1,CameraPosition.z,0);
        //GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localRotation.SetEulerRotation(gameObject.transform.localEulerAngles);
	}
}
