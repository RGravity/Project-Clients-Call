using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialScript : MonoBehaviour 
{
    private float _speedP1 = 0;

    private bool _intro = false;
    private bool _checkpoint = false;
    private bool _wall = false;
    private bool _superwall = false;
    private bool _speedup = false;
    private bool _coin = false;
    private bool _fire = false;
    private bool _fireWall = false;
    private bool _ramp = false;
    private bool _shield = false;
    private bool _twister = false;
    private bool _end = false;
    private bool _minimap = false;
    private bool _inventory = false;
    private bool _powerUp = false;
    private bool _letter = false;
    private bool _coolDown = false;

   

    public bool Fire {get { return _fire; }set { _fire = value; }}
    public bool Wall { get { return _wall; } set { _wall = value; } }
    public bool Checkpoint { get { return _checkpoint; } set { _checkpoint = value; } }
    public bool Superwall { get { return _superwall; } set { _superwall = value; } }
    public bool Speedup { get { return _speedup; } set { _speedup = value; } }
    public bool Coin { get { return _coin; } set { _coin = value; } }
    public bool Firewall { get { return _fireWall; } set { _fireWall = value; } }
    public bool Ramp { get { return _ramp; } set { _ramp = value; } }
    public bool Shield { get { return _shield; } set { _shield = value; } }
    public bool Twister { get { return _twister; } set { _twister = value; } }
    public bool End { get { return _end; } set { _end = value; } }
    public bool PowerUp { get { return _powerUp; } set { _powerUp = value; } }
    public bool Letter { get { return _letter; } set { _letter = value; } }

    
	// Use this for initialization
	void Awake ()
    {
        GameObject.Find("Intro").GetComponent<Image>().enabled = true;
        _speedP1 = GameObject.FindObjectOfType<Player1LevelScript>().Speed;
        Time.timeScale = 0;
        _intro = true;
	}

    void Update()
    {

        Tutorial();
    }

    void Tutorial()
    {

        if (_intro == true && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0)))
        {
            GameObject.Find("Intro").GetComponent<Image>().enabled = false;
            _intro = false;
            Time.timeScale = 1;
        }

        if (_minimap == true)
        {

            GameObject.Find("Minimap").GetComponent<Image>().enabled = true;
            Time.timeScale = 0;
            
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                GameObject.Find("Minimap").GetComponent<Image>().enabled = false;
                _minimap = false;
                Time.timeScale = 1;
            }
        }

        if (_inventory == true)
        {

            GameObject.Find("Inventory").GetComponent<Image>().enabled = true;

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                GameObject.Find("Inventory").GetComponent<Image>().enabled = false;
                Time.timeScale = 1;
                _inventory = false;
               
            }
        }

        if (_powerUp == true)
        {
            GameObject.Find ("Powerup").GetComponent<Image>().enabled = true;
            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                GameObject.Find("Powerup").GetComponent<Image>().enabled = false;
                _powerUp = false;
                _inventory = true;
            }
        }
        

        if (_fire == true)
        {
            GameObject.Find("Fire").GetComponent<Image>().enabled = true;
            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                GameObject.Find("Fire").GetComponent<Image>().enabled = false;
                Time.timeScale = 1;
                _fire = false;
                _coolDown = true;
            }
        }
        
        if (_wall == true)
        {
            GameObject.Find("Wall").GetComponent<Image>().enabled = true;
            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                GameObject.Find("Wall").GetComponent<Image>().enabled = false;
                _wall = false;
                _fire = true;
                
            }
        }
        
        if (_superwall == true)
        {
            GameObject.Find("SuperWall").GetComponent<Image>().enabled = true;
            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                GameObject.Find("SuperWall").GetComponent<Image>().enabled = false;
                Time.timeScale = 1;
                _superwall = false;
            }
        }
        
        if (_coin == true)
        {
            GameObject.Find("Coin").GetComponent<Image>().enabled = true;
            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                GameObject.Find("Coin").GetComponent<Image>().enabled = false;
                Time.timeScale = 1;
                _coin = false;
            }
        }
        
        
        if (_fireWall == true)
        {
            GameObject.Find("Firewall").GetComponent<Image>().enabled = true;
            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                GameObject.Find("Firewall").GetComponent<Image>().enabled = false;
                Time.timeScale = 1;
                _fireWall = false;
            }
        }

        if (_checkpoint == true)
        {
            GameObject.Find("Checkpoint").GetComponent<Image>().enabled = true;
            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                GameObject.Find("Checkpoint").GetComponent<Image>().enabled = false;
                _checkpoint = false;
                _minimap = true;
            }
        }

        if (_shield == true)
        {
            GameObject.Find("ShieldUp").GetComponent<Image>().enabled = true;
            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                GameObject.Find("ShieldUp").GetComponent<Image>().enabled = false;
                Time.timeScale = 1;
                _shield = false;
            }
        }

        if (_twister == true)
        {
            GameObject.Find("Twister").GetComponent<Image>().enabled = true;
            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                GameObject.Find("Twister").GetComponent<Image>().enabled = false;
                Time.timeScale = 1;
                _twister = false;
            }
        }

        if (_speedup == true)
        {
            GameObject.Find("Speedup").GetComponent<Image>().enabled = true;
            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                GameObject.Find("Speedup").GetComponent<Image>().enabled = false;
                Time.timeScale = 1;
                _speedup = false;
            }
        }

        if (_ramp == true)
        {
            GameObject.Find("Ramp").GetComponent<Image>().enabled = true;
            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                GameObject.Find("Ramp").GetComponent<Image>().enabled = false;
                Time.timeScale = 1;
                _ramp = false;
            }
        }

        if (_letter == true)
        {
            GameObject.Find("Letter").GetComponent<Image>().enabled = true;
            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                GameObject.Find("Letter").GetComponent<Image>().enabled = false;
                Time.timeScale = 1;
                _letter = false;
            }
        }
        if (_coolDown == true)
        {
            GameObject.Find("Cooldown").GetComponent<Image>().enabled = true;
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                GameObject.Find("Cooldown").GetComponent<Image>().enabled = false;
                Time.timeScale = 1;
                _coolDown = false;
            }

        }

        if (_end == true)
        {
            GameObject.Find("End").GetComponent<Image>().enabled = true;
            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                GameObject.Find("End").GetComponent<Image>().enabled = false;
                Time.timeScale = 1;
                _end = false;
                GameObject.FindObjectOfType<PauseScript>().backToMenu = true;

            }
        }
    
    }

}
