using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour {

    private float _speed = 10f;
	
	// Update is called once per frame
	void Update () {
        if (!Input.GetKey(KeyCode.Space))
        {
            _speed += 0.01f;
            gameObject.transform.position = transform.position - (transform.forward * _speed * Time.deltaTime);
        }
	}
}
