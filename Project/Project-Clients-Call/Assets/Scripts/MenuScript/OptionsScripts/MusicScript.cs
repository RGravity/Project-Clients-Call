using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {

    private AudioSource [] _music;
    private GameObject _volume;
    private bool _play = false;
    private bool _play2 = false;
    public bool Play { get { return _play; } set { _play = value; } }

    private static GameObject _instance;

    void Awake()
    {
        //if we don't have an [_instance] set yet
        if (!_instance)
        {
            _instance = this.gameObject;
           
        }
        //otherwise, if we do, kill this thing
        else
            Destroy(this.gameObject);


        DontDestroyOnLoad(this.gameObject);
    }
	void Start () 
    {
        _music = gameObject.GetComponentsInChildren<AudioSource>();
        _volume = GameObject.FindGameObjectWithTag("MusicSlidersSlider");
      

      
	}
    void Update()
    {
        Volume();
        PlayNextMusic();
        if (Input.GetKey(KeyCode.Escape))
        {
            _play2 = true;
        }
        BackToMenu();
    }

    void Volume()
    {
        for (int i = 0; i < _music.Length; i++)
        {
            _music[i].volume = ((-_volume.transform.position.z + 75) / 150);
        }
    }

    void PlayNextMusic()
    {
        if (_play == true)
        {
            StartCoroutine("PlayNextInGameMusic", 0.1f);
            _music[0].Stop();
            _music[1].Play();
            _play = false;
        }

    }

    void BackToMenu()
    { 
        if (_play2 == true)
        {
            
            Application.LoadLevel(2);
            _music[0].Play ();
            _music[1].Stop ();
            _music[2].Stop ();
            GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer1 = 0;
            GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer2 = 0;
            StopCoroutine("PlayNextInGameMusic");
            _play2 = false;
        }
    
    }

    IEnumerator PlayNextInGameMusic()
    {
        yield return new WaitForSeconds (_music [1].clip.length);
        _music[2].Play();
    }
}
