using UnityEngine;
using System.Collections;

public class BankingP1Script : MonoBehaviour {

    Vector3 CameraPosition;
    Vector3 PlayerPosition;
    Vector3 moveRot = Vector3.zero;

	// Use this for initialization
	void Start () {
        CameraPosition = GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localEulerAngles;
        PlayerPosition = gameObject.transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localEulerAngles = CameraPosition + moveRot;
        moveRot.y = -(Input.GetAxis("Horizontal P1") * 12);
        gameObject.transform.localEulerAngles = PlayerPosition + moveRot * 3;

        Debug.Log(gameObject.transform.localEulerAngles);
        //if (Input.GetAxis("Horizontal P1") > 0)
        //{
        //   gameObject.transform.localEulerAngles = gameObject.transform.localEulerAngles + new Vector3(gameObject.transform.localEulerAngles.x, gameObject.transform.localEulerAngles.y + 1, gameObject.transform.localEulerAngles.z);
        //}
        //if (Input.GetAxis("Horizontal P1") < 0)
        //{
        //    gameObject.transform.localEulerAngles = gameObject.transform.localEulerAngles + new Vector3(gameObject.transform.localEulerAngles.x, gameObject.transform.localEulerAngles.y - 1, gameObject.transform.localEulerAngles.z);
        //}


        //Sync stuff
	}
}
