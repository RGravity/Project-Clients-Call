using UnityEngine;
using System.Collections;

public class RotationScript : MonoBehaviour {

   
	// Update is called once per frame
	void Update () 
    {
        this.gameObject.transform.Rotate (0,20*Time.deltaTime,0);
	
	}
}
