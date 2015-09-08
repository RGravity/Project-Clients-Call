using UnityEngine;
using System.Collections;

public class BankingP1Script : MonoBehaviour {

    Vector3 CameraPosition;

	// Use this for initialization
	void Start () {
        CameraPosition = GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 moveRot = Vector3.zero;
        moveRot.y = -(Input.GetAxis("Horizontal P1") * 12);
        gameObject.transform.localEulerAngles = moveRot * 3;

        GameObject.Find("P1 Camera").GetComponent<Camera>().transform.localEulerAngles = CameraPosition + moveRot;
        //Sync stuff
	}
}
