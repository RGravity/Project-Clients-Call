using UnityEngine;
using System.Collections;

public class BankingP2Script : MonoBehaviour {

    Vector3 CameraPosition;
    Vector3 PlayerPosition;

	// Use this for initialization
	void Start () {
        CameraPosition = GameObject.Find("P2 Camera").GetComponent<Camera>().transform.localEulerAngles;
        PlayerPosition = transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 moveRot = Vector3.zero;
        moveRot.y = -(Input.GetAxis("Horizontal P2") * 12);
        gameObject.transform.localEulerAngles = PlayerPosition + moveRot * 3;

        GameObject.Find("P2 Camera").GetComponent<Camera>().transform.localEulerAngles = CameraPosition + moveRot;
        //Sync stuff
	}
}
