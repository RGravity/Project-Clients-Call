using UnityEngine;
using System.Collections;

public class ChoosingPlayer2 : MonoBehaviour {

    void Update()
    {
        if (GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer2 == 0)
        {
            this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.SetActiveRecursively(true);
            this.gameObject.GetComponent<Transform>().GetChild(1).gameObject.SetActive(false);
            this.gameObject.GetComponent<Transform>().GetChild(2).gameObject.SetActive(false);
            this.gameObject.GetComponent<Transform>().GetChild(3).gameObject.SetActive(false);

        }
        else if (GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer2 == 1)
        {
            this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
            this.gameObject.GetComponent<Transform>().GetChild(1).gameObject.SetActiveRecursively(true);
            this.gameObject.GetComponent<Transform>().GetChild(2).gameObject.SetActive(false);
            this.gameObject.GetComponent<Transform>().GetChild(3).gameObject.SetActive(false);

        }
        else if (GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer2 == 2)
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
