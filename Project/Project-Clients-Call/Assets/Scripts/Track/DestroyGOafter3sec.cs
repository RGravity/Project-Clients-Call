using UnityEngine;
using System.Collections;
using System;

public class DestroyGOafter3sec : MonoBehaviour {

    private DateTime time;
	// Use this for initialization
	void Start () {
        time = DateTime.UtcNow;
	}
	
	// Update is called once per frame
	void Update () {
        if (time.AddSeconds(3) < DateTime.UtcNow)
        {
            Destroy(this.gameObject);
        }
	}
}
