using UnityEngine;
using System.Collections;
using System.Linq;

public class ArrowRightScript2 : MonoBehaviour {

    public Material[] materials;
    private bool _moveHorizontal1 = false;
    private bool _moveHorizontal2 = false;
    private bool _playSound = false;
    public bool PlaySound { get { return _playSound; } set { _playSound = value; } }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Horizontal P2") > 0.5f)
        {
            GetComponent<MeshRenderer>().material = materials.Where(c => c.name == "arrow pressed").FirstOrDefault();

        }
        else
        {
            GetComponent<MeshRenderer>().material = materials.Where(c => c.name == "arrow").FirstOrDefault();
        }

        if (_playSound == true)
        {
            if (Input.GetAxisRaw("Horizontal P1") != 0)
            {
                if (_moveHorizontal1 == false)
                {
                    // Call your event function here.
                    _moveHorizontal1 = true;
                    GameObject.FindGameObjectWithTag("PlayerMovement").GetComponent<AudioSource>().Play();
                }
            }
            if (Input.GetAxisRaw("Horizontal P1") == 0)
            {
                _moveHorizontal1 = false;
            }

            if (Input.GetAxisRaw("Horizontal P2") != 0)
            {
                if (_moveHorizontal2 == false)
                {
                    // Call your event function here.
                    _moveHorizontal2 = true;
                    GameObject.FindGameObjectWithTag("Selection").GetComponent<AudioSource>().Play();
                }
            }
            if (Input.GetAxisRaw("Horizontal P2") == 0)
            {
                _moveHorizontal2 = false;
            }

        }
    }

}
