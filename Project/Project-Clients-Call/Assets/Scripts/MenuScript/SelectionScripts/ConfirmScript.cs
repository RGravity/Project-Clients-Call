using UnityEngine;
using System.Collections;

public class ConfirmScript : MonoBehaviour {

    public int bodyPlayer1 = 0;
    public int bodyPlayer2 = 0;

    public int round = 1;
	void Start () 
    {
        DontDestroyOnLoad(this);
	}
}
