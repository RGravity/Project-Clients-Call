using UnityEngine;
using System.Collections;

public class LogoSaxionFunieFit : MonoBehaviour {

    private float screenTime = 0;
    // Use this for initialization
    void Start()
    {
        screenTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > (screenTime + 2.5f))
        {
            Application.LoadLevel(1);
        }
    }
}
