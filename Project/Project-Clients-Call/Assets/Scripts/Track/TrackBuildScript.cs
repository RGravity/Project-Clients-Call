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
    private GameObject _powerupBox;
    private int _trackBlocksCounter;
    private int _trackWallsCounter;
    private int _trackBarrierCounter;
    private int _wallCounter;
    private int _speedCounter = 0;
    private int _shieldCounter = 0;
    private int _drillCounter = 0;
    private int _coinCounter = 0;
    private int _powerupCounter = 0;

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
        _speedBoostPowerup = (GameObject)Resources.Load("Powerups/speedboost Prefab");
        _shieldPowerup = (GameObject)Resources.Load("Powerups/Invulnerability Powerup");
        _coinPowerup = (GameObject)Resources.Load("Powerups/Coin");
        _drillPowerup = (GameObject)Resources.Load("Powerups/RocketDrill");
        _powerupBox = (GameObject)Resources.Load("Powerups/PowerUpCube");
        
        //spawn the first XXX blocks far
        for (int z = 0; z < _firstBlocks; z++)
        {
            if (z % 10 == 0 && z != 0)
            {
                SpawnWallsOnZ(z);
            }
            if (z % 23 == 0 && z != 0)
            {
                SpawnPowerupsOnZ(z);
            }
            //spawn the XXX blocks wide
            for (int x = 0; x < 7; x++)
            {
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

        SpawnPowerup(new Vector3((rndPowerups * 2) - 4.25f, 1, (Z * 0.7f)), GameObject.Find("TrackBlocks1"));
        SpawnPowerup(new Vector3(((6 - rndPowerups) * 2) - 4.25f, -5, (Z * 0.7f)), GameObject.Find("TrackBlocks2"));
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

    public void SpawnPowerup(Vector3 pPosition, GameObject pParent)
    {

        GameObject GO = (GameObject)Instantiate(_powerupBox, pPosition, Quaternion.identity);
        GO.transform.parent = pParent.transform;
        GO.name = "Powerup" + _powerupCounter;
        GO.transform.localEulerAngles = new Vector3(0, 0, 0);
        GO.GetComponent<PowerupScript>().ZBlocks = _firstBlocks;
        _powerupCounter++;

    }
}
