using UnityEngine;
using System.Collections;

public class RampJumpingScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.name == GameObject.FindObjectOfType<Player1MoveScript>().name)
        {

            GameObject.FindObjectOfType<Jumpscript>().JumpP1 = true;

        }

        else if (other.name == GameObject.FindObjectOfType<Player2MoveScript>().name)
        {
            GameObject.FindObjectOfType<Jumpscript>().JumpP2 = true;
        }
    }
}
