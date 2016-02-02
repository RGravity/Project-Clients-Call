using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CollisionScript : MonoBehaviour
{
    bool startTimer = false;

    int round = 0;

    float timer = 0;
    float secondsLeftP1 = 5;
    float secondsLeftP2 = 5;
    bool isActivated = false;
    float shootingWallTimer = 0;
    int shootingWallCount = 0;

    float reloadTime = 0;
    bool showTime = true;

    [SerializeField]
    private GameObject _replacedPrefab;
    [SerializeField]
    private GameObject _disappearWall;

    private Player1LevelScript _player1LevelScript;
    private PowerUpScriptP1 _powerupScriptP1;
    private ScoreScript _scoreScript;
    private GameObject _hittingWall;
    private Player2LevelScript _player2LevelScript;
    private PowerUpScriptP1 _powerUpScriptP1;
    private TutorialScript _tutorialScript;
    private ConfirmScript _confirmScript;

    public GameObject DisappearWall { get { return _disappearWall; } }

    // Use this for initialization
    void Start()
    {
        if (GameObject.FindObjectOfType<ConfirmScript>().Tutorial == false)
        {
            round = GameObject.FindObjectOfType<ConfirmScript>().Round;
        }
        _player1LevelScript = GameObject.FindObjectOfType<Player1LevelScript>();
        _powerupScriptP1 = GameObject.FindObjectOfType<PowerUpScriptP1>();
        _scoreScript = GameObject.FindObjectOfType<ScoreScript>();
        _hittingWall = GameObject.Find("HittingWall");
        _player2LevelScript = GameObject.FindObjectOfType<Player2LevelScript>();
        _powerUpScriptP1 = GameObject.FindObjectOfType<PowerUpScriptP1>();
        _tutorialScript = GameObject.FindObjectOfType<TutorialScript>();
        _confirmScript = GameObject.FindObjectOfType<ConfirmScript>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Bullet"))
        {
            if (other.GetComponent<Bullet>().IsPlayer1)
            {
                GameObject disappearWall = (GameObject)GameObject.Instantiate(_disappearWall, this.transform.position, Quaternion.identity);
                disappearWall.GetComponent<ParticleSystem>().gravityModifier = -1.44f;
                disappearWall.GetComponent<ParticleSystem>().Play();
            }
            if (!other.GetComponent<Bullet>().IsPlayer1)
            {
                GameObject disappearWall = (GameObject)GameObject.Instantiate(_disappearWall, this.transform.position, Quaternion.identity);
                disappearWall.GetComponent<ParticleSystem>().gravityModifier = 1.44f;
                disappearWall.GetComponent<ParticleSystem>().Play();
            }
            //_disappearWall.transform.position = this.transform.position;
        }
        if (_confirmScript.Tutorial == false)
        {
            if (other.gameObject.name == _player1LevelScript.name && _powerupScriptP1.Invulnerable)
            {
                _player1LevelScript.SlowSpeed = true;

                _scoreScript.P1ScoreType = ScoreScript.ScoreType.Wall;
                _hittingWall.GetComponent<AudioSource>().Play();
                Instantiate(_replacedPrefab);
                _replacedPrefab.gameObject.transform.position = other.gameObject.transform.position;
                _replacedPrefab.gameObject.transform.rotation = other.gameObject.transform.rotation;
                //Destroy(this.gameObject);
                if (this.gameObject.name != "Finish")
                {
                    GetComponent<TrackBlockScript>().OnBecameInvisible();
                }
            }
            if (other.gameObject.name == _player2LevelScript.name && !_powerUpScriptP1.Invulnerable)
            {
                _player2LevelScript.SlowSpeed = true;
                _scoreScript.P2ScoreType = ScoreScript.ScoreType.Wall;
                _hittingWall.GetComponent<AudioSource>().Play();
                Instantiate(_replacedPrefab);

                _replacedPrefab.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y - 0.5f, other.gameObject.transform.rotation.z);
                _replacedPrefab.gameObject.transform.rotation = other.gameObject.transform.rotation;
                //Destroy(this.gameObject);
                if (this.gameObject.name != "Finish")
                {
                    GetComponent<TrackBlockScript>().OnBecameInvisible();
                }
            }
        }
        else
        {
            if (other.gameObject.name == _player1LevelScript.name && !_powerupScriptP1.Invulnerable)
            {
                _player1LevelScript.SlowSpeed = true;
                _scoreScript.P1ScoreType = ScoreScript.ScoreType.Wall;
                _tutorialScript.Wall = true;
                _hittingWall.GetComponent<AudioSource>().Play();
                Instantiate(_replacedPrefab);
                _replacedPrefab.gameObject.transform.position = other.gameObject.transform.position;
                _replacedPrefab.gameObject.transform.rotation = other.gameObject.transform.rotation;

                //Destroy(this.gameObject);
                if (this.gameObject.name != "Finish")
                {
                    GetComponent<TrackBlockScript>().OnBecameInvisible();
                }
            }
        }
    }

   
}
