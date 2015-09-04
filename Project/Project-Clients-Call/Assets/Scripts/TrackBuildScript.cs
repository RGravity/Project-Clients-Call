using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackBuildScript : MonoBehaviour {

    private GameObject TrackBlock;
    private List<Object> TrackBlocksList;
    private int TrackBlocksCounter;

	// Use this for initialization
	void Start () {
        TrackBlocksCounter = 0;
        TrackBlock = (GameObject)Resources.Load("TrackBlock/TrackBlock");
        SpawnTrackBlock(new Vector3(0, 0, 0));
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    private void SpawnTrackBlock(Vector3 pPosition)
    {
        GameObject GO = (GameObject)Instantiate(TrackBlock, pPosition, Quaternion.identity);
        GO.transform.parent = this.gameObject.transform;
        GO.name = "TrackBlock" + TrackBlocksCounter;
        GO.transform.localEulerAngles = new Vector3(0, 90, 0);
        TrackBlocksCounter++;
    }
}
