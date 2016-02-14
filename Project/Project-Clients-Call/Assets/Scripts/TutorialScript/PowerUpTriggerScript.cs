﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PowerUpTriggerScript : MonoBehaviour {

    private GameObject _textBox;
    private GameObject _textBox2;
    // Use this for initialization
    void Start()
    {
        _textBox = GameObject.Find("WallText");
        _textBox2 = GameObject.Find("PowerUpText");
    }


    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player 1")
        {
            _textBox.GetComponent<Image>().enabled = false;
            _textBox2.GetComponent<Image>().enabled = true;
        }
    }
}