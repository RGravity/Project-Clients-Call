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

    public GameObject DisappearWall { get { return _disappearWall; } }

    // Use this for initialization
    void Start()
    {
        if (GameObject.FindObjectOfType<ConfirmScript>().Tutorial == false)
        {
            round = GameObject.FindObjectOfType<ConfirmScript>().round;
        }
        
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
        if (GameObject.FindObjectOfType<ConfirmScript>().Tutorial == false)
        {
            if (other.gameObject.name == GameObject.FindObjectOfType<Player1MoveScript>().name && !GameObject.FindObjectOfType<PowerUpScriptP1>().Invulnerable)
            {
                GameObject.FindObjectOfType<Player1LevelScript>().SlowSpeed = true;
                
                GameObject.FindObjectOfType<ScoreScript>().P1ScoreType = ScoreScript.ScoreType.Wall;
                GameObject.FindGameObjectWithTag("HittingWall").GetComponent<AudioSource>().Play();
                Instantiate(_replacedPrefab);
                _replacedPrefab.gameObject.transform.position = other.gameObject.transform.position;
                _replacedPrefab.gameObject.transform.rotation = other.gameObject.transform.rotation;
                //Destroy(this.gameObject);
                if (this.gameObject.name != "Finish")
                {
                    GetComponent<TrackBlockScript>().OnBecameInvisible();
                }
            }
            if (other.gameObject.name == GameObject.FindObjectOfType<Player2MoveScript>().name && !GameObject.FindObjectOfType<PowerUpScriptP1>().Invulnerable)
            {
                GameObject.FindObjectOfType<Player2LevelScript>().SlowSpeed = true;
                GameObject.FindObjectOfType<ScoreScript>().P2ScoreType = ScoreScript.ScoreType.Wall;
                GameObject.FindGameObjectWithTag("HittingWall").GetComponent<AudioSource>().Play();
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
            if (other.gameObject.name == GameObject.FindObjectOfType<Player1MoveScript>().name && !GameObject.FindObjectOfType<PowerUpScriptP1>().Invulnerable)
            {
                GameObject.FindObjectOfType<Player1LevelScript>().SlowSpeed = true;
                GameObject.FindObjectOfType<ScoreScript>().P1ScoreType = ScoreScript.ScoreType.Wall;
                GameObject.FindObjectOfType<TutorialScript>().Wall = true;
                GameObject.FindGameObjectWithTag("HittingWall").GetComponent<AudioSource>().Play();
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
