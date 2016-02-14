using UnityEngine;
using System.Collections;

public class ArrowMoveScript : MonoBehaviour {

    private GameObject _startButton;
    private GameObject _optionsButton;
    private GameObject _creditsButton;
    private GameObject _howToPlayButton;
    private GameObject _exitButton;
    private GameObject _camera;
    private GameObject _backButton;
    private GameObject _creditScreen;
    private GameObject _controls;
    private GameObject _sounds;
    private GameObject _tutorialText;
    private GameObject _tutorialButton;
    private GameObject _cubeOne;
    private GameObject _cubeTwo;
    private GameObject _cubeThree;
    private GameObject _platform;
    private GameObject _leftArrow;
    private GameObject _rightArrow;
    private GameObject _platform2;
    private GameObject _leftArrow2;
    private GameObject _rightArrow2;
    private GameObject _selectScreen;
    private GameObject _player;
    private GameObject _player2;
    private GameObject _startGame;
    private GameObject _musicSlider;
    private GameObject _sfxSlider;
    private SliderScript1 _slider1;
    private SliderScript2 _slider2;
    private ConfirmScript _confirmScript;
    private ArrowRightScript2 _arrowScript;

    private AudioSource _selectSound;
    private AudioSource _moveSound;






    private bool _moving = false;
    private bool _moving2 = false;
    private bool _movingToOptions = false;
    private bool _movingToHowTo = false;
    private bool _movingToCredits = false;
    private bool _movingToSelection = false;
    private bool _rotationCredits = false;
    private bool _rotationOptions = false;
    private bool _rotationHowto = false;
    private bool _rotationToSelection = false;
    private bool _rotateBack = false;

    private float _degrees = 0;

    void Start()
    {
        this.gameObject.transform.position = new Vector3(1298, 29, 0);
        _startButton = GameObject.FindGameObjectWithTag("StartButton");
        _optionsButton = GameObject.FindGameObjectWithTag("OptionsButton");
        _creditsButton = GameObject.FindGameObjectWithTag("CreditsButton");
        _howToPlayButton = GameObject.FindGameObjectWithTag("HowToPlayButton");
        _exitButton = GameObject.FindGameObjectWithTag("ExitButton");
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
        _backButton = GameObject.FindGameObjectWithTag("BackButton");
        _creditScreen = GameObject.FindGameObjectWithTag("CreditScreen");
        _controls = GameObject.FindGameObjectWithTag("Controls");
        _sounds = GameObject.FindGameObjectWithTag("Sounds");
        _tutorialText = GameObject.FindGameObjectWithTag("TutorialText");
        _cubeOne = GameObject.FindGameObjectWithTag("CubeOne");
        _cubeTwo = GameObject.FindGameObjectWithTag("CubeTwo");
        _cubeThree = GameObject.FindGameObjectWithTag("CubeThree");
        _platform = GameObject.FindGameObjectWithTag("Platform");
        _player = GameObject.FindGameObjectWithTag("Player1");
        _player2 = GameObject.FindGameObjectWithTag("Player2");
        _leftArrow = GameObject.FindGameObjectWithTag("ArrowLeft");
        _rightArrow = GameObject.FindGameObjectWithTag("ArrowRight");
        _selectScreen = GameObject.FindGameObjectWithTag("SelectionScreen");
        _leftArrow2 = GameObject.FindGameObjectWithTag("ArrowLeft2");
        _rightArrow2 = GameObject.FindGameObjectWithTag("ArrowRight2");
        _platform2 = GameObject.FindGameObjectWithTag("Platform2");
        _startGame = GameObject.FindGameObjectWithTag("StartGame");
        _musicSlider = GameObject.FindGameObjectWithTag("MusicSlider");
        _sfxSlider = GameObject.FindGameObjectWithTag("SFXSlider");

        _selectSound = GameObject.FindGameObjectWithTag("DrillFire").GetComponent<AudioSource>();
        _moveSound = GameObject.FindGameObjectWithTag("Selection").GetComponent<AudioSource>();
        _slider1 = FindObjectOfType<SliderScript1>();
        _slider2 = FindObjectOfType<SliderScript2>();
        _confirmScript = FindObjectOfType<ConfirmScript>();
        _arrowScript = FindObjectOfType<ArrowRightScript2>();

    }
    void Update()
    {
        ArrowMovement ();
        MenuSelect();
        GoToSelectedScene();
        CreditScreen();
        HowToScreen();
        OptionsScreen();
        ReturnToMenu();
        OptionsSelect();
        SelectionScreen();
    }

    void GoToSelectedScene()
    {
        if (gameObject.transform.position == new Vector3(1298, 29, 0) && Input.GetButtonDown("FireP1"))
        {
            _rotationToSelection = true;
            _movingToSelection = true;
            _confirmScript.bodyPlayer1 = 0;
            _confirmScript.bodyPlayer2 = 0;
            _selectSound.Play();
           
        }
        if (gameObject.transform.position == new Vector3(1298, -25, 0) && Input.GetButtonDown("FireP1"))
        {
            _movingToHowTo = true;
            _rotationHowto = true;
            _selectSound.Play();
        }
        if (gameObject.transform.position == new Vector3(1298, -79, 0) && Input.GetButtonDown("FireP1"))
        {
            _movingToOptions = true;
            _rotationOptions = true;
            _selectSound.Play();

        }
        if (gameObject.transform.position == new Vector3(1298, -133, 0) && Input.GetButtonDown("FireP1"))
        {
            _movingToCredits = true;
            _rotationCredits = true;
            _selectSound.Play();
        }
        if (gameObject.transform.position == new Vector3(1298, -187, 0) && Input.GetButtonDown("FireP1"))
        {
            Application.Quit();
            _selectSound.Play();
        }

        if ((gameObject.transform.position == new Vector3(266, 1294, -457) && Input.GetButtonDown("FireP1")) || (this.gameObject.transform.position == new Vector3(250, 1294, -457) && Input.GetButtonDown("FireP1")) || (_movingToOptions == true && Input.GetButtonDown("FireP1") && this.gameObject.transform.position == new Vector3(112, 1300, 0)) || (this.gameObject.transform.position == new Vector3(220, 1300, 0) && _movingToHowTo == true && Input.GetButtonDown("FireP1")))
        {
            _rotateBack = true;
            _selectSound.Play();
        }
        if (gameObject.transform.position == new Vector3(150,1294,-457) && Input.GetButtonDown ("FireP1"))
        {
            Application.LoadLevel(3);
            _selectSound.Play();
            _confirmScript.Tutorial = true;

        }
    
    }

    void SelectionScreen()
    {
        if (_rotationToSelection == true)
        {

            _degrees = _degrees - 1;
            _camera.transform.rotation = Quaternion.Euler(_degrees, 90, 0);

            if (_degrees == -45)
            {
                _backButton.transform.position = new Vector3(260, 1294, 0);
                _backButton.transform.rotation = Quaternion.Euler(274.6854f, 90.00016f, 359.6443f);
                _player.transform.position = new Vector3(15,197,28);
                _player.transform.rotation = Quaternion.Euler(90, 270,0);
                _player2.transform.position = new Vector3(15, 197, -30);
                _player2.transform.rotation = Quaternion.Euler(90, 270, 0);
                _player.GetComponent<Transform>().GetChild(0).gameObject.SetActiveRecursively(true);
                _player2.GetComponent<Transform>().GetChild(0).gameObject.SetActiveRecursively(true);
                _leftArrow.transform.position = new Vector3(14, 1322, 309);
                _rightArrow.transform.position = new Vector3(14, 1322, 69);
                _selectScreen.transform.position = new Vector3(-141, 1155, 236);
                _platform.transform.position = new Vector3(143, 1400, 189);
                _platform.transform.rotation = Quaternion.Euler(0,180, 270);
                _platform2.transform.position = new Vector3(143, 1400, -199);
                _platform2.transform.rotation = Quaternion.Euler(0, 180, 270);
                _leftArrow2.transform.position = new Vector3(14, 1322, -79);
                _rightArrow2.transform.position = new Vector3(14, 1322, -319);
                _cubeOne.transform.position = new Vector3(-201, 1113, -370);
                _cubeTwo.transform.position = new Vector3(-1, 1126, 341);
                _cubeThree.transform.position = new Vector3(171, 1045, 276);
                _cubeTwo.transform.rotation = Quaternion.Euler(275, 90, 0);
                _cubeOne.transform.rotation = Quaternion.Euler(50, 60, 0);
                _cubeThree.transform.rotation = Quaternion.Euler(90, 90, -180);
                _startGame.transform.position = new Vector3(200, 1294, 0);
              

            }

            if (_degrees <= -90)
            {
                gameObject.transform.position = new Vector3(150, 1294, -457);
                _arrowScript.PlaySound = true;
                _rotationToSelection = false;
                _camera.transform.rotation = Quaternion.Euler(270, 90, 0);
                _degrees = 270;
            }
        }
    }

    void CreditScreen()
    {
        if (_rotationCredits == true)
        {
            _degrees = _degrees - 1;
            _camera.transform.rotation = Quaternion.Euler(_degrees, 90, 0);

            if (_degrees == -45)
            {
                _backButton.transform.position = new Vector3(266, 1294, -357);
                _backButton.transform.rotation = Quaternion.Euler(274.6854f, 90.00016f, 359.6443f);
                _cubeOne.transform.position = new Vector3(84, 1233, 323);
                _cubeTwo.transform.position = new Vector3(52, 996, -321);
                _cubeThree.transform.position = new Vector3(-99, 999, 326);
                _cubeTwo.transform.rotation = Quaternion.Euler(275, 90, 0);
                _cubeOne.transform.rotation = Quaternion.Euler(50, 60, 0);
                _cubeThree.transform.rotation = Quaternion.Euler(90, 90, -180);
            }
            if (_degrees <= -90)
            {
                gameObject.transform.position = new Vector3(266, 1294, -457);
                _creditScreen.transform.position = new Vector3(383, 1868, 225);
                _rotationCredits = false;
                _camera.transform.rotation = Quaternion.Euler(270, 90, 0);
                _degrees = 270;
                
            }

        }
        
    }

    void OptionsScreen()
    {
        if (_rotationOptions == true)
        {

            _degrees = _degrees - 1;
            _camera.transform.rotation = Quaternion.Euler(_degrees, 90, 0);

            if (_degrees == -45)
            {
                _controls.transform.position = new Vector3(-34, 1300, 200);
                _sounds.transform.position = new Vector3(39, 1300, 200);
                _sfxSlider.transform.position = new Vector3(-10,1200,0);
                _musicSlider.transform.position = new Vector3(-75,1200,0);
                _backButton.transform.position = new Vector3(107, 1300, 0);
                _backButton.transform.rotation = Quaternion.Euler(275, 90, 0);
                _cubeOne.transform.position = new Vector3(-67, 1217, -435);
                _cubeTwo.transform.position = new Vector3(103, 1203, -192);
                _cubeThree.transform.position = new Vector3(121, 805, 215);
                _cubeOne.transform.rotation = Quaternion.Euler(275, 90, 0);
                _cubeTwo.transform.rotation = Quaternion.Euler(50, 60, 0);
                _cubeThree.transform.rotation = Quaternion.Euler(90, 90, -180);
            }

            if (_degrees <= -90)
            {
                 gameObject.transform.position = new Vector3(-34, 1300, 0);
                _rotationOptions = false;
                _camera.transform.rotation = Quaternion.Euler(270, 90, 0);
                _degrees = 270;
            }

        }
    }

    void HowToScreen()
    {
        if (_rotationHowto == true)
        {

            _degrees = _degrees - 1;

            _camera.transform.rotation = Quaternion.Euler(_degrees, 90, 0);


            if (_degrees == -45)
            {
                _backButton.transform.position = new Vector3(220, 1300,0);
                _backButton.transform.rotation = Quaternion.Euler(274.6854f, 90.00016f, 359.6443f);
                _tutorialText.transform.position = new Vector3(-306, 1868, 425);
                _cubeOne.transform.position = new Vector3(-80, 1414, -396);
                _cubeTwo.transform.position = new Vector3(150, 1256, 320);
                _cubeThree.transform.position = new Vector3(-109, 1072, 369);
                _cubeOne.transform.rotation = Quaternion.Euler(60, 20, 3);
                _cubeTwo.transform.rotation = Quaternion.Euler(300, 120, 100);
                _cubeThree.transform.rotation = Quaternion.Euler(67, 15, -180);
            }

            if (_degrees <= -90)
            {
                 gameObject.transform.position = new Vector3(150, 1300, 0);
                _rotationHowto = false;
                _camera.transform.rotation = Quaternion.Euler(270, 90, 0);
                _degrees = 270;
            }

        }
    
    }

    void MenuSelect()
    {

        if (_movingToHowTo == false || _movingToCredits == false || _movingToOptions == false || _movingToSelection == false)
        {
            if (gameObject.transform.position == new Vector3(1298, 29, 0))
            {
                _startButton.transform.position = new Vector3(1183, 0, 243);
                _howToPlayButton.transform.position = new Vector3(1220, -55, 250);
                _creditsButton.transform.position = new Vector3(1220, -165, 250);
                _optionsButton.transform.position = new Vector3(1220, -110, 250);
                _exitButton.transform.position = new Vector3(1220, -220, 250);

            }
            if (gameObject.transform.position == new Vector3(1298, -25, 0))
            {
                _startButton.transform.position = new Vector3(1220, 0, 250);
                _howToPlayButton.transform.position = new Vector3(1183, -55, 243);
                _optionsButton.transform.position = new Vector3(1220, -110, 250);

            }
            if (gameObject.transform.position == new Vector3(1298, -79, 0))
            {
                _howToPlayButton.transform.position = new Vector3(1220, -55, 250);
                _optionsButton.transform.position = new Vector3(1183, -110, 243);
                _creditsButton.transform.position = new Vector3(1220, -165, 250);
            }
            if (gameObject.transform.position == new Vector3(1298, -133, 0))
            {
                _optionsButton.transform.position = new Vector3(1220, -110, 250);
                _creditsButton.transform.position = new Vector3(1183, -160, 243);
                _exitButton.transform.position = new Vector3(1220, -220, 250);
            }
            if (gameObject.transform.position == new Vector3(1298, -187, 0))
            {
                _creditsButton.transform.position = new Vector3(1220, -165, 250);
                _exitButton.transform.position = new Vector3(1183, -217, 243);
            }
        }
    }

    void OptionsSelect()
    {
        if (_movingToSelection == true)
        {
            if (gameObject.transform.position == new Vector3(150, 1294, -457))
            {
                _startGame.transform.position = new Vector3(190, 1194, 0);
                _backButton.transform.position = new Vector3(260, 1294, 0);
            }
            if (gameObject.transform.position == new Vector3(250, 1294, -457))
            {
                _startGame.transform.position = new Vector3(200, 1294, 0);
                _backButton.transform.position = new Vector3(240, 1194, 0);
            }

        }
        if (_movingToOptions == true)
        {
            if (gameObject.transform.position == new Vector3(-34, 1300, 0))
            {
                _controls.transform.position = new Vector3(-34, 1300, 180);
                _sounds.transform.position = new Vector3(39, 1300, 200);
                _slider1.Music = true;
                _slider2.Sound = false;
            }
            if (gameObject.transform.position == new Vector3(39, 1300, 0))
            {
                _controls.transform.position = new Vector3(-34, 1300, 200);
                _sounds.transform.position = new Vector3(39, 1300, 180);
                _backButton.transform.position = new Vector3(107, 1300, 0);
                _slider1.Music = false;
                _slider2.Sound = true;
            }
            if (gameObject.transform.position == new Vector3(112, 1300, 0))
            {
                
                _sounds.transform.position = new Vector3(39, 1300, 200);
                _backButton.transform.position = new Vector3(107, 1200, 0);
                _slider1.Music = false;
                _slider2.Sound = false;
            }
        }
        if (_movingToHowTo == true)
        {
            if (gameObject.transform.position == new Vector3(220, 1300, 0))
            {
                _backButton.transform.position = new Vector3(200, 1200, 0);
            }
        }
    }

    void ArrowMovement ()
    {
        if (_movingToSelection)
        {
            if (Input.GetAxis("Vertical P1") < -0.5f && _moving == false && gameObject.transform.position.x < 250)
            {
                gameObject.transform.position = gameObject.transform.position + new Vector3(100, 0, 0);
                _moveSound.Play();
               
            }

            if (Input.GetAxis("Vertical P1") > 0.5f && _moving2 == false && gameObject.transform.position.x > 150)
            {
               gameObject.transform.position = gameObject.transform.position - new Vector3(100, 0, 0);
                _moveSound.Play();
                
            }
            if (gameObject.transform.position == new Vector3(150, 1294, -457))
            {
                _moving = true;
                _moving2 = true;

                if (Input.GetAxis("Vertical P1") > -0.5f && _moving == true)
                {

                    _moving = false;
                }
                if (Input.GetAxis("Vertical P1") < 0.5f && _moving2 == true)
                {
                    _moving2 = false;
                }

            }
            if (gameObject.transform.position == new Vector3(250, 1294, -457))
            {
                _moving = true;
                _moving2 = true;

                if (Input.GetAxis("Vertical P1") > -0.5f && _moving == true)
                {
                    _moving = false;
                }
                if (Input.GetAxis("Vertical P1") < 0.5f && _moving2 == true)
                {
                    _moving2 = false;
                }
            }
        }
        if (_movingToCredits == true)return;

        if (_movingToHowTo == true)
        {
            if (Input.GetAxis("Vertical P1") < -0.5f && _moving == false && gameObject.transform.position.x < 220)
            {
                gameObject.transform.position = gameObject.transform.position + new Vector3(70, 0, 0);
                _moveSound.Play();
            }

            if (Input.GetAxis("Vertical P1") > 0.5f && _moving2 == false && gameObject.transform.position.x > 150)
            {
                gameObject.transform.position = gameObject.transform.position - new Vector3(70, 0, 0);
                _moveSound.Play();
               
            }
            if (gameObject.transform.position == new Vector3(150, 1300, 0))
            {
                _moving = true;
                _moving2 = true;

                if (Input.GetAxis("Vertical P1") > -0.5f && _moving == true)
                {

                    _moving = false;
                }
                if (Input.GetAxis("Vertical P1") < 0.5f && _moving2 == true)
                {
                    _moving2 = false;
                }

            }
            if (gameObject.transform.position == new Vector3(220, 1300, 0))
            {
                _moving = true;
                _moving2 = true;

                if (Input.GetAxis("Vertical P1") > -0.5f && _moving == true)
                {
                    _moving = false;
                }
                if (Input.GetAxis("Vertical P1") < 0.5f && _moving2 == true)
                {
                    _moving2 = false;
                }
            }
        
        }
        

        if (_movingToOptions == true )
        {
            if (Input.GetAxis("Vertical P1") < -0.5f && _moving == false && gameObject.transform.position.x < 112)
            {
                gameObject.transform.position = gameObject.transform.position + new Vector3(73, 0, 0);
                _moveSound.Play();
            }

            if (Input.GetAxis("Vertical P1") > 0.5f && _moving2 == false && gameObject.transform.position.x > -34 )
            {
                gameObject.transform.position = gameObject.transform.position - new Vector3(73, 0, 0);
                _moveSound.Play();
            }
            if (gameObject.transform.position == new Vector3(-34, 1300, 0))
            {
                _moving = true;
                _moving2 = true;

                if (Input.GetAxis("Vertical P1") > -0.5f && _moving == true)
                {
                    
                    _moving = false;
                }
                if (Input.GetAxis("Vertical P1") < 0.5f && _moving2 == true)
                {
                    _moving2 = false;
                }

            }
            if (gameObject.transform.position == new Vector3(39, 1300, 0))
            {
                _moving = true;
                _moving2 = true;

                if (Input.GetAxis("Vertical P1") > -0.5f && _moving == true)
                {
                    _moving = false;
                }
                if (Input.GetAxis("Vertical P1") < 0.5f && _moving2 == true)
                {
                    _moving2 = false;
                }
            }
            if (gameObject.transform.position == new Vector3(112, 1300, 0))
            {
                _moving = true;
                _moving2 = true;

                if (Input.GetAxis("Vertical P1") > -0.5f && _moving == true)
                {
                    _moving = false;
                }
                if (Input.GetAxis("Vertical P1") < 0.5f && _moving2 == true)
                {
                    _moving2 = false;
                }
            }
        }

        if (_movingToOptions == false || _movingToHowTo == false || _movingToCredits == false || _movingToSelection == false)
        {
            if (Input.GetAxis("Vertical P1") < -0.5f && _moving == false && gameObject.transform.position.y > -187)
            {
                gameObject.transform.position = gameObject.transform.position - new Vector3(0, 54, 0);
                _moveSound.Play();
            }

            if (Input.GetAxis("Vertical P1") > 0.5f && _moving2 == false && gameObject.transform.position.y < 29)
            {
               gameObject.transform.position = gameObject.transform.position + new Vector3(0, 54, 0);
                _moveSound.Play();
            }

            if (gameObject.transform.position == new Vector3(1298, -25, 0))
            {
                _moving = true;
                _moving2 = true;

                if (Input.GetAxis("Vertical P1") > -0.5f && _moving == true)
                {
                    _moving = false;
                }
                if (Input.GetAxis("Vertical P1") < 0.5f && _moving2 == true)
                {
                    _moving2 = false;
                }

            }
            if (gameObject.transform.position == new Vector3(1298, -79, 0))
            {
                _moving = true;
                _moving2 = true;

                if (Input.GetAxis("Vertical P1") > -0.5f && _moving == true)
                {
                    _moving = false;
                }
                if (Input.GetAxis("Vertical P1") < 0.5f && _moving2 == true)
                {
                    _moving2 = false;
                }
            }
            if (gameObject.transform.position == new Vector3(1298, -133, 0))
            {
                _moving = true;
                _moving2 = true;

                if (Input.GetAxis("Vertical P1") > -0.5f && _moving == true)
                {
                    _moving = false;
                }
                if (Input.GetAxis("Vertical P1") < 0.5f && _moving2 == true)
                {
                    _moving2 = false;
                }
            }
            if (gameObject.transform.position == new Vector3(1298, -187, 0))
            {
                _moving = true;
                _moving2 = true;

                if (Input.GetAxis("Vertical P1") > -0.5f && _moving == true)
                {
                    _moving = false;
                }
                if (Input.GetAxis("Vertical P1") < 0.5f && _moving2 == true)
                {
                    _moving2 = false;
                }
            }
        }
    }

    void ReturnToMenu()
    {

        if (_rotateBack == true)
        {

            _degrees = _degrees + 1;
            _camera.transform.rotation = Quaternion.Euler(_degrees, 90, 0);

            if (_degrees == 300)
            {

                _creditScreen.transform.position = new Vector3(383, 2568, 225);
                _controls.transform.position = new Vector3(-75, 2637, 0);
                _sounds.transform.position = new Vector3(81, 2637, 0);
                _backButton.transform.position = new Vector3(206, 1846, -489);
                _tutorialText.transform.position = new Vector3(-306, 2568, 417);
                 gameObject.transform.position = new Vector3(1298, 29, 0);
                _cubeOne.transform.position = new Vector3(1679, -315, -475);
                _cubeTwo.transform.position = new Vector3(1256.42f, 0, 0);
                _cubeThree.transform.position = new Vector3(1312.2f, -214.1f, 463.7f);
                _cubeOne.transform.rotation = Quaternion.Euler(342.8109f, 0.5965576f, 338.0217f);
                _cubeTwo.transform.rotation = Quaternion.Euler(30.00685f, 0, 0);
                _cubeThree.transform.rotation = Quaternion.Euler(20.16795f, 9.03801f, 29.89008f);
                _player.transform.position = new Vector3(15, 3000, 0);
                _player.transform.rotation = Quaternion.Euler(90, 270, 0);
                _player2.transform.position = new Vector3(15, 3000, 0);
                _player2.transform.rotation = Quaternion.Euler(90, 270, 0);
                _leftArrow.transform.position = new Vector3(0, 3000, 200);
                _rightArrow.transform.position = new Vector3(0, 3000, -200);
                _leftArrow2.transform.position = new Vector3(0, 3000, 200);
                _rightArrow2.transform.position = new Vector3(0, 3000, -200);
                _selectScreen.transform.position = new Vector3(-141, 3000, 336);
                _platform.transform.position = new Vector3(200, 3000, 0);
                _platform.transform.rotation = Quaternion.Euler(0, 180, 270);
                _platform2.transform.position = new Vector3(200, 3000, 0);
                _platform2.transform.rotation = Quaternion.Euler(0, 180, 270);
                _startGame.transform.position = new Vector3(150,3000, -457);
                _sfxSlider.transform.position = new Vector3(-16, 5000, 0);
                _musicSlider.transform.position = new Vector3(-90, 5000, 0);
                _player.GetComponent<Transform>().GetChild(1).gameObject.SetActive(false);
                _player.GetComponent<Transform>().GetChild(2).gameObject.SetActive(false);
                _player.GetComponent<Transform>().GetChild(3).gameObject.SetActive(false);
                _player2.GetComponent<Transform>().GetChild(1).gameObject.SetActive(false);
                _player2.GetComponent<Transform>().GetChild(2).gameObject.SetActive(false);
                _player2.GetComponent<Transform>().GetChild(3).gameObject.SetActive(false); 
                _movingToCredits = false;
                _movingToOptions = false;
                _movingToHowTo = false;
                _movingToSelection = false;
                _arrowScript.PlaySound = false;

            }
            if (_degrees == 360)
            {
                _rotateBack = false;
                _camera.transform.rotation = Quaternion.Euler(0, 90, 0);
                _degrees = 0;


            }
        }
    }
}
