using UnityEngine;
using System.Collections;

public class Spiral : MonoBehaviour {

    int rndRotation;

	// Use this for initialization
	void Start () {
        do
        {
            rndRotation = Random.Range(-2, 2);
        } while (rndRotation == 0);
        
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(new Vector3(0, 0, rndRotation));
	}
}
