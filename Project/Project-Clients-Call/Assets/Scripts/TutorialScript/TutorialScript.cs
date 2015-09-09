using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {

    private GameObject _tutorialTextOne;
    private GameObject _tutorialTextTwo;
    private GameObject _tutorialTextThree;
    private GameObject _tutorialTextFour;
    private GameObject _tutorialTextFive;

	// Use this for initialization
	void Start () 
    {
        _tutorialTextOne = GameObject.FindGameObjectWithTag("TutorialOne");

	}
	
	// Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _tutorialTextOne.GetComponent<Rigidbody> ())
        {
            Debug.Log(true);
        }
    }
}
