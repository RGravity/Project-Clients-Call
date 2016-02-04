using UnityEngine;
using System.Collections;

public class RampJumpingScript : MonoBehaviour
{

    private Jumpscript _jumpScript;

    // Use this for initialization
    void Start()
    {
        _jumpScript = GameObject.FindObjectOfType<Jumpscript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.name == GameObject.FindObjectOfType<Player1MoveScript>().name)
        {
            _jumpScript.JumpP1 = true;
        }
        if (other.name == GameObject.FindObjectOfType<Player2MoveScript>().name)
        {
            _jumpScript.JumpP2 = true;
        }
    }
}
