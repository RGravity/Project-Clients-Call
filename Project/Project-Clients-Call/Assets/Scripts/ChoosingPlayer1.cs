using UnityEngine;
using System.Collections;

public class ChoosingPlayer1 : MonoBehaviour {

    private ConfirmScript _confirmScript;

    void Start()
    {
        _confirmScript = GameObject.FindObjectOfType<ConfirmScript>();
    }

	// Update is called once per frame
	void Update () 
    {
        if (_confirmScript != null)
        {
           
            if (_confirmScript.bodyPlayer1 == 0)
            {
                this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.SetActiveRecursively(true);
                this.gameObject.GetComponent<Transform>().GetChild(1).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(2).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(3).gameObject.SetActive(false);

            }
            else if (_confirmScript.bodyPlayer1 == 1)
            {
                this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(1).gameObject.SetActiveRecursively(true);
                this.gameObject.GetComponent<Transform>().GetChild(2).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(3).gameObject.SetActive(false);

            }
            else if (_confirmScript.bodyPlayer1 == 2)
            {
                this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(1).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(2).gameObject.SetActiveRecursively(true);
                this.gameObject.GetComponent<Transform>().GetChild(3).gameObject.SetActive(false);
            }
            else
            {
                this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(1).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(2).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(3).gameObject.SetActiveRecursively(true);
            } 
        }

	}

}
