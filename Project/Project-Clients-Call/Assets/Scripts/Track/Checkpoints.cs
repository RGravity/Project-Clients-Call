using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.ObjectModel;

public class Checkpoints : MonoBehaviour
{
    private bool _checkpointP1Hit = false;
    private bool _checkpointP2Hit = false;

    public bool CheckPointP1Hit { get { return _checkpointP1Hit; } set { _checkpointP1Hit = value; } }
    public bool CheckPointP2Hit { get { return _checkpointP2Hit; } set { _checkpointP2Hit = value; } }
    private AudioSource _checkpointSound;
    private ScoreScript _scoreScript;
    private Player1MoveScript _player1MoveScript;
    private Player2MoveScript _player2MoveScript;

    List<Checkpoints> checkpoints;
    // Use this for initialization
    void Start()
    {
        checkpoints = GameObject.FindObjectsOfType<Checkpoints>().ToList();
        _checkpointSound = GameObject.FindGameObjectWithTag("CheckpointSound").GetComponent<AudioSource>();
        _player1MoveScript = GameObject.FindObjectOfType<Player1MoveScript>();
        _player2MoveScript = GameObject.FindObjectOfType<Player2MoveScript>();
        _scoreScript = GameObject.FindObjectOfType<ScoreScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == _player1MoveScript.gameObject.name)
        {
            _checkpointSound.Play();
            _scoreScript.P1ScoreType = ScoreScript.ScoreType.Checkpoint;
            foreach (Checkpoints checkpoint in checkpoints)
            {
                if (this.gameObject.name == checkpoint.gameObject.name)
                {
                    this.gameObject.GetComponent<BoxCollider>().enabled = false;
                    this.gameObject.GetComponent<MeshRenderer>().enabled = false;

                    string _checkpointNumber = checkpoint.name.Substring(checkpoint.name.Length - 3, 1);
                    List<Checkpoints> checkpointsChecked = checkpoints.Where(c => c.name.Contains(""+_checkpointNumber+"P")).ToList();
                    for (int i = 0; i < checkpointsChecked.Count; i++)
                    {
                        checkpoints.Remove(checkpointsChecked[i]);
                    }
                    _checkpointP1Hit = true;
                    GameObject.Find("CheckPoint" + _checkpointNumber + "P2").GetComponent<Checkpoints>().enabled = false;
                    GameObject.Find("CheckPoint" + _checkpointNumber + "P2").GetComponent<BoxCollider>().enabled = false;
                    break;
                }
            }
        }
        if (other.gameObject.name == _player2MoveScript.gameObject.name)
        {
            _checkpointSound.Play();
            _scoreScript.P2ScoreType = ScoreScript.ScoreType.Checkpoint;
            foreach (Checkpoints checkpoint in checkpoints)
            {
                if (this.gameObject.name == checkpoint.gameObject.name)
                {
                    this.gameObject.GetComponent<BoxCollider>().enabled = false;
                    this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    string _checkpointNumber = checkpoint.name.Substring(checkpoint.name.Length - 3, 1);

                    List<Checkpoints> checkpointsChecked = checkpoints.Where(c => c.name.Contains("" + _checkpointNumber + "P")).ToList();
                    for (int i = 0; i < checkpointsChecked.Count; i++)
                    {
                        checkpoints.Remove(checkpointsChecked[i]);
                    }
                    _checkpointP2Hit = true;
                    GameObject.Find("CheckPoint" + _checkpointNumber + "P1").GetComponent<Checkpoints>().enabled = false;
                    GameObject.Find("CheckPoint" + _checkpointNumber + "P1").GetComponent<BoxCollider>().enabled = false;
                    break;
                    //checkpoints.Remove(checkpoints.Where(c => c.name.Contains("" + _checkpointNumber + "P")).FirstOrDefault());
                }
            }
        }
    }
}