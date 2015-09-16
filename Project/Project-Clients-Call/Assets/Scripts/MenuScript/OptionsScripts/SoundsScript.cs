using UnityEngine;
using System.Collections;

public class SoundsScript : MonoBehaviour 
{
    private AudioSource[] _music;
    private GameObject _volume;

    private bool _play = false;

    public bool Play { get { return _play; } set { _play = value; } }

    private static GameObject _instance;



    void Awake()
    {
        //if we don't have an [_instance] set yet
        if (!_instance)
            _instance = this.gameObject;
        //otherwise, if we do, kill this thing
        else
            Destroy(this.gameObject);


        DontDestroyOnLoad(this.gameObject);
    }
    

    
    void Start()
    {
        _music = gameObject.GetComponentsInChildren<AudioSource>();
        _volume = GameObject.FindGameObjectWithTag("SFXSlidersSlider");
        
    }
    void Update()
    {
       
        Volume();
        StartCountDown();
    }

    void Volume()
    {
       
        for (int i = 0; i < _music.Length; i++)
        {
            _music[i].volume = ((-_volume.transform.position.z + 75) / 150);
        }

    }

    void StartCountDown()
    {
        if (_play == true)
        { 
            _music[4].Play ();
            _play = false;
        }
    
    }
}
