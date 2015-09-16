using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour 
{

    private GameObject _tutorialTextOne;
   // private GameObject _tutorialTextTwo;
    private Player1LevelScript _p1;

	// Use this for initialization
	void Start () 
    {
        _tutorialTextOne = GameObject.FindGameObjectWithTag("TutorialOne");
        //_tutorialTextTwo = GameObject.FindGameObjectWithTag("TutorialTwo");
        _p1 = GameObject.FindObjectOfType<Player1LevelScript>();
	}
	
	// Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _tutorialTextOne)
        {
            //_p1.StopSpeedTutorial = true;


        }

        //if (other.gameObject == _tutorialTextTwo)
        //{
        //    _p1.StopSpeed = true;
        //}
    }
}
