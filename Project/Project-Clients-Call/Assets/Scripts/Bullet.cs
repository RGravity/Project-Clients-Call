using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    private Rigidbody _body;
    private GameObject _plane;
	// Use this for initialization
	void Start () {
        _body = GetComponent<Rigidbody>();
        _body.position = transform.position;

       _plane = GameObject.FindObjectOfType<LevelScript>().gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        _body.velocity = new Vector3(0, 0, 50);
	}
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Cube")
        {
            GameObject otherCube = other.gameObject;// Instantiate(other.gameObject);
            otherCube.transform.position = new Vector3(other.transform.position.x, -other.transform.position.y, other.transform.position.z);
            otherCube.transform.parent = _plane.transform;
            Destroy(other.transform.gameObject);
            Destroy(this.transform.gameObject);
        }
    }

}
