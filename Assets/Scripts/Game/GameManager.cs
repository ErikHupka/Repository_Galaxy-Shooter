using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject PauseMenuPanel;
    public GameObject GameOverPanel;
    public bool isGameOver = false;
    private bool isPauseMenu = false;
    [SerializeField]
    private GameObject Instructions;
    private Animator PauseAnimator;
    private bool GameIsRunning = false;
    [SerializeField]
    private Asteroid Asteroid;
    private int GameOver_ButtonSelected = -1;
    private int PauseMenu_ButtonSelected = -1;
    [SerializeField]
    private GameObject[] GameOverButtons = new GameObject[2];
    public GameObject[] PauseMenuButtons = new GameObject[3];
    private bool GameOver_FirstPress = false;
    public AudioSource BackGround_Music;
    public Options Options;

    private Player Player = new Player();
    public GameObject Leaderboard;
    public Leaderboard Leaderboard_Script; 

    public GameObject HighScore_Input;
    public Text GameOver_HighScore;
    public InputField PlayerName;

    public GameData GameData = new GameData();
    public int GameDifficulty;

    public int score;
    public GameObject Player1;

    private Player Player_Script;

    OptionsHolder optionsHolder;


    private void Awake()
    {
        optionsHolder = FindObjectOfType<OptionsHolder>();
    }

    private void Start()
    {
        GameDifficulty = GameData.GameDifficulty;
        PauseAnimator = GameObject.Find("Pause_Menu_Panel").GetComponent<Animator>();
        PauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime; //preventing from pausing PauseMenu

        Player_Script = Player1.GetComponent<Player>();
        Leaderboard_Script = Leaderboard.GetComponent<Leaderboard>();

        //Options = JsonUtility.FromJson<Options>(File.ReadAllText(Application.persistentDataPath + "/Options.json"));
        Options = optionsHolder.GetOptions();

        BackGround_Music.volume = Options.Volume;
    }

    private void Update()
    {
        PauseMenu_Activation();
        if (isPauseMenu == true && isGameOver == false)
        {
            PauseMenu_Buttons();
        }

        if (isGameOver == true)
        {
            GameOver_Button();
            if (Input.GetKeyDown(KeyCode.R))
            {
                Restart_Button();
            }
        }
    }

    public void GameOver()
    {
        HighScore_Input.SetActive(true);
        GameOver_HighScore.text = "Your score: " + Player_Script.score.ToString();
        PlayerName.text = GameData.Name;
    }

    public void SaveHighScore()
    {
        switch (GameDifficulty)
        {
            case 1:
                Leaderboard_Script.Arcade_Beginner_CheckForHighScore(Player_Script.score, PlayerName.text);
                break;
            case 2:
                Leaderboard_Script.Arcade_Easy_CheckForHighScore(Player_Script.score, PlayerName.text);
                break;
            case 3:
                Leaderboard_Script.Arcade_Medium_CheckForHighScore(Player_Script.score, PlayerName.text);
                break;
            case 4:
                Leaderboard_Script.Arcade_Hard_CheckForHighScore(Player_Script.score, PlayerName.text);
                break;
            case 5:
                Leaderboard_Script.Arcade_UltraHard_CheckForHighScore(Player_Script.score, PlayerName.text);
                break;
            case 10:
                Leaderboard_Script.Challenge_CheckForHighScore(Player_Script.score, PlayerName.text);
                break;
            default:
                break;
        }
        GameData.Name = PlayerName.text;
        HighScore_Input.SetActive(false);
        GameOverPanel.SetActive(true);
        isGameOver = true;
    }

    public void Restart_Button()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Restart_Button_Number()
    {
        GameOver_ButtonSelected = 0;
        PauseMenu_ButtonSelected = 1;
    }

    public void BackToMainMenu_Button()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }

    public void BackToMainMenu_Button_Number()
    {
        GameOver_ButtonSelected = 1;
        PauseMenu_ButtonSelected = 2;
    }

    public void ButtonEffects_Down(GameObject Button)
    {
        Button.GetComponent<Image>().color = new Color32(20, 120, 160, 255);
        Button.transform.localScale = new Vector2(1.05f, 1.05f);
    }

    public void ButtonEffect_Up(GameObject Button)
    {
        Button.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        Button.transform.localScale = new Vector2(1, 1);
    }

    public void ButtonEffect_Up_All()
    {
        foreach (GameObject Buttons in GameOverButtons)
        {
            ButtonEffect_Up(Buttons);
        }

        foreach (GameObject Buttons in PauseMenuButtons)
        {
            ButtonEffect_Up(Buttons);
        }
    }

    private void Error()
    {
    }

    public void GameOver_Button()
    {
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && GameOver_ButtonSelected < GameOverButtons.Length -1)
        {
            GameOver_ButtonSelected++;
        }

        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && GameOver_ButtonSelected > 0)
        {
            GameOver_ButtonSelected--;
        }

        switch (GameOver_ButtonSelected)
        {
            case 0:
                ButtonEffect_Up_All();
                ButtonEffects_Down(GameOverButtons[GameOver_ButtonSelected]);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Restart_Button();
                }
                return;
            case 1:
                ButtonEffect_Up_All();
                ButtonEffects_Down(GameOverButtons[GameOver_ButtonSelected]);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    BackToMainMenu_Button();
                }
                return;
            default:
                foreach (GameObject Button in GameOverButtons)
                {
                    ButtonEffect_Up(Button);
                }
                return;

        }
    }

    public void PauseMenu_Activation()
    {
        if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) && isGameOver == false && isPauseMenu == false)
        {
            PauseMenuPanel.SetActive(true);
            PauseAnimator.SetBool("isPaused", true);
            Time.timeScale = 0;
            isPauseMenu = true;
            if (Instructions.activeSelf)
            {
                Instructions.SetActive(false);
            }
            return;
        }

        if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) && isGameOver == false && isPauseMenu == true)
        {
            PauseMenuPanel.SetActive(false);
            isPauseMenu = false;
            Time.timeScale = 1;
            PauseMenu_ButtonSelected = -1;
            if (Asteroid.GameIsRunning == false)
            {
                Instructions.SetActive(true);
            }
            return;
        }
    }

    public void PauseMenu_Buttons()
    {
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && PauseMenu_ButtonSelected < PauseMenuButtons.Length -1)
        {
            PauseMenu_ButtonSelected++;
        }

        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && PauseMenu_ButtonSelected > 0)
        {
            PauseMenu_ButtonSelected--;
        }

        switch (PauseMenu_ButtonSelected)
        {
            case 0:
                ButtonEffect_Up_All();
                ButtonEffects_Down(PauseMenuButtons[PauseMenu_ButtonSelected]);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Resume_Button();
                }
                return;
            case 1:
                ButtonEffect_Up_All();
                ButtonEffects_Down(PauseMenuButtons[PauseMenu_ButtonSelected]);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Restart_Button();
                }
                return;
            case 2:
                ButtonEffect_Up_All();
                ButtonEffects_Down(PauseMenuButtons[PauseMenu_ButtonSelected]);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    BackToMainMenu_Button();
                }
                return;
            default:
                foreach (GameObject Button in GameOverButtons)
                {
                    ButtonEffect_Up(Button);
                }
                return;
        }
    }

    public void Resume_Button()
    {
        PauseMenuPanel.SetActive(false);
        isPauseMenu = false;
        Time.timeScale = 1;
        PauseMenu_ButtonSelected = -1;
        if (Asteroid.GameIsRunning == false)
        {
            Instructions.SetActive(true);
        }

    }

    public void Resume_Button_Number()
    {
        PauseMenu_ButtonSelected = 0;
    }
}
