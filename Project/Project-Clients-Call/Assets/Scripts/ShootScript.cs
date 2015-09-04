using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {

    public GameObject bulletPrefab;
    private Transform _bullet;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.M) && this.name == "Player 1")
        {
            bulletPrefab.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 1.3f);
            _bullet = Instantiate(bulletPrefab).GetComponent<Transform>();
            _bullet.GetComponent<Bullet>().Player(true);
        }
        if (Input.GetKeyDown(KeyCode.F) && this.name == "Player 2")
        {
            bulletPrefab.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 1.3f);
            _bullet = Instantiate(bulletPrefab).GetComponent<Transform>();
            _bullet.GetComponent<Bullet>().Player(false);

        }
	}
}
