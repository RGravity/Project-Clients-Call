using UnityEngine;
using System.Collections;

public class ConfirmScript : MonoBehaviour {

    public int bodyPlayer1 = 0;
    public int bodyPlayer2 = 0;

    public int round = 1;
    private static GameObject _instance;

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
