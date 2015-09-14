using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackBuildScript : MonoBehaviour {

    /*
     * 0 - straight     - 1  blocks long
     * 1 - curve right  - 20 blocks long
     * 2 - curve left   - 20 blocks long
     * 3 - slope up     - 10 blocks long
     * 4 - slope down   - 10 blocks long
     * 
     * after these numbers is the x-position located where these begin
     */

    private List<GameObject> TrackBlockList = new List<GameObject>();

    private GameObject _trackBlock;
    private GameObject _trackWall;
    private GameObject _trackBarrier;
    private int _trackBlocksCounter;
    private int _trackWallsCounter;
    private int _trackBarrierCounter;
    private int _wallCounter;

    [SerializeField]
    private int _firstBlocks = 500;
    public int FirstBlocks { get { return _firstBlocks; } }

	// Use this for initialization
	void Start () {

        _trackBlocksCounter = 0;
        _trackWallsCounter = 0;
        _trackBarrierCounter = 0;
        _trackBlock = (GameObject)Resources.Load("TrackBlock/TrackBlock");
        _trackWall = (GameObject)Resources.Load("TrackBlock/TrackWall");
        _trackBarrier = (GameObject)Resources.Load("TrackBlock/TrackBarrier");
        
        
        //spawn the first XXX blocks far
        for (int z = 0; z < _firstBlocks; z++)
        {
            if (z % 10 == 0 && z != 0)
            {
                SpawnWallsOnZ(z);
            }
            //spawn the XXX blocks wide
            for (int x = 0; x < 10; x++)
            {
                if (z % 33 == 0)
                {
                    if (x == 0 || x == 9)
                    {
                        SpawnTrackBarrier(new Vector3((x * 2) - 4.25f, -0.1f, (z * 0.7f)));
                        SpawnTrackBarrier(new Vector3((x * 2) - 4.25f, -3.4f, (z * 0.7f)));
                    }
                    
                }
                SpawnTrackBlock(new Vector3((x * 2) - 4.25f, 0, (z * 0.7f)));
                
                //SpawnTrackBlock(new Vector3((x * 2) - 4.25f, 0, (z * 3.65f)+2));
            }
        }

        #region holes in the track
        //GameObject GO = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //GO.transform.position = TrackBlockList[Random.Range(0, TrackBlockList.Count - 1)].transform.position;
        //GO.transform.localScale += new Vector3(5, 5, 5);
        //GO.AddComponent<Rigidbody>();
        //GO.GetComponent<Rigidbody>().useGravity = false;
        ////GO.GetComponent<Rigidbody>().angularDrag = 10000;
        //GO.AddComponent<DestroyGOafter3sec>();
        ////GO.GetComponent<Renderer>().enabled = false;
        #endregion


        //Collider[] hitColliders = Physics.OverlapSphere(TrackBlockList[Random.Range(0, TrackBlockList.Count-1)].transform.position, 0.0001f);

        //Debug.Log(hitColliders.Length);

        //foreach (Collider col in hitColliders)
        //{
        //    if (col.gameObject.GetComponent<TrackBlockScript>())
        //    {
        //        Destroy(col.gameObject);
        //    }
            
        //}
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    private void SpawnWallsOnZ(float Z)
    {
        int rndAmountOfWalls = 3;//Random.Range(1, 6);
        List<int> LastPlaces = new List<int>();

        for (int i = 0; i < rndAmountOfWalls; i++)
        {
            int rndPlace;
            do
            {
                rndPlace = Random.Range(1, 8);
            } while (LastPlaces.Contains(rndPlace));

            SpawnWall(new Vector3((rndPlace * 2) - 4.25f, 1, (Z * 0.7f)));
            LastPlaces.Add(rndPlace);
        }
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
        //set variables to the script of the block
        GO.GetComponent<TrackBlockScript>().ZBlocks = _firstBlocks;

        //TrackBlockList.Add(GO);
        //increase the unique number counter
        _trackBlocksCounter++;
    }

    public void SpawnTrackBarrier(Vector3 pPosition)
    {

        //instantiate the actual block
        GameObject GO = (GameObject)Instantiate(_trackBarrier, pPosition, Quaternion.identity);
        //change the parent of the block
        GO.transform.parent = this.gameObject.transform;
        //change the name of the block + the unique number of the block
        GO.name = "TrackBarrier" + _trackBarrierCounter;
        //rotate the block 90 degrees
        //GO.transform.localEulerAngles = new Vector3(0, 90, 0);
        //set variables to the script of the block
        GO.GetComponent<TrackBarrierScript>().ZBlocks = _firstBlocks;

        //TrackBlockList.Add(GO);
        //increase the unique number counter
        _trackBarrierCounter++;
    }

    public void SpawnWall(Vector3 pPosition)
    {
        
            
            //instantiate the actual block
            GameObject GO = (GameObject)Instantiate(_trackWall, pPosition, Quaternion.identity);
            //change the parent of the block
            GO.transform.parent = this.gameObject.transform;
            //change the name of the block + the unique number of the block
            GO.name = "Wall" + _trackWallsCounter;
            //rotate the block 90 degrees
            GO.transform.localEulerAngles = new Vector3(0, 90, 0);
            //set variables to the script of the block
            GO.GetComponent<TrackBlockScript>().ZBlocks = _firstBlocks;

            //increase the unique number counter
            _trackWallsCounter++;
    }
}
