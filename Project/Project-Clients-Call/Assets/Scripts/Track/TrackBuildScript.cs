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

    private List<string> _puzzleWord = new List<string>();
    #region letter variables
    private GameObject _letterA;
    private GameObject _letterB;
    private GameObject _letterC;
    private GameObject _letterD;
    private GameObject _letterE;
    private GameObject _letterF;
    private GameObject _letterG;
    private GameObject _letterH;
    private GameObject _letterI;
    private GameObject _letterJ;
    private GameObject _letterK;
    private GameObject _letterL;
    private GameObject _letterM;
    private GameObject _letterN;
    private GameObject _letterO;
    private GameObject _letterP;
    private GameObject _letterQ;
    private GameObject _letterR;
    private GameObject _letterS;
    private GameObject _letterT;
    private GameObject _letterU;
    private GameObject _letterV;
    private GameObject _letterW;
    private GameObject _letterX;
    private GameObject _letterY;
    private GameObject _letterZ;
    #endregion

    private GameObject _trackBlock;
    private GameObject _trackBlockRed;
    private GameObject _trackRamp;
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
    public List<string> PuzzleWord { set { _puzzleWord = value; } }

	// Use this for initialization
	void Start () {

        _trackBlocksCounter = 0;
        _trackWallsCounter = 0;
        _trackBarrierCounter = 0;
        _trackBlock = (GameObject)Resources.Load("TrackBlock/TrackBlock");
        _trackBlockRed = (GameObject)Resources.Load("TrackBlock/TrackBlockRed");
        _trackRamp = (GameObject)Resources.Load("TrackBlock/Ramp");
        _trackWall = (GameObject)Resources.Load("TrackBlock/TrackWall");
        _speedBoostPowerup = (GameObject)Resources.Load("Powerups/speedboost Prefab");
        _shieldPowerup = (GameObject)Resources.Load("Powerups/Invulnerability Powerup");
        _coinPowerup = (GameObject)Resources.Load("Powerups/Coin");
        _drillPowerup = (GameObject)Resources.Load("Powerups/RocketDrill");
        _powerupBox = (GameObject)Resources.Load("Powerups/PowerUpCube");

        
        #region Loading Letters
        _letterA = (GameObject)Resources.Load("Letters/A");
        _letterB = (GameObject)Resources.Load("Letters/B");
        _letterC = (GameObject)Resources.Load("Letters/C");
        _letterD = (GameObject)Resources.Load("Letters/D");
        _letterE = (GameObject)Resources.Load("Letters/E");
        _letterF = (GameObject)Resources.Load("Letters/F");
        _letterG = (GameObject)Resources.Load("Letters/G");
        _letterH = (GameObject)Resources.Load("Letters/H");
        _letterI = (GameObject)Resources.Load("Letters/I");
        _letterJ = (GameObject)Resources.Load("Letters/J");
        _letterK = (GameObject)Resources.Load("Letters/K");
        _letterL = (GameObject)Resources.Load("Letters/L");
        _letterM = (GameObject)Resources.Load("Letters/M");
        _letterN = (GameObject)Resources.Load("Letters/N");
        _letterO = (GameObject)Resources.Load("Letters/O");
        _letterP = (GameObject)Resources.Load("Letters/P");
        _letterQ = (GameObject)Resources.Load("Letters/Q");
        _letterR = (GameObject)Resources.Load("Letters/R");
        _letterS = (GameObject)Resources.Load("Letters/S");
        _letterT = (GameObject)Resources.Load("Letters/T");
        _letterU = (GameObject)Resources.Load("Letters/U");
        _letterV = (GameObject)Resources.Load("Letters/V");
        _letterW = (GameObject)Resources.Load("Letters/W");
        _letterX = (GameObject)Resources.Load("Letters/X");
        _letterY = (GameObject)Resources.Load("Letters/Y");
        _letterZ = (GameObject)Resources.Load("Letters/Z");
        #endregion

        Vector3 PlayerPosition = GameObject.FindObjectOfType<Player1MoveScript>().transform.position;
        Vector3 FinishPosition = GameObject.FindObjectOfType<Finish>().transform.position;
        Vector3 Distance = FinishPosition - PlayerPosition;
        float Length = Distance.magnitude;
        int AmountofPlaces = _puzzleWord.Count + 2;
        float LengthBetweenLetters = Length / AmountofPlaces;
        float currentZcoords = LengthBetweenLetters;

        foreach (string letter in _puzzleWord)
        {
            int x = Random.Range(0,7);
            SpawnLetter(new Vector3((x * 2) - 4.25f, 2, (currentZcoords * 0.7f)), letter, GameObject.Find("TrackBlocks1"));
            SpawnLetter(new Vector3(((6 - x) * 2) - 4.25f, -3, (currentZcoords * 0.7f)), letter, GameObject.Find("TrackBlocks2"));
            currentZcoords += LengthBetweenLetters;
        }

        //spawn the first XXX blocks far
        for (int z = 0; z < _firstBlocks; z++)
        {
            if (GameObject.FindObjectOfType<ConfirmScript>().Tutorial == false)
            {
                if (z % 10 == 0 && z != 0)
                {
                    SpawnWallsOnZ(z);
                }
                if (z % 23 == 0 && z != 0)
                {
                    SpawnPowerupsOnZ(z);
                }
            }
            
            
            //spawn the XXX blocks wide
            int rnd = Random.Range(0, 7);
            for (int x = 0; x < 7; x++)
            {
                if (z != 0)
                {
                    if (z == 13 || z == 33)
                    {
                        SpawnCoin(new Vector3((rnd * 2) - 4.25f, 0.75f, (z * 0.7f)), GameObject.Find("TrackBlocks1"));
                        SpawnCoin(new Vector3(((6 - rnd) * 2) - 4.25f, -2, (z * 0.7f)), GameObject.Find("TrackBlocks2"));
                    }
                    if (z % 35 == 0 && x == 3)
                    {
                        SpawnRamp(new Vector3((x * 2) - 4.25f, 0.5f, (z * 0.7f)), GameObject.Find("TrackBlocks1"));
                        SpawnRamp(new Vector3((x * 2) - 4.25f, -1.75f, (z * 0.7f)), GameObject.Find("TrackBlocks2"));
                        SpawnTrackBlock(new Vector3((x * 2) - 4.25f, 0, (z * 0.7f)), GameObject.Find("TrackBlocks1"));
                        SpawnTrackBlock(new Vector3((x * 2) - 4.25f, -1.25f, (z * 0.7f)), GameObject.Find("TrackBlocks2"));
                    }
                    else if (z % 37 == 0 || z % 38 == 0 || z % 39 == 0)
                    {
                        SpawnTrackBlockRed(new Vector3((x * 2) - 4.25f, 0, (z * 0.7f)), GameObject.Find("TrackBlocks1"));
                        SpawnTrackBlockRed(new Vector3((x * 2) - 4.25f, -1.25f, (z * 0.7f)), GameObject.Find("TrackBlocks2"));
                    }
                    else
                    {
                        SpawnTrackBlock(new Vector3((x * 2) - 4.25f, 0, (z * 0.7f)), GameObject.Find("TrackBlocks1"));
                       SpawnTrackBlock(new Vector3((x * 2) - 4.25f, -1.25f, (z * 0.7f)), GameObject.Find("TrackBlocks2"));
                    }
                }
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

    private void SpawnLetter(Vector3 pPosition, string pLetter, GameObject pParent){
        GameObject GO = new GameObject();

        #region Switch pLetter
        switch(pLetter){
            case "A":
                GO = (GameObject)Instantiate(_letterA, pPosition, Quaternion.identity);
                break;
            case "B":
                GO = (GameObject)Instantiate(_letterB, pPosition, Quaternion.identity);
                break;
            case "C":
                GO = (GameObject)Instantiate(_letterC, pPosition, Quaternion.identity);
                break;
            case "D":
                GO = (GameObject)Instantiate(_letterD, pPosition, Quaternion.identity);
                break;
            case "E":
                GO = (GameObject)Instantiate(_letterE, pPosition, Quaternion.identity);
                break;
            case "F":
                GO = (GameObject)Instantiate(_letterF, pPosition, Quaternion.identity);
                break;
            case "G":
                GO = (GameObject)Instantiate(_letterG, pPosition, Quaternion.identity);
                break;
            case "H":
                GO = (GameObject)Instantiate(_letterH, pPosition, Quaternion.identity);
                break;
            case "I":
                GO = (GameObject)Instantiate(_letterI, pPosition, Quaternion.identity);
                break;
            case "J":
                GO = (GameObject)Instantiate(_letterJ, pPosition, Quaternion.identity);
                break;
            case "K":
                GO = (GameObject)Instantiate(_letterK, pPosition, Quaternion.identity);
                break;
            case "L":
                GO = (GameObject)Instantiate(_letterL, pPosition, Quaternion.identity);
                break;
            case "M":
                GO = (GameObject)Instantiate(_letterM, pPosition, Quaternion.identity);
                break;
            case "N":
                GO = (GameObject)Instantiate(_letterN, pPosition, Quaternion.identity);
                break;
            case "O":
                GO = (GameObject)Instantiate(_letterO, pPosition, Quaternion.identity);
                break;
            case "P":
                GO = (GameObject)Instantiate(_letterP, pPosition, Quaternion.identity);
                break;
            case "Q":
                GO = (GameObject)Instantiate(_letterQ, pPosition, Quaternion.identity);
                break;
            case "R":
                GO = (GameObject)Instantiate(_letterR, pPosition, Quaternion.identity);
                break;
            case "S":
                GO = (GameObject)Instantiate(_letterS, pPosition, Quaternion.identity);
                break;
            case "T":
                GO = (GameObject)Instantiate(_letterT, pPosition, Quaternion.identity);
                break;
            case "U":
                GO = (GameObject)Instantiate(_letterU, pPosition, Quaternion.identity);
                break;
            case "V":
                GO = (GameObject)Instantiate(_letterV, pPosition, Quaternion.identity);
                break;
            case "W":
                GO = (GameObject)Instantiate(_letterW, pPosition, Quaternion.identity);
                break;
            case "X":
                GO = (GameObject)Instantiate(_letterX, pPosition, Quaternion.identity);
                break;
            case "Y":
                GO = (GameObject)Instantiate(_letterY, pPosition, Quaternion.identity);
                break;
            case "Z":
                GO = (GameObject)Instantiate(_letterZ, pPosition, Quaternion.identity);
                break;
            default:
                break;
        }
        #endregion

        GO.transform.parent = pParent.transform;
        GO.name = pLetter;

        if (pParent.name == "TrackBlocks1")
        {
            GO.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (pParent.name == "TrackBlocks2")
        {
            GO.transform.localEulerAngles = new Vector3(0, 0, 180);
        }
        

        
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

    private void SpawnTrackBlockRed(Vector3 pPosition, GameObject pParent)
    {

        //instantiate the actual block
        GameObject GO = (GameObject)Instantiate(_trackBlockRed, pPosition, Quaternion.identity);
        //change the parent of the block
        GO.transform.parent = pParent.transform;
        //change the name of the block + the unique number of the block
        GO.name = "TrackBlockRed" + _trackBlocksCounter;
        //rotate the block 90 degrees
        GO.transform.localEulerAngles = new Vector3(0, 90, 0);
        //set variables to the script of the block
        GO.GetComponent<TrackBlockScript>().ZBlocks = _firstBlocks;
        //increase the unique number counter
        _trackBlocksCounter++;
    }

    private void SpawnRamp(Vector3 pPosition, GameObject pParent)
    {

        //instantiate the actual block
        GameObject GO = (GameObject)Instantiate(_trackRamp, pPosition, Quaternion.identity);
        //change the parent of the block
        GO.transform.parent = pParent.transform;
        //change the name of the block + the unique number of the block
        GO.name = "TrackRamp" + _trackBlocksCounter;
        //rotate the block 90 degrees
        if (pParent.name == "TrackBlocks1")
        {
            GO.transform.localEulerAngles = new Vector3(0, 90, 0);
        }
        else if (pParent.name == "TrackBlocks2")
        {
            GO.transform.localEulerAngles = new Vector3(180, 90, 0);
        }
        //set variables to the script of the block
        GO.GetComponent<TrackRampScript>().ZBlocks = _firstBlocks;
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
        GO.GetComponent<PowerupPickup>().ZBlocks = _firstBlocks;
        _powerupCounter++;

    }

    public void SpawnCoin(Vector3 pPosition, GameObject pParent)
    {
        GameObject GO = (GameObject)Instantiate(_coinPowerup, pPosition, Quaternion.identity);
        GO.transform.parent = pParent.transform;
        GO.name = "Coin" + _powerupCounter;
        if (pParent.name == "TrackBlocks1")
        {
            GO.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (pParent.name == "TrackBlocks2")
        {
            GO.transform.localEulerAngles = new Vector3(0, 0, 180);
        }
        GO.GetComponent<CoinScript>().ZBlocks = _firstBlocks;
        _powerupCounter++;
    }
}
