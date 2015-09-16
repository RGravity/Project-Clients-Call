using UnityEngine;
using System.Collections;

public class SliderScript2 : MonoBehaviour
{
    private bool _sound = false;

    public bool Sound { get { return _sound; } set { _sound = value; } }

    void Update()
    {
        if (_sound == true)
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
