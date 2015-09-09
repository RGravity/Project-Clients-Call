using UnityEngine;
using System.Collections;

public class Skybox : MonoBehaviour {
    
    public Texture[] textures;
    public Renderer rend;
    int index = 0;
    Vector3 rotation;
    Vector3 currentRotation;

    void Start()
    {
        rend = GetComponent<Renderer>();
        textures = Resources.LoadAll("Background") as Texture[];
    }

    void Update()
    {
        if (textures.Length == 0)
            return;

        index++;
        if (index >= textures.Length)
        {
            index = 0;
        }
        rend.material.mainTexture = textures[index];
        currentRotation = transform.localEulerAngles;
        rotation = currentRotation + new Vector3(0, 0.10f, 0);
        transform.localEulerAngles = rotation; 

    }
}
