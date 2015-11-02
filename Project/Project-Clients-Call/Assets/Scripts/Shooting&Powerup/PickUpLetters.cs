﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class PickUpLetters : MonoBehaviour {


    private List<string> _pickUpLettersFun = new List<string>() { "F", "U", "N", "I", "E", "F", "I", "T" };
    private List<string> _pickUpLettersUltimate = new List<string>() { "U", "L", "T", "I", "M", "A", "T", "E" };
    private List<string> _pickUpLettersVi = new List<string>() { "V", "I", "R", "A", "C", "E", "R" };
    private List<string> _pickups;

    private GameObject[] _p1Letters;
    private GameObject[] _p2Letters;

    public List<string> PickUp
    {
        get { return _pickups; }
        set { _pickups = value; }
    }
    
	// Use this for initialization
	void Start () {
            int randomPick = Random.Range(0, 2);
            randomPick = 2;
            switch (randomPick)
            {
                case 0:
                    _pickups = _pickUpLettersFun;
                    break;
                case 1:
                    _pickups = _pickUpLettersUltimate;
                    break;
                case 2:
                    _pickups = _pickUpLettersVi;
                    break;
                default:
                    break;
            }

            if (GameObject.FindObjectOfType<Player2MoveScript>().GetComponent<PickUpLetters>().PickUp == null || GameObject.FindObjectOfType<Player1MoveScript>().GetComponent<PickUpLetters>().PickUp == GameObject.FindObjectOfType<Player2MoveScript>().GetComponent<PickUpLetters>().PickUp)
            {
                GameObject.FindObjectOfType<Player2MoveScript>().GetComponent<PickUpLetters>().PickUp = _pickups;
            }
            else if (GameObject.FindObjectOfType<Player1MoveScript>().GetComponent<PickUpLetters>().PickUp == null || GameObject.FindObjectOfType<Player1MoveScript>().GetComponent<PickUpLetters>().PickUp == GameObject.FindObjectOfType<Player2MoveScript>().GetComponent<PickUpLetters>().PickUp)
            {
                GameObject.FindObjectOfType<Player1MoveScript>().GetComponent<PickUpLetters>().PickUp = _pickups;
            }

            //if (GameObject.FindObjectOfType<Player1MoveScript>().GetComponent<PickUpLetters>().PickUp != GameObject.FindObjectOfType<Player2MoveScript>().GetComponent<PickUpLetters>().PickUp && _pickups != null)
            //{
            //    if (_pickups != GameObject.FindObjectOfType<Player2MoveScript>().GetComponent<PickUpLetters>().PickUp)
            //    {
            //        if (GameObject.FindObjectOfType<Player2MoveScript>().GetComponent<PickUpLetters>().PickUp != null)
            //        {
            //            _pickups = GameObject.FindObjectOfType<Player2MoveScript>().GetComponent<PickUpLetters>().PickUp;
            //        }
            //   }
            //    else if (_pickups != GameObject.FindObjectOfType<Player1MoveScript>().GetComponent<PickUpLetters>().PickUp)
            //    {
            //        if (GameObject.FindObjectOfType<Player1MoveScript>().GetComponent<PickUpLetters>().PickUp != null)
            //        {
            //            _pickups = GameObject.FindObjectOfType<Player1MoveScript>().GetComponent<PickUpLetters>().PickUp;
            //        }
            //    }
            //}

            GameObject.FindObjectOfType<TrackBuildScript>().PuzzleWord = _pickups;

            _p1Letters = GameObject.FindGameObjectsWithTag("LettersP1");
            _p2Letters = GameObject.FindGameObjectsWithTag("LettersP2");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        if (_pickups.Contains(other.name) && this.gameObject.transform.name == GameObject.FindObjectOfType<PowerUpScriptP1>().transform.name)
        {
            if (_pickups.Contains(other.name))
            {
                //if (_pickups ==_pickUpLettersFun )
                //{
                //    int i = 0;
                //    foreach (GameObject text in _p1Letters)
                //    {
                //        text.GetComponent<Text>().text = _pickups[i];
                //        i++;
                //    }
                //}
                //if (_pickups == _pickUpLettersUltimate)
                //{
                //    int i = 0;
                //    foreach (GameObject text in _p1Letters)
                //    {
                //        text.GetComponent<Text>().text = _pickups[i];
                //        i++;
                //    }
                //}
                //if (_pickups == _pickUpLettersVi)
                //{
                //    int i = 0;
                //    foreach (GameObject text in _p1Letters)
                //    {
                //        text.GetComponent<Text>().text = _pickups[i];
                //        i++;
                //    }
                //    _p1Letters.LastOrDefault().GetComponent<Text>().text = "!";
                //}
                GameObject.FindObjectOfType<Player1MoveScript>().GetComponent<PowerUpScriptP1>().PickedUpP1.Add(this.gameObject.name);
                string needToRemove = _pickups.Where(p => p.ToString() == other.name).FirstOrDefault();
                _pickups.Remove(needToRemove);
               
                if (_pickups.Count == 0)
                {
                    GameObject.FindObjectOfType<ConfirmScript>().SavedP1Score =+ 200;
                }
            }
            Destroy(other.gameObject);
        }
        if (_pickups.Contains(other.name) && this.gameObject.transform.name == GameObject.FindObjectOfType<PowerUpScriptP2>().transform.name)
        {
            if (_pickups.Contains(other.name))
            {
                //if (_pickups == _pickUpLettersFun)
                //{
                //    int i = 0;
                //    foreach (GameObject text in _p1Letters)
                //    {
                //        text.GetComponent<Text>().text = _pickups[i];
                //        i++;
                //    }
                //}
                //if (_pickups == _pickUpLettersUltimate)
                //{
                //    int i = 0;
                //    foreach (GameObject text in _p1Letters)
                //    {
                //        text.GetComponent<Text>().text = _pickups[i];
                //        i++;
                //    }
                //}
                //if (_pickups == _pickUpLettersVi)
                //{
                //    int i = 0;
                //    foreach (GameObject text in _p1Letters)
                //    {
                //        text.GetComponent<Text>().text = _pickups[i];
                //        i++;
                //    }
                //    _p1Letters.Last().GetComponent<Text>().text = "!";
                //}
                GameObject.FindObjectOfType<Player2MoveScript>().GetComponent<PowerUpScriptP2>().PickedUpP2.Add(this.gameObject.name);
                //_pickups.Remove(other.name);
                string needToRemove = _pickups.Where(p => p.ToString() == other.name).FirstOrDefault();
                _pickups.Remove(needToRemove);
                if (_pickups.Count == 0)
                {
                    GameObject.FindObjectOfType<ConfirmScript>().SavedP2Score = +200;
                }
            }
            Destroy(other.gameObject);
        }
    }
   
}
