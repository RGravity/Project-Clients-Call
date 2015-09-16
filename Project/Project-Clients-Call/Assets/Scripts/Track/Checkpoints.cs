using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.ObjectModel;

public class Checkpoints : MonoBehaviour
{

    List<Checkpoints> checkpoints;
    // Use this for initialization
    void Start()
    {
        checkpoints = GameObject.FindObjectsOfType<Checkpoints>().ToList();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == GameObject.FindObjectOfType<Player1MoveScript>().gameObject.name)
        {
            GameObject.FindGameObjectWithTag("CheckpointSound").GetComponent<AudioSource>().Play();
            GameObject.FindObjectOfType<ScoreScript>().P1ScoreType = ScoreScript.ScoreType.Checkpoint;
            foreach (Checkpoints checkpoint in checkpoints)
            {
                if (this.gameObject.name == checkpoint.gameObject.name)
                {
                    Player1LevelScript p1 = GameObject.FindObjectOfType<Player1LevelScript>();
                    this.gameObject.GetComponent<BoxCollider>().enabled = false;
                    this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    p1.StopSpeed = true;
                    //p1.SlowSpeed = true;
                    p1.StopTime = Time.time;
                    //checkpoints.Remove(checkpoints.Where(c => c.name == checkpoint.gameObject.name).FirstOrDefault());

                    //if (checkpoint.gameObject.name.Substring(name.Length - 3, 1) == "1")
                    //{
                    //    checkpoints.Remove(checkpoints.Where(c => c.name.Contains("P2")).FirstOrDefault());

                    //}
                    string _checkpointNumber = checkpoint.name.Substring(checkpoint.name.Length - 3, 1);
                    List<Checkpoints> checkpointsChecked = checkpoints.Where(c => c.name.Contains(""+_checkpointNumber+"P")).ToList();
                    for (int i = 0; i < checkpointsChecked.Count; i++)
                    {
                        checkpoints.Remove(checkpointsChecked[i]);
                    }
                    GameObject.Find("CheckPoint" + _checkpointNumber + "P2").GetComponent<Checkpoints>().enabled = false;
                    GameObject.Find("CheckPoint" + _checkpointNumber + "P2").GetComponent<BoxCollider>().enabled = false;
                    break;
                }
            }
        }
        if (other.gameObject.name == GameObject.FindObjectOfType<Player2MoveScript>().gameObject.name)
        {
            GameObject.FindGameObjectWithTag("CheckpointSound").GetComponent<AudioSource>().Play();
            GameObject.FindObjectOfType<ScoreScript>().P2ScoreType = ScoreScript.ScoreType.Checkpoint;
            foreach (Checkpoints checkpoint in checkpoints)
            {
                if (this.gameObject.name == checkpoint.gameObject.name)
                {
                    Player2LevelScript p2 = GameObject.FindObjectOfType<Player2LevelScript>();
                    this.gameObject.GetComponent<BoxCollider>().enabled = false;
                    this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    p2.StopSpeed = true;
                    //p2.SlowSpeed = true;
                    p2.StopTime = Time.time;


                    //checkpoints.Remove(checkpoints.Where(c => c.name == checkpoint.gameObject.name).FirstOrDefault());

                    //if (checkpoint.gameObject.name.Substring(name.Length - 3, 1) == "1")
                    //{
                    //    checkpoints.Remove(checkpoints.Where(c => c.name.Contains("P1")).FirstOrDefault());

                    //}
                    string _checkpointNumber = checkpoint.name.Substring(checkpoint.name.Length - 3, 1);

                    List<Checkpoints> checkpointsChecked = checkpoints.Where(c => c.name.Contains("" + _checkpointNumber + "P")).ToList();
                    for (int i = 0; i < checkpointsChecked.Count; i++)
                    {
                        checkpoints.Remove(checkpointsChecked[i]);
                    }
                    GameObject.Find("CheckPoint" + _checkpointNumber + "P1").GetComponent<Checkpoints>().enabled = false;
                    GameObject.Find("CheckPoint" + _checkpointNumber + "P1").GetComponent<BoxCollider>().enabled = false;
                    break;
                    //checkpoints.Remove(checkpoints.Where(c => c.name.Contains("" + _checkpointNumber + "P")).FirstOrDefault());
                }
            }
        }
    }
}