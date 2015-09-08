using UnityEngine;
using System.Collections;

public class TrackBlockScript : MonoBehaviour {

    private bool _moving = false;
    private Vector3 _localFinalSpot;
    private Vector3 _globalFinalSpot;


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (_moving)
        {
            Vector3 Distance = this.transform.position - _globalFinalSpot;
            Vector3 NormalizedDistance = Distance;
            NormalizedDistance.Normalize();
            this.transform.position -= (NormalizedDistance * 2);
            if (Distance.magnitude < 1)
            {
                _moving = false;
                this.transform.localPosition = _localFinalSpot;
            }
        }
        
	}


    public void OnBecameInvisible()
    {
        if (!_moving)
        {
            Vector3 LocalPosition = this.transform.localPosition;
            Vector3 GlobalPosition = this.transform.position;

            int ZBlocks = GameObject.FindObjectOfType<TrackBuildScript>().FirstBlocks;

            //Final LOCAL position
            _localFinalSpot = new Vector3(LocalPosition.x, LocalPosition.y, LocalPosition.z + (ZBlocks * 0.7f));

            //Final GLOBAL position
            _globalFinalSpot = new Vector3(GlobalPosition.x, GlobalPosition.y, GlobalPosition.z + (ZBlocks * 0.7f));

            //set next position in the air
            this.transform.position = new Vector3(GlobalPosition.x + Random.Range(-30, 30), GlobalPosition.y + Random.Range(-30, 30), GlobalPosition.z + (ZBlocks * 0.7f));

            _moving = true;

            // ----- Set next position directly -----
            //this.transform.position = new Vector3(position.x, position.y, position.z + (ZBlocks * 0.7f));

            
        }
        
    }
}
