using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundScript : MonoBehaviour {

    public Sprite Round1Sprite;
    public Sprite Round2Sprite;
    public Sprite Round3Sprite;
    private int round;

	// Use this for initialization
	void Start () {
        round = GameObject.FindObjectOfType<ConfirmScript>().Round;
    }
	
	// Update is called once per frame
	void Update () {
        UpdateImage();
	}

    void UpdateImage()
    {
        //Debug.Log(GameObject.FindObjectOfType<ConfirmScript>().Round / 2);
        //if (GameObject.FindObjectOfType<ConfirmScript>().Round/2 == 1)
        //{
        //    this.GetComponent<Image>().sprite = Round1Sprite;
        //}
        //else if (GameObject.FindObjectOfType<ConfirmScript>().Round/2 == 2)
        //{
        //    this.GetComponent<Image>().sprite = Round2Sprite;
        //}
        //else if (GameObject.FindObjectOfType<ConfirmScript>().Round/2 == 3)
        //{
        //    this.GetComponent<Image>().sprite = Round3Sprite;
        //}

        if (round == 1)
        {
            this.GetComponent<Image>().sprite = Round1Sprite;
        }
        else if (round == 2)
        {
            this.GetComponent<Image>().sprite = Round2Sprite;
        }
        else if (round == 3)
        {
            this.GetComponent<Image>().sprite = Round3Sprite;
        }
    }
}
