using UnityEngine;
using System.Collections;

public class LettersTutorialScripts : MonoBehaviour {

    void Start()
    { }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == GameObject.FindObjectOfType<PowerUpScriptP1>().name)
        {
            GameObject.FindObjectOfType<TutorialScript>().Letter = true;
            Destroy(this.gameObject);

        }

    }
}
