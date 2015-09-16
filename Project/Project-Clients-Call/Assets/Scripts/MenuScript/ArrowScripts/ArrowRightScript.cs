﻿using UnityEngine;
using System.Collections;
using System.Linq;

public class ArrowRightScript : MonoBehaviour {

    // Use this for initialization
    public Material[] materials;
    void Update()
    {

        if (Input.GetAxis("Horizontal P1") > 0.5f)
        {
            GetComponent<MeshRenderer>().material = materials.Where(c => c.name == "arrow pressed").FirstOrDefault();

        }
        else
        {
            GetComponent<MeshRenderer>().material = materials.Where(c => c.name == "arrow").FirstOrDefault();
        }

    }
}
