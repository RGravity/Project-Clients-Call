using UnityEngine;
using System.Collections;

public class RaceScipt : MonoBehaviour {


	// Use this for initialization
	void Start () {
        GameObject.FindObjectOfType<RaceScipt>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetAxis("Horizontal") == -1)
        {

        }
	}
}
