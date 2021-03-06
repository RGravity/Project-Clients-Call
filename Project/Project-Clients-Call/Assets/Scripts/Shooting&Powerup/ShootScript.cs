﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShootScript : MonoBehaviour {

    public GameObject bulletPrefab;
    private Transform _bullet;
    private float timeStampP1;
    private float timeStampP2;
    private float timeShotP1;
    private float timeShotP2;
    private int coolDownPeriodInSeconds = 3;
    private bool fireStartedP1 = false;
    private bool fireStartedP2 = false;
    private Image _shootAllowIconP1;
    private Image _shootAllowIconP2;
    private Image _shootDenyIconP1;
    private Image _shootDenyIconP2;
    private AudioSource _shootSound;
    // Use this for initialization
    void Start () {
        timeStampP1 = Time.time;
        timeStampP2 = Time.time;
        
        _shootAllowIconP1 = GameObject.Find("ShootAllowIconP1").GetComponent<Image>();
        _shootDenyIconP1 = GameObject.Find("ShootDenyIconP1").GetComponent<Image>();

        _shootAllowIconP2 = GameObject.Find("ShootAllowIconP2").GetComponent<Image>();
        _shootDenyIconP2 = GameObject.Find("ShootDenyIconP2").GetComponent<Image>();
        _shootSound = GameObject.FindGameObjectWithTag("Shoot").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        if (this.name == "Player 1" && timeStampP1 <= Time.time || fireStartedP1)
        {
            _shootAllowIconP1.enabled = true;
            _shootDenyIconP1.enabled = false;
        }
        else if (this.name == "Player 1" && timeStampP1 > Time.time || fireStartedP1)
        {
            _shootAllowIconP1.enabled = false;
            _shootDenyIconP1.enabled = true;
        }
        if (Input.GetButtonDown("Fire2P1") && this.name == "Player 1" && timeStampP1 <= Time.time || fireStartedP1)
        {
            fireStartedP1 = true;
            if (Input.GetButtonDown("Fire2P1"))
	        {
                timeShotP1 = Time.time + 1.2f;
	        }   
            if (timeShotP1 < Time.time)
            {
                bulletPrefab.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1f);
                _bullet = Instantiate(bulletPrefab).GetComponent<Transform>();
                _bullet.GetComponent<Bullet>().Player(true);
                fireStartedP1 = false;
                _shootSound.Play();
            }
            else
            {
                timeStampP1 = Time.time + coolDownPeriodInSeconds;
                //GameObject.Find("ShootAllowIconP1").GetComponent<Image>().enabled = false;
               // GameObject.Find("ShootDenyIconP1").GetComponent<Image>().enabled = true;
            }
        }




        if (this.name == "Player 2" && timeStampP2 <= Time.time || fireStartedP2)
        {
            _shootAllowIconP2.enabled = true;
            _shootDenyIconP2.enabled = false;
        }
        else if (this.name == "Player 2" && timeStampP2 > Time.time || fireStartedP2)
        {
            _shootAllowIconP2.enabled = false;
            _shootDenyIconP2.enabled = true;
        }
        if (Input.GetButtonDown("Fire2P2") && this.name == "Player 2" && timeStampP2 <= Time.time || fireStartedP2)
        {
            fireStartedP2 = true;

            if (Input.GetButtonDown("Fire2P2"))
            {
                timeShotP2 = Time.time + 1.2f;
            }
            if (timeShotP2 < Time.time)
            {
                bulletPrefab.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.4f, this.transform.position.z + 1f);
                _bullet = Instantiate(bulletPrefab).GetComponent<Transform>();
                _bullet.GetComponent<Bullet>().Player(false);
                fireStartedP2 = false;
                _shootSound.Play();
            }
            else
            {
                timeStampP2 = Time.time + coolDownPeriodInSeconds;
                //GameObject.Find("ShootAllowIconP2").GetComponent<Image>().enabled = false;
                // GameObject.Find("ShootDenyIconP2").GetComponent<Image>().enabled = true;
            }
        }

	}
}
