using UnityEngine;
using System.Collections;

public class BankingP1Script : MonoBehaviour {

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
        CameraPosition = GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localRotation;
        //CameraPosition = GameObject.Find("P1 Camera").GetComponent<Camera>().transform.position;
        PlayerPosition = gameObject.transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update () {


        if (GameObject.FindObjectOfType<Player1LevelScript>().LevelStarted)
        {
            //Debug.Log(gameObject.transform.localEulerAngles);
            if (Input.GetAxis("Horizontal P1") > 0.1f)
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
            if (Input.GetAxis("Horizontal P1") < -0.1f)
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
            else if (Input.GetAxis("Horizontal P1") == 0)
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

            //GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localEulerAngles = CameraPosition + moveRot;
            //GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localRotation = new Quaternion(CameraPosition.x,CameraPosition.y+1,CameraPosition.z,0);
            //GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localRotation.SetLookRotation(new Vector3(gameObject.transform.rotation.x,gameObject.transform.rotation.y,gameObject.transform.rotation.z));
            //CameraPosition = GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localEulerAngles;
            //Debug.Log(counter);  
            //if (Input.GetAxis("Horizontal P1") < 0)
            //{
            //    gameObject.transform.localEulerAngles = gameObject.transform.localEulerAngles + new Vector3(gameObject.transform.localEulerAngles.x, gameObject.transform.localEulerAngles.y - 1, gameObject.transform.localEulerAngles.z);
            //}

            // GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localRotation;
            //GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localEulerAngles = GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localEulerAngles + moveRot /10;

            //if (GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localEulerAngles.y < 150)
            //{
            //    GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localEulerAngles = new Vector3(GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localEulerAngles.x, 150, GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localEulerAngles.z);
            //}
            Debug.Log(GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localEulerAngles); 
        }

        //Sync stuff
	}
}
