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
    //private GameObject _trackBarrier;
    private GameObject _speedBoostPowerup;
    private GameObject _shieldPowerup;
    private GameObject _coinPowerup;
    private GameObject _drillPowerup;
    private int _trackBlocksCounter;
    private int _trackWallsCounter;
    private int _trackBarrierCounter;
    private int _wallCounter;
    private int _speedCounter = 0;
    private int _shieldCounter = 0;
    private int _drillCounter = 0;
    private int _coinCounter = 0;

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
        //_trackBarrier = (GameObject)Resources.Load("TrackBlock/TrackBarrier");
        _speedBoostPowerup = (GameObject)Resources.Load("Powerups/speedboost Prefab");
        _shieldPowerup = (GameObject)Resources.Load("Powerups/Invulnerability Powerup");
        _coinPowerup = (GameObject)Resources.Load("Powerups/Coin");
        _drillPowerup = (GameObject)Resources.Load("Powerups/RocketDrill");
        
        //spawn the first XXX blocks far
        for (int z = 0; z < _firstBlocks; z++)
        {
            if (z % 10 == 0 && z != 0)
            {
                SpawnWallsOnZ(z);
            }
            if (z % 16 == 0 && z != 0)
            {
                SpawnPowerupsOnZ(z);
            }
            //spawn the XXX blocks wide
            for (int x = 0; x < 7; x++)
            {
                //if (z % 33 == 0)
                //{

                //    if (x == 0)
                //    {
                //        SpawnTrackBarrier(new Vector3((x * 2) - 6.255f, -1.7f, (z * 0.7f)), GameObject.Find("TrackBlocks1"));
                //        SpawnTrackBarrier(new Vector3((x * 2) - 6.255f, -4.2f, (z * 0.7f)), GameObject.Find("TrackBlocks2"));
                //    }
                //    if (x == 6)
                //    {
                //        SpawnTrackBarrier(new Vector3((x * 2) - 2.28f, -1.7f, (z * 0.7f)), GameObject.Find("TrackBlocks1"));
                //        SpawnTrackBarrier(new Vector3((x * 2) - 2.28f, -4.2f, (z * 0.7f)), GameObject.Find("TrackBlocks2"));
                //    }
                    
                    
                //}
                SpawnTrackBlock(new Vector3((x * 2) - 4.25f, 0, (z * 0.7f)), GameObject.Find("TrackBlocks1"));
                SpawnTrackBlock(new Vector3((x * 2) - 4.25f, -1.25f, (z * 0.7f)), GameObject.Find("TrackBlocks2"));
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
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    private void SpawnWallsOnZ(float Z)
    {
        int rndAmountOfWalls = Random.Range(1, 4);
        List<int> LastPlaces = new List<int>();

        for (int i = 0; i < rndAmountOfWalls; i++)
        {
            int rndPlace;
            do
            {
                rndPlace = Random.Range(0, 7);
            } while (LastPlaces.Contains(rndPlace));

            SpawnWall(new Vector3((rndPlace * 2) - 4.6f, 0.6f, (Z * 0.7f)), GameObject.Find("TrackBlocks1"));
            SpawnWall(new Vector3(((6 - rndPlace) * 2) - 4.6f, -3.1f, (Z * 0.7f)), GameObject.Find("TrackBlocks2"));
            LastPlaces.Add(rndPlace);
        }
    }

    private void SpawnPowerupsOnZ(float Z)
    {
        int rndPowerups = Random.Range(0, 7);

        SpawnPowerup(new Vector3((rndPowerups * 2) - 4.25f, 2, (Z * 0.7f)));
    }

    private void SpawnTrackBlock(Vector3 pPosition, GameObject pParent)
    {
        
        //instantiate the actual block
        GameObject GO = (GameObject)Instantiate(_trackBlock, pPosition, Quaternion.identity);
        //change the parent of the block
        GO.transform.parent = pParent.transform;
        //change the name of the block + the unique number of the block
        GO.name = "TrackBlock" + _trackBlocksCounter;
        //rotate the block 90 degrees
        GO.transform.localEulerAngles = new Vector3(0, 90, 0);
        //set variables to the script of the block
        GO.GetComponent<TrackBlockScript>().ZBlocks = _firstBlocks;
        //increase the unique number counter
        _trackBlocksCounter++;
    }

    //public void SpawnTrackBarrier(Vector3 pPosition, GameObject pParent)
    //{
    //    //instantiate the actual block
    //    GameObject GO = (GameObject)Instantiate(_trackBarrier, pPosition, Quaternion.identity);
    //    //change the parent of the block
    //    GO.transform.parent = pParent.transform;
    //    //change the name of the block + the unique number of the block
    //    GO.name = "TrackBarrier" + _trackBarrierCounter;
    //    //rotate the block 90 degrees
    //    //GO.transform.localEulerAngles = new Vector3(0, 90, 0);
    //    //set variables to the script of the block
    //    GO.GetComponent<TrackBarrierScript>().ZBlocks = _firstBlocks;
    //    //increase the unique number counter
    //    _trackBarrierCounter++;
    //}

    public void SpawnWall(Vector3 pPosition, GameObject pParent)
    {  
        //instantiate the actual block
        GameObject GO = (GameObject)Instantiate(_trackWall, pPosition, Quaternion.identity);
        //change the parent of the block
        GO.transform.parent = pParent.transform;
        //change the name of the block + the unique number of the block
        GO.name = "Wall" + _trackWallsCounter;
        //rotate the block 90 degrees
        GO.transform.localEulerAngles = new Vector3(0, 90, 0);
        //set variables to the script of the block
        GO.GetComponent<TrackBlockScript>().ZBlocks = _firstBlocks;
        //increase the unique number counter
        _trackWallsCounter++;
    }

    private void SpawnPowerup(Vector3 pPosition)
    {
        int randomIndex = Random.Range(0, 4);
        GameObject GO;
        switch (randomIndex)
        {
            //Speed Powerup
            case 0:
                GO = (GameObject)Instantiate(_speedBoostPowerup, pPosition, Quaternion.identity);
                GO.transform.localEulerAngles = new Vector3(0, 90, 0);
                GO.transform.parent = this.gameObject.transform;
                GO.name = "Speed" + _speedCounter;
                _speedCounter++;
                break;
            //Shield Powerup
            case 1:
                GO = (GameObject)Instantiate(_shieldPowerup, pPosition, Quaternion.identity);
                GO.transform.localEulerAngles = new Vector3(0, -45, 0);
                GO.transform.parent = this.gameObject.transform;
                GO.name = "Shield" + _shieldCounter;
                _shieldCounter++;
                break;
            //Drill Powerup
            case 2:
                GO = (GameObject)Instantiate(_drillPowerup, pPosition, Quaternion.identity);
                GO.transform.localEulerAngles = new Vector3(0, 90, 0);
                GO.transform.parent = this.gameObject.transform;
                GO.name = "Drill" + _drillCounter;
                _drillCounter++;
                break;
            case 3:
                GO = (GameObject)Instantiate(_coinPowerup, pPosition, Quaternion.identity);
                GO.transform.parent = this.gameObject.transform;
                GO.name = "Coin" + _coinCounter;
                _coinCounter++;
                break;
        }
    }
}
