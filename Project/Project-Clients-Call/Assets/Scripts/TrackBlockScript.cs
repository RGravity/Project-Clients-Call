using UnityEngine;
using System.Collections;

public class TrackBlockScript : MonoBehaviour {

    private bool _moving = false;
    private Vector3 _finalSpot;


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (_moving)
        {
            Vector3 Distance = this.transform.position - _finalSpot;
            Distance.Normalize();
            this.transform.position -= (Distance * Time.deltaTime);
            if (Distance.magnitude < 1)
            {
                _moving = false;
                this.transform.position = _finalSpot;
            }
        }
        
	}


    public void OnBecameInvisible()
    {
        if (!_moving)
        {
            Vector3 position = this.transform.position;
            int ZBlocks = GameObject.FindObjectOfType<TrackBuildScript>().FirstBlocksZCoords;
            //_finalSpot = new Vector3(position.x, position.y, position.z + (ZBlocks * 3.65f));
            //this.transform.position = new Vector3(position.x, position.y + Random.Range(10, 30), position.z + (ZBlocks * 3.65f));
            this.transform.position = new Vector3(position.x, position.y, position.z + (ZBlocks * 0.7f));
            _moving = true;
        }
        
    }
}
