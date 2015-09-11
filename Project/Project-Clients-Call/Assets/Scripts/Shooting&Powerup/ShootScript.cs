using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {

    public GameObject bulletPrefab;
    private Transform _bullet;
    private float timeStampP1;
    private float timeStampP2;
    private int coolDownPeriodInSeconds = 3;
	// Use this for initialization
	void Start () {
        timeStampP1 = Time.time;
        timeStampP2 = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire2P1") && this.name == "Player 1" && timeStampP1 <= Time.time)
        {
            timeStampP1 = Time.time + coolDownPeriodInSeconds;
            bulletPrefab.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 1.3f);
            _bullet = Instantiate(bulletPrefab).GetComponent<Transform>();
            _bullet.GetComponent<Bullet>().Player(true);
        }
        if (Input.GetButtonDown("Fire2P2") && this.name == "Player 2" && timeStampP2 <= Time.time)
        {
            timeStampP2 = Time.time + coolDownPeriodInSeconds;
            bulletPrefab.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 1.3f);
            _bullet = Instantiate(bulletPrefab).GetComponent<Transform>();
            _bullet.GetComponent<Bullet>().Player(false);
        }
	}
}
