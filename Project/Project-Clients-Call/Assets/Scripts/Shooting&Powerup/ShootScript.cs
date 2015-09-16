using UnityEngine;
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
	// Use this for initialization
	void Start () {
        timeStampP1 = Time.time;
        timeStampP2 = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
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
                GameObject.FindGameObjectWithTag("Shoot").GetComponent<AudioSource>().Play();
            }
            else
            {
                timeStampP1 = Time.time + coolDownPeriodInSeconds;
            }
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
                GameObject.FindGameObjectWithTag("Shoot").GetComponent<AudioSource>().Play();
            }
            else
            {
                timeStampP2 = Time.time + coolDownPeriodInSeconds;
            }
        }

	}
}
