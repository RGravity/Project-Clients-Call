using UnityEngine;
using System.Collections;

public class SliderScript1 : MonoBehaviour
{
    private bool _music = false;
    public bool Music { get { return _music; } set { _music = value; } }

    // Update is called once per frame
    void Update()
    {
        if (_music == true)
        {
            if (Input.GetAxis("Horizontal P1") < -0.5f && this.gameObject.transform.position.z < 75)
            {
                this.gameObject.transform.position = this.gameObject.transform.position + new Vector3(0, 0, 1);

            }
            else if (Input.GetAxis("Horizontal P1") > 0.5f && this.gameObject.transform.position.z > -75)
            {
                this.gameObject.transform.position = this.gameObject.transform.position - new Vector3(0, 0, 1);
            }
        }
        
           
    }


}
