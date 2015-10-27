using UnityEngine;
using System.Collections;

public class LetterRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Rotate(0, 1, 0);
	}
}
