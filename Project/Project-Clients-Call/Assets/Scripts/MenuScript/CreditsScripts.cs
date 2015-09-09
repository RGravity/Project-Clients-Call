using UnityEngine;
using System.Collections;

public class CreditsScripts : MonoBehaviour {

	
	// Update is called once per frame
	void Update () 
    {
        
            this.gameObject.transform.position = this.gameObject.transform.position - new Vector3(1, 0, 0);

            if (this.gameObject.transform.position == new Vector3(-1134, 1868, 225))
            {

                this.gameObject.transform.position = new Vector3(383, 1868, 225);
            }
        
	}
}
