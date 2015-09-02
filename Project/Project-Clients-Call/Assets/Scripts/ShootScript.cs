using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {

    public GameObject bullet;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            bullet.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 1);
            Instantiate(bullet).GetComponent<Transform>();
        }
	}
}
