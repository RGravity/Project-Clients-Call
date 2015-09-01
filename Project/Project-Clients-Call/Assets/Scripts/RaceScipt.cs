using UnityEngine;
using System.Collections;

public class RaceScipt : MonoBehaviour {


    public GameObject Bullet;
	// Use this for initialization
	void Start () {
        GameObject.FindObjectOfType<RaceScipt>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(Bullet);
        }
	}
}
