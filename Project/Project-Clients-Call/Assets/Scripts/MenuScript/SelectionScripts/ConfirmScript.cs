using UnityEngine;
using System.Collections;

public class ConfirmScript : MonoBehaviour {

    public int bodyPlayer1 = 0;
    public int bodyPlayer2 = 0;

    private int _p1Score = 0;
    private int _p2Score = 0;

    private int _round = 1;
    private static GameObject _instance;
    private bool _tutorial = false;

    private bool _doTutorial = true;

    public bool Tutorial { get { return _tutorial; } set { _tutorial = value; } }
    public int SavedP1Score { get { return _p1Score; } set { _p1Score = value; } }
    public int SavedP2Score { get { return _p2Score; } set { _p2Score = value; } }
    public int Round { get { return _round; } set { _round = value; } }

    public bool DoTutorial { get { return _doTutorial; } set { _doTutorial = value; }  }

    void Awake()
    {
        //if we don't have an [_instance] set yet
        if (!_instance)
            _instance = this.gameObject;
        //otherwise, if we do, kill this thing
        else
       
            Destroy(this.gameObject);
            
            
       

        DontDestroyOnLoad(this.gameObject);
    }
}
