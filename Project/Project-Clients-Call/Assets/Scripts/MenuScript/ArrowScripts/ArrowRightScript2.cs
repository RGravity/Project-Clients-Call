using UnityEngine;
using System.Collections;
using System.Linq;

public class ArrowRightScript2 : MonoBehaviour {

    public Material[] materials;
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

    }

}
