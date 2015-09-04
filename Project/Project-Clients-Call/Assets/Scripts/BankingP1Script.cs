using UnityEngine;
using System.Collections;

public class BankingP1Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 moveRot = Vector3.zero;
        moveRot.y = -(Input.GetAxis("Horizontal P1") * 12);
        gameObject.transform.localEulerAngles = moveRot * 3;
	}
}
