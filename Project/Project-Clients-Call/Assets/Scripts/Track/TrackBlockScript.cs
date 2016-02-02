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

	}

    public void OnBecameInvisible()
    {
        float NextXPositionLocal = this.transform.localPosition.x;
        float NextYPositionLocal = this.transform.localPosition.y;
        float NextZPositionLocal = this.transform.localPosition.z + (_zBlocks * 0.7f);
        this.transform.localPosition = new Vector3(NextXPositionLocal, NextYPositionLocal, NextZPositionLocal);
    }

    
}
