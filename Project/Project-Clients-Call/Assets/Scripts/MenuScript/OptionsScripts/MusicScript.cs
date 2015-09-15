using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {

    private AudioSource [] _music;
    private GameObject _volume;
	void Start () 
    {
        _music = gameObject.GetComponentsInChildren<AudioSource>();
        _volume = GameObject.FindGameObjectWithTag("MusicSlidersSlider");
    
	}
    void Update()
    {
        Volume();
    }

    void Volume()
    {

        for (int i = 0; i < _music.Length; i++)
        {
            _music[i].volume = ((-_volume.transform.position.z + 75) / 150);
        }
    
    }
}
