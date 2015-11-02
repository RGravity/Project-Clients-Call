using UnityEngine;
using System.Collections.Generic;
using System;

public class TrackBlockScript : MonoBehaviour {

    private bool _moving = false;
    private Vector3 _localFinalSpot;
    private Vector3 _globalFinalSpot;

    private int _zBlocks;

    public int ZBlocks { set { _zBlocks = value; } }


	// Use this for initialization
	void Start () {
        //resetVisibility();
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

    //void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.name == "Sphere")
    //    {
    //        Renderer[] childsRend = this.gameObject.GetComponentsInChildren<Renderer>();

    //        foreach (Renderer rend in childsRend)
    //        {
    //            rend.enabled = false;
    //        }
    //    }
    //}

    public void OnBecameInvisible()
    {
        if (!_moving)
        {
            _moving = true;

            // -- actual next position on track
            float NextXPositionLocal = this.transform.localPosition.x;
            float NextYPositionLocal = this.transform.localPosition.y;
            float NextZPositionLocal = this.transform.localPosition.z + (_zBlocks * 0.7f);

            //// -- falling 'animation' --
            float NextXPositionGlobal = this.transform.position.x;
            float NextYPositionGlobal = this.transform.position.y;
            float NextZPositionGlobal = this.transform.position.z + (_zBlocks * 0.7f);

            //Final LOCAL position
            _localFinalSpot = new Vector3(NextXPositionLocal, NextYPositionLocal, NextZPositionLocal);

            //Final GLOBAL position
            _globalFinalSpot = new Vector3(NextXPositionGlobal, NextYPositionGlobal, NextZPositionGlobal);

            //set next position in the air
            this.transform.position = new Vector3(NextXPositionGlobal + UnityEngine.Random.Range(-30, 30), NextYPositionGlobal + UnityEngine.Random.Range(-30, 30), NextZPositionGlobal);

            //resetVisibility();



        }
        //this.transform.position = new Vector3(NextXPositionLocal, NextYPositionLocal, NextZPositionLocal);
    }

    private void resetVisibility(){
        Renderer[] childsRend = this.gameObject.GetComponentsInChildren<Renderer>();

        foreach (Renderer rend in childsRend)
        {
            rend.enabled = true;
        }
    }

    public void OnTriggerEnter(Collider player)
    {
        if (player.GetComponent<Player1LevelScript>())
        {
            player.GetComponent<Player1LevelScript>().Speed = 2;
        }
        else if (player.GetComponent<Player2LevelScript>())
        {
            player.GetComponent<Player2LevelScript>().Speed = 2;
        }
    }
}
