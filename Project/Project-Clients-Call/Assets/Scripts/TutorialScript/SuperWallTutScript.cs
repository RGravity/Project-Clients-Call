using UnityEngine;
using System.Collections;

public class SuperWallTutScript : MonoBehaviour {

    void Start()
    { }

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == GameObject.FindObjectOfType<PowerUpScriptP1>().name)
        {
            GameObject.FindObjectOfType<TutorialScript>().Superwall = true;
            Destroy(this.gameObject);
           
        }
    
    }
}
