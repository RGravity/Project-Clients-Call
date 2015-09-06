using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackBuildScript : MonoBehaviour {

    private GameObject _trackBlock;
    private List<Object> _trackBlocksList;
    private int _trackBlocksCounter;

    private int _firstBlocksZCoords = 20;
    private int _zCounter = 0;
    public int FirstBlocksZCoords { get { return _firstBlocksZCoords; } }

	// Use this for initialization
	void Start () {
        _trackBlocksCounter = 0;
        _trackBlock = (GameObject)Resources.Load("TrackBlock/TrackBlock");
        
        //spawn the first 100 blocks far
        for (int z = 0; z < _firstBlocksZCoords; z++)
        {
            //spawn the 5 blocks wide
            for (int x = 0; x < 5; x++)
            {
                
                SpawnTrackBlock(new Vector3((x * 2) - 4.25f, 0, (z * 3.65f)+2));
            }
            _zCounter++;
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    private void SpawnTrackBlock(Vector3 pPosition)
    {
        //instantiate the actual block
        GameObject GO = (GameObject)Instantiate(_trackBlock, pPosition, Quaternion.identity);
        //change the parent of the block
        GO.transform.parent = this.gameObject.transform;
        //change the name of the block + the unique number of the block
        GO.name = "TrackBlock" + _trackBlocksCounter;
        //rotate the block 90 degrees
        GO.transform.localEulerAngles = new Vector3(0, 90, 0);
        //increase the unique number counter
        _trackBlocksCounter++;
    }
}
