﻿using UnityEngine;
using System.Collections;

public class Windmill : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(0, 0, 0.4f);
	}
}
