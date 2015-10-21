using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundScript : MonoBehaviour {

    public Sprite Round1Sprite;
    public Sprite Round2Sprite;
    public Sprite Round3Sprite;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        UpdateImage();
	}

    void UpdateImage()
    {
        Debug.Log(GameObject.FindObjectOfType<ConfirmScript>().round / 2);
        if (GameObject.FindObjectOfType<ConfirmScript>().round/2 == 1)
        {
            this.GetComponent<Image>().sprite = Round1Sprite;
        }
        else if (GameObject.FindObjectOfType<ConfirmScript>().round/2 == 2)
        {
            this.GetComponent<Image>().sprite = Round2Sprite;
        }
        else if (GameObject.FindObjectOfType<ConfirmScript>().round/2 == 3)
        {
            this.GetComponent<Image>().sprite = Round3Sprite;
        }
    }
}
