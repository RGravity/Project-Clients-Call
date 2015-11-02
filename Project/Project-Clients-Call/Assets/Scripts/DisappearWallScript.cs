using UnityEngine;
using System.Collections;

public class DisappearWallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!this.GetComponent<ParticleSystem>().isPlaying)
        {
            Destroy(this.gameObject);
        }
	}
}
