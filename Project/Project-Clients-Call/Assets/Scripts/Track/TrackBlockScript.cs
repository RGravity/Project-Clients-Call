using UnityEngine;
using System.Collections.Generic;

public class TrackBlockScript : MonoBehaviour {

    private bool _moving = false;
    private Vector3 _localFinalSpot;
    private Vector3 _globalFinalSpot;
    private int _zBlocks;

    private List<string> _trackList = new List<string>();
    private int _listPart = 0;

    public List<string> TrackList { set { _trackList = value; } }
    public int ZBlocks { set { _zBlocks = value; } }


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
            _moving = true;

            /*
             * - check if we are already on the Z for the next part
             * - determine what part of the track we are doing
             * - register when the next part of the track has to start
             * 
             * - determine which Z we are on
             * 
             * - curved: what X are we on <===>
             * 
             * - place next part of blocks for the curve
             * - Are we doing the last block part of the curve?
             * - YES: Set a bool to say we are DONE with the curve
             * - NO: Set a bool so we are NOT DONE with the curve
             * 
             *                            /\
             * - sloped: what Y are we on ||
             *                            \/
             *                            
             * - place next part of blocks for the slope
             * - Are we doing the last block part of the slope?
             * - YES: Set a bool to say we are DONE with the slope
             * - NO: Set a bool so we are NOT DONE with the slope
             * 
             */

            // -- actual next position on track
            float NextXPositionLocal = this.transform.localPosition.x;
            float NextYPositionLocal = this.transform.localPosition.y;
            float NextZPositionLocal = this.transform.localPosition.z + (_zBlocks * 0.7f);

            // -- falling 'animation' --
            float NextXPositionGlobal = this.transform.position.x;
            float NextYPositionGlobal = this.transform.position.y;
            float NextZPositionGlobal = this.transform.position.z + (_zBlocks * 0.7f); 



            #region Straight track
            Vector3 LocalPosition = this.transform.localPosition;
            Vector3 GlobalPosition = this.transform.position;

            //Final LOCAL position
            _localFinalSpot = new Vector3(LocalPosition.x, LocalPosition.y, LocalPosition.z + (_zBlocks * 0.7f));

            //Final GLOBAL position
            _globalFinalSpot = new Vector3(GlobalPosition.x, GlobalPosition.y, GlobalPosition.z + (_zBlocks * 0.7f));

            //set next position in the air
            this.transform.position = new Vector3(GlobalPosition.x + Random.Range(-30, 30), GlobalPosition.y + Random.Range(-30, 30), GlobalPosition.z + (_zBlocks * 0.7f));
            #endregion

            #region curve right track
            #endregion

            #region curve left track
            #endregion

            #region slope up track
            #endregion

            #region slope down track
            #endregion



            // ----- Set next position directly -----
            //this.transform.position = new Vector3(position.x, position.y, position.z + (ZBlocks * 0.7f));

            //if (LocalPosition.z % ZBlocks == 0)
            //{
            //    Vector3 PositionWall = new Vector3((Random.Range(0, 3) * 2), LocalPosition.y + 1.27f, LocalPosition.z + (ZBlocks * 0.7f) - 0.19f);

            //    GameObject.FindObjectOfType<TrackBuildScript>().SpawnWall(PositionWall);
            //}
        }
    }
}
