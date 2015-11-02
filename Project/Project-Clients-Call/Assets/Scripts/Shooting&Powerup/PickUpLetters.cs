using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class PickUpLetters : MonoBehaviour {


    private List<string> _pickUpLettersFun = new List<string>() { "F", "U", "N", "I", "E", "F", "I", "T" };
    private List<string> _pickUpLettersUltimate = new List<string>() { "U", "L", "T", "I", "M", "A", "T", "E" };
    private List<string> _pickUpLettersVi = new List<string>() { "V", "I", "R", "A", "C", "E", "R" };
    private List<string> _pickups;
    private string _pickFun;
    private string _pickUltimate;
    private string _pickVi;
    private string _pickedWord;

    private GameObject[] _p1Letters;
    private GameObject[] _p2Letters;

    public List<string> PickUp
    {
        get { return _pickups; }
        set { _pickups = value; }
    }
    
	// Use this for initialization
	void Start () {
            int randomPick = Random.Range(0, 3);
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
            _pickedWord = string.Join("", _pickups.ToArray());
            _pickFun = string.Join("", _pickUpLettersFun.ToArray());
            _pickUltimate = string.Join("", _pickUpLettersUltimate.ToArray());
            _pickVi = string.Join("", _pickUpLettersVi.ToArray());
            _p1Letters = GameObject.FindGameObjectsWithTag("LettersP1");
            _p2Letters = GameObject.FindGameObjectsWithTag("LettersP2");
            _p1Letters = _p1Letters.OrderBy(c => c.name).ToArray();
            _p2Letters = _p2Letters.OrderBy(c => c.name).ToArray();
            if (_pickedWord == _pickVi)
            {
                _p1Letters.LastOrDefault().GetComponent<Text>().text = "!";
                _p2Letters.LastOrDefault().GetComponent<Text>().text = "!";
            }
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
                if (_pickedWord == _pickFun)
                {
                    char[] charword = _pickedWord.ToCharArray();
                    for (int i = 0; i < _pickedWord.Length; i++)
                    {
                        if (other.name.ToCharArray().FirstOrDefault() == charword[i])
                        {
                            if (_p1Letters[i].GetComponent<Text>().text == other.name)
                            {
                                continue;
                            }
                            _p1Letters[i].GetComponent<Text>().text = other.name;
                            break;
                        }
                    }
                }
                if (_pickedWord == _pickUltimate)
                {
                    char[] charword = _pickedWord.ToCharArray();
                    for (int i = 0; i < _pickedWord.Length; i++)
                    {
                        if (other.name.ToCharArray().FirstOrDefault() == charword[i])
                        {
                            if (_p1Letters[i].GetComponent<Text>().text == other.name)
                            {
                                continue;
                            }
                            _p1Letters[i].GetComponent<Text>().text = other.name;
                            break;
                        }
                    }
                }
                if (_pickedWord == _pickVi)
                {
                    char[] charword = _pickedWord.ToCharArray();
                    for (int i = 0; i < _pickedWord.Length; i++)
                    {
                        if (other.name.ToCharArray().FirstOrDefault() == charword[i])
                        {
                            if (_p1Letters[i].GetComponent<Text>().text == other.name)
                            {
                                continue;
                            }
                            _p1Letters[i].GetComponent<Text>().text = other.name;
                            break;
                        }
                    }
                }
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
                if (_pickedWord == _pickFun)
                {
                    char[] charword = _pickedWord.ToCharArray();
                    for (int i = 0; i < _pickedWord.Length; i++)
                    {
                        if (other.name.ToCharArray().FirstOrDefault() == charword[i])
                        {
                            if (_p2Letters[i].GetComponent<Text>().text == other.name)
                            {
                                continue;
                            }
                            _p2Letters[i].GetComponent<Text>().text = other.name;
                            break;
                        }
                    }
                }
                if (_pickedWord == _pickUltimate)
                {
                    char[] charword = _pickedWord.ToCharArray();
                    for (int i = 0; i < _pickedWord.Length; i++)
                    {
                        if (other.name.ToCharArray().FirstOrDefault() == charword[i])
                        {
                            if (_p2Letters[i].GetComponent<Text>().text == other.name)
                            {
                                continue;
                            }
                            _p2Letters[i].GetComponent<Text>().text = other.name;
                            break;
                        }
                    }
                }
                if (_pickedWord == _pickVi)
                {
                    char[] charword = _pickedWord.ToCharArray();
                    for (int i = 0; i < _pickedWord.Length; i++)
                    {
                        if (other.name.ToCharArray().FirstOrDefault() == charword[i])
                        {
                            if (_p2Letters[i].GetComponent<Text>().text == other.name)
                            {
                                continue;
                            }
                            _p2Letters[i].GetComponent<Text>().text = other.name;
                            break;
                        }
                    }
                }
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
