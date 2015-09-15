using UnityEngine;
using System.Collections;

public class explosionsScript : MonoBehaviour {

	IEnumerator DASIEnumerator;
	[SerializeField]int time =2;
	[SerializeField]float force = 25;


    void Start()
    {
        DASIEnumerator = DestroyAfterSec(time);
        StartCoroutine(DestroyAfterSec(time));
	}
//
//	void Update(){
//		if(Input.GetKeyDown(KeyCode.Space)){
//			explode();
//		}
//	}

	void explode(){
	}

	IEnumerator DestroyAfterSec(int time){
        Rigidbody[] rList = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody r in rList)
        {
            r.AddExplosionForce((float)(force * (Random.value + 0.3f)), transform.position, 10, 2, ForceMode.Impulse);
            r.useGravity = true;
        }
		yield return new WaitForSeconds(time);
		Destroy(gameObject);
	}
}
