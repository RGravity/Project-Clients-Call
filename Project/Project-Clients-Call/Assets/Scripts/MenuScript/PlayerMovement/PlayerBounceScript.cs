using UnityEngine;
using System.Collections;

public class PlayerBounceScript : MonoBehaviour {

    private bool _movingUp = false;
    private bool _movingDown = false;
	
	// Update is called once per frame
	void Update () 
    {

        if (this.transform.position.y <= -30.6f)
        {
            _movingUp = true;
            _movingDown = false;
        }
        if (this.transform.position.y >= -28)
        {
            _movingUp = false;
            _movingDown = true;
           
        }

        if (_movingDown == true)
        {
            this.transform.position -= new Vector3(0, 0.125f, 0);
        }

        if (_movingUp == true)
        {
            this.transform.position += new Vector3(0, 0.125f, 0);
        }

	
	}
}
