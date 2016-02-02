using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {

    private int _zBlocks;
    public int ZBlocks { set { _zBlocks = value; } }
    private bool respawn = false;

    private ConfirmScript _confirmScript;
    private Player1MoveScript _p1MoveScript;
    private Player2MoveScript _p2MoveScript;
    private ScoreScript _scoreScript;
    private AudioSource _coinSound;
    private TutorialScript _tutorialScript;
    private TrackBuildScript _trackBuildScript;

    // Use this for initialization
    void Start () {
        _confirmScript = GameObject.FindObjectOfType<ConfirmScript>();
        _p1MoveScript = GameObject.FindObjectOfType<Player1MoveScript>();
        _p2MoveScript = GameObject.FindObjectOfType<Player2MoveScript>();
        _scoreScript = GameObject.FindObjectOfType<ScoreScript>();
        _coinSound = GameObject.FindGameObjectWithTag("CoinPickUp").GetComponent<AudioSource>();
        _tutorialScript = GameObject.FindObjectOfType<TutorialScript>();
        _trackBuildScript = GameObject.FindObjectOfType<TrackBuildScript>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (_confirmScript.Tutorial == false)
        {
            if (other.gameObject.name == _p1MoveScript.name)
            {
                _scoreScript.P1ScoreType = ScoreScript.ScoreType.Coin;
                _coinSound.Play();
                respawn = true;
                Destroy(this.gameObject);
            }
            else if (other.gameObject.name == _p2MoveScript.name)
            {
                _scoreScript.P2ScoreType = ScoreScript.ScoreType.Coin;
                _coinSound.Play();
                respawn = true;
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (other.gameObject.name == _p1MoveScript.name)
            {
                _coinSound.Play();
                _tutorialScript.Coin = true;
                Destroy(this.gameObject);
            }
        }
    }

    void OnDestroy()
    {
        if (respawn)
        {
            Vector3 newPosition = this.transform.position;
            newPosition.z += _zBlocks;
            _trackBuildScript.SpawnCoin(newPosition, this.gameObject.transform.parent.gameObject);
        }
    }

    void OnBecameInvisible()
    {
        if (_confirmScript.Tutorial == false)
        {
            respawn = true;
        }
        Destroy(this.gameObject);
        
      
    }
}
