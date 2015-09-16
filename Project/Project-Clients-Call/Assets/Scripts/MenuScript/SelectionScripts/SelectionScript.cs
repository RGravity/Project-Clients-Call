using UnityEngine;
using System.Collections;

public class SelectionScript : MonoBehaviour {

    private bool _moving = false;
    private bool _movingLeft = false;
    private bool _movingRight = false;

	// Use this for initialization
	void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        Selection();
        NextChoice();
	}

    void NextChoice()
    {
        if (_movingRight == true)
        {
            if (this.transform.position.z <= 50 && this.transform.position.z >= 10)
            {
                this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.SetActiveRecursively(true);
                this.gameObject.GetComponent<Transform>().GetChild(1).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(2).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(3).gameObject.SetActive(false);
                
            }
            if (this.transform.position.z >= 50)
            {
                this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(1).gameObject.SetActiveRecursively(true);
                this.gameObject.GetComponent<Transform>().GetChild(2).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(3).gameObject.SetActive(false);
                
            }
            if (this.transform.position.z >= 90)
            {

                this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(1).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(2).gameObject.SetActiveRecursively(true);
                this.gameObject.GetComponent<Transform>().GetChild(3).gameObject.SetActive(false);
                
            }
            if (this.transform.position.z >= 130)
            {
                this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(1).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(2).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(3).gameObject.SetActiveRecursively(true);
                

            }
            
        }
        if (_movingLeft == true)
        {
            if (this.transform.position.z <= 50 && this.transform.position.z >= 10)
            {
                this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.SetActiveRecursively(true);
                this.gameObject.GetComponent<Transform>().GetChild(1).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(2).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(3).gameObject.SetActive(false);
                
            }
           
            if (this.transform.position.z >= 50)
            {
                this.gameObject.GetComponent <Transform>().GetChild (0).gameObject.SetActive (false);
                this.gameObject.GetComponent<Transform>().GetChild(1).gameObject.SetActiveRecursively(true);
                this.gameObject.GetComponent<Transform>().GetChild(2).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(3).gameObject.SetActive(false);
                
            }
            if (this.transform.position.z >= 90)
            {
                this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(1).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(2).gameObject.SetActiveRecursively(true);
                this.gameObject.GetComponent<Transform>().GetChild(3).gameObject.SetActive(false);
               
            }
            if (this.transform.position.z >= 130)
            {
                this.gameObject.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(1).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(2).gameObject.SetActive(false);
                this.gameObject.GetComponent<Transform>().GetChild(3).gameObject.SetActiveRecursively(true);
                

            }
           
        }
        
    }

    void Selection()
    {
        if (this.transform.position == new Vector3(15, 197, 30) || this.transform.position.z == 41)
        {
            _moving = true;
        }

        if (this.transform.position == new Vector3(15, 3000, 0))
        {
            _moving = false;
        }
        if (_moving == true)
        {
            if (Input.GetAxis("Horizontal P1") < -0.5f)
            {
                _moving = false;
                _movingLeft = true;

            }
            else if (Input.GetAxis("Horizontal P1") > 0.5f)
            {
                _moving = false;
                _movingRight = true;
            }


        }
        if (_movingLeft == true)
        {
            this.gameObject.transform.position = this.gameObject.transform.position + new Vector3(0, 0, 1);

            if (this.gameObject.transform.position == new Vector3 (15,197,70) || this.gameObject.transform.position.z == 0)
            {
                GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer1 = 1;
                

                _moving = true;
                _movingLeft = false;

            }

            else if (this.gameObject.transform.position == new Vector3(15, 197, 110) || this.gameObject.transform.position.z == 0)
            {
                GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer1 = 2;
                

                _moving = true;
                _movingLeft = false;
            }

            else if (this.gameObject.transform.position == new Vector3(15, 197, 150) || this.gameObject.transform.position.z == 0)
            {
                GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer1 = 3;
                

                _moving = true;
                _movingLeft = false;
            }
            else if (this.gameObject.transform.position.z > 170)
            {
                this.gameObject.transform.position = new Vector3(15, 197, 10);
             
            }
            else if (this.gameObject.transform.position == new Vector3(15, 197, 30))
            {
                GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer1 = 0;
               

                _moving = true;
                _movingLeft = false;

            }
        }

        if (_movingRight == true)
        {
            
            this.gameObject.transform.position = this.gameObject.transform.position - new Vector3(0, 0, 1);

         
            if (this.gameObject.transform.position == new Vector3(15, 197, 110) || this.gameObject.transform.position.z == 0)
            {
                GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer1 = 2;
                
                _moving = true;
                _movingRight = false;
            }

            else if (this.gameObject.transform.position == new Vector3(15, 197, 70) || this.gameObject.transform.position.z == 0)
            {

                GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer1 = 2;
               

                _moving = true;
                _movingRight = false;

               
            }
            else if (this.gameObject.transform.position.z < 10)
            {
                this.gameObject.transform.position = new Vector3(15, 197, 170);
            }
            else  if (this.gameObject.transform.position == new Vector3(15, 197, 150))
            {
                GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer1 = 3;
                

                _moving = true;
                _movingRight = false;

                
            }
            else if (this.gameObject.transform.position == new Vector3(15, 197, 30))
            {
                GameObject.FindObjectOfType<ConfirmScript>().bodyPlayer1 = 0;
               

                _moving = true;
                _movingRight = false;

                
            }

            
            
        }
    
    }
}
