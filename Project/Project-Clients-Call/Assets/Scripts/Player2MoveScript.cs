﻿using UnityEngine;
using System.Collections;

public class Player2MoveScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 moveDir = Vector3.zero;
        moveDir.x = Input.GetAxis("Horizontal P2") * 4; // get result of AD keys in X
        transform.position -= moveDir * Time.deltaTime;
	}
}
