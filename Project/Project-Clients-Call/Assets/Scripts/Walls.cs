using UnityEngine;
using System.Collections;

public class Walls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnColissionEnter(Collision other)
    {
        if (other.gameObject.name == "car")
        {
            
        }
        if (other.gameObject.name == "Bullet")
        {
            Destroy(this);
        }
    }
}
