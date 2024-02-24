using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager_MainMenu : MonoBehaviour
{
    private int MainMenu_Buttons_Selected = -1;
    private int MainMenu_NewGame_Buttons_Selected = -1;
    private int MainMenu_NewGame_ArcadeMode_Buttons_Selected = -1;
    private int MainMenu_Leaderboard_Buttons_Selected = -1;
    private int MainMenu_Options_Buttons_Selected = -1;
    private int MainMenu_Credits_Buttons_Selected = -1;

    public GameObject[] MainMenu_Buttons = new GameObject[5];
    public GameObject[] MainMenu_NewGame_Buttons = new GameObject[4];
    public GameObject[] MainMenu_NewGame_ArcadeMode_Buttons = new GameObject[6];
    public GameObject[] MainMenu_Leaderboard_Buttons = new GameObject[1];
    public GameObject[] MainMenu_Options_Buttons = new GameObject[1];
    public GameObject[] MainMenu_Credits_Buttons = new GameObject[1];

    public GameObject MainMenu_GameObject;
    public GameObject MainMenu_NewGame_GameObject;
    public GameObject MainMenu_NewGame_ArcadeMode_GameObject;
    public GameObject MainMenu_Leaderboard_GameObject;
    public GameObject MainMenu_Options_GameObject;
    public GameObject MainMenu_Credits_GameObject;

    public GameData GameData = new GameData();

    public GameObject Leaderboards;
    private Leaderboard Leaderboards_Script;
 
    void Start()
    {
        Application.targetFrameRate = 120;

        Leaderboards_Script = Leaderboards.GetComponent<Leaderboard>();

        MainMenu_GameObject.SetActive(true);
        MainMenu_Credits_GameObject.SetActive(false);
        MainMenu_Options_GameObject.SetActive(false);
        MainMenu_Leaderboard_GameObject.SetActive(false);
        MainMenu_NewGame_GameObject.SetActive(false);
        MainMenu_NewGame_ArcadeMode_GameObject.SetActive(false);

        Leaderboards_Script.GetValues();
        Leaderboards_Script.Arcade_Beginner_DrawScores();
        Leaderboards_Script.Arcade_Easy_DrawScores();
        Leaderboards_Script.Arcade_Medium_DrawScores();
        Leaderboards_Script.Arcade_Hard_DrawScores();
        Leaderboards_Script.Arcade_UltraHard_DrawScores();
        Leaderboards_Script.Challenge_DrawScores();
        

    }

    void Update()
    {
        if (MainMenu_GameObject.activeSelf)
        {
            MainMenu();
        }

        else if (MainMenu_Credits_GameObject.activeSelf)
        {
            MainMenu_Credits();
        }

        else if (MainMenu_NewGame_ArcadeMode_GameObject.activeSelf)
        {
            MainMenu_NewGame_ArcadeMode();
        }

        else if (MainMenu_Options_GameObject.activeSelf)
        {
            MainMenu_Options();
        }

        else if (MainMenu_Leaderboard_GameObject.activeSelf)
        {
            MainMenu_Leaderboard();
        }

        else if (MainMenu_NewGame_GameObject.activeSelf)
        {
            MainMenu_NewGame();
        }
    }

    public void MainMenu()
    {
            if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && MainMenu_Buttons_Selected < MainMenu_Buttons.Length - 1)
            {
                MainMenu_Buttons_Selected++;
            }

            else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && MainMenu_Buttons_Selected > 0)
            {
                MainMenu_Buttons_Selected--;
            }

        switch (MainMenu_Buttons_Selected)
        {
            case 0:
                ButtonEffect_Up_All();
                ButtonEffect_Down(MainMenu_Buttons[MainMenu_Buttons_Selected]);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    NewGame_Button();
                }
                return;

            case 1:
                ButtonEffect_Up_All();
                ButtonEffect_Down(MainMenu_Buttons[MainMenu_Buttons_Selected]);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Leaderboard_Button();
                }
                return;

            case 2:
                ButtonEffect_Up_All();
                ButtonEffect_Down(MainMenu_Buttons[MainMenu_Buttons_Selected]);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Options_Button();
                }
                return;
            case 3:
                ButtonEffect_Up_All();
                ButtonEffect_Down(MainMenu_Buttons[MainMenu_Buttons_Selected]);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Credits_Button();
                }
                return;
            case 4:
                ButtonEffect_Up_All();
                ButtonEffect_Down(MainMenu_Buttons[MainMenu_Buttons_Selected]);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Exit_Button();
                }
                return;
            default:
                ButtonEffect_Up_All();
                return;
        }
    }

    public void MainMenu_NewGame()
    {
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && MainMenu_NewGame_Buttons_Selected < MainMenu_NewGame_Buttons.Length - 1)
        {
                MainMenu_NewGame_Buttons_Selected++;
        }

        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && MainMenu_NewGame_Buttons_Selected > 0)
        {
                MainMenu_NewGame_Buttons_Selected--;
        }

        switch (MainMenu_NewGame_Buttons_Selected)
        {
            case 0:
                ButtonEffect_Up_All();
                ButtonEffect_Down(MainMenu_NewGame_Buttons[MainMenu_NewGame_Buttons_Selected]);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    ArcadeMode_Button();
                }
                return;
            case 1:
                ButtonEffect_Up_All();
                ButtonEffect_Down(MainMenu_NewGame_Buttons[MainMenu_NewGame_Buttons_Selected]);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    ChallengeMode_Button();
                }
                return;
            case 2:
                ButtonEffect_Up_All();
                ButtonEffect_Down(MainMenu_NewGame_Buttons[MainMenu_NewGame_Buttons_Selected]);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    CoOpMode_Button();
                }
                return;
            case 3:
                ButtonEffect_Up_All();
                ButtonEffect_Down(MainMenu_NewGame_Buttons[MainMenu_NewGame_Buttons_Selected]);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Back_Button();
                }
                return;
            default:
                ButtonEffect_Up_All();
                return;
        }
    }

    public void MainMenu_NewGame_ArcadeMode()
    {
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && MainMenu_NewGame_ArcadeMode_Buttons_Selected < MainMenu_NewGame_ArcadeMode_Buttons.Length - 1)
        {
            MainMenu_NewGame_ArcadeMode_Buttons_Selected++;
        }

        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && MainMenu_NewGame_ArcadeMode_Buttons_Selected > 0)
        {
            MainMenu_NewGame_ArcadeMode_Buttons_Selected--;
        }

        switch (MainMenu_NewGame_ArcadeMode_Buttons_Selected)
        {
            case 0:
                ButtonEffect_Up_All();
                ButtonEffect_Down(MainMenu_NewGame_ArcadeMode_Buttons[MainMenu_NewGame_ArcadeMode_Buttons_Selected]);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Beginner_Button();
                }
                return;
            case 1:
                ButtonEffect_Up_All();
                ButtonEffect_Down(MainMenu_NewGame_ArcadeMode_Buttons[MainMenu_NewGame_ArcadeMode_Buttons_Selected]);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Easy_Button();
                }
                return;
            case 2:
                ButtonEffect_Up_All();
                ButtonEffect_Down(MainMenu_NewGame_ArcadeMode_Buttons[MainMenu_NewGame_ArcadeMode_Buttons_Selected]);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Medium_Button();
                }
                return;
            case 3:
                ButtonEffect_Up_All();
                ButtonEffect_Down(MainMenu_NewGame_ArcadeMode_Buttons[MainMenu_NewGame_ArcadeMode_Buttons_Selected]);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Hard_Button();
                }
                return;
            case 4:
                ButtonEffect_Up_All();
                ButtonEffect_Down(MainMenu_NewGame_ArcadeMode_Buttons[MainMenu_NewGame_ArcadeMode_Buttons_Selected]);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    UltraHard_Button();
                }
                return;
            case 5:
                ButtonEffect_Up_All();
                ButtonEffect_Down(MainMenu_NewGame_ArcadeMode_Buttons[MainMenu_NewGame_ArcadeMode_Buttons_Selected]);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    BackButton_NewGame();
                }
                return;
            default:
                ButtonEffect_Up_All();
                return;
        }
    }

    public void MainMenu_Leaderboard()
    {
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && MainMenu_Leaderboard_Buttons_Selected < MainMenu_Leaderboard_Buttons.Length -1)
        {
            MainMenu_Leaderboard_Buttons_Selected++;
        }

        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && MainMenu_Leaderboard_Buttons_Selected > 0)
        {
            MainMenu_Leaderboard_Buttons_Selected--;
        }

        switch (MainMenu_Leaderboard_Buttons_Selected)
        {
            case 0:
                ButtonEffect_Up_All();
                ButtonEffect_Down(MainMenu_Leaderboard_Buttons[MainMenu_Leaderboard_Buttons_Selected]);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Back_Button();
                }
                return;
            default:
                ButtonEffect_Up_All();
                return;
        }
    }

    public void MainMenu_Options()
    {
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && MainMenu_Options_Buttons_Selected < MainMenu_Options_Buttons.Length - 1)
        {
            MainMenu_Options_Buttons_Selected++;
        }

        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && MainMenu_Options_Buttons_Selected > 0)
        {
            MainMenu_Options_Buttons_Selected--;
        }

        switch (MainMenu_Options_Buttons_Selected)
        {
            case 0:
                ButtonEffect_Up_All();
                ButtonEffect_Down(MainMenu_Options_Buttons[MainMenu_Options_Buttons_Selected]);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Back_Button();
                }
                return;
            default:
                ButtonEffect_Up_All();
                return;
        }
        
    }

    public void MainMenu_Credits()
    {
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && MainMenu_Credits_Buttons_Selected < MainMenu_Credits_Buttons.Length - 1)
        {
            MainMenu_Credits_Buttons_Selected++;
        }

        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && MainMenu_Credits_Buttons_Selected > 0)
        {
            MainMenu_Credits_Buttons_Selected--;
        }

        switch (MainMenu_Credits_Buttons_Selected)
        {
            case 0:
                ButtonEffect_Up_All();
                ButtonEffect_Down(MainMenu_Credits_Buttons[MainMenu_Credits_Buttons_Selected]);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Back_Button();
                }
                return;
            default:
                foreach(GameObject Button in MainMenu_Credits_Buttons)
                {
                    ButtonEffect_Up(Button);
                }
                return;
        }
    }

    public void ButtonEffect_Down(GameObject Button)
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
        foreach (GameObject Button in MainMenu_Buttons)
        {
            ButtonEffect_Up(Button);
        }

        foreach (GameObject Button in MainMenu_Credits_Buttons)
        {
            ButtonEffect_Up(Button);
        }

        foreach (GameObject Button in MainMenu_Options_Buttons)
        {
            ButtonEffect_Up(Button);
        }

        foreach (GameObject Button in MainMenu_Leaderboard_Buttons)
        {
            ButtonEffect_Up(Button);
        }

        foreach (GameObject Button in MainMenu_NewGame_Buttons)
        {
            ButtonEffect_Up(Button);
        }

        foreach (GameObject Button in MainMenu_NewGame_ArcadeMode_Buttons)
        {
            ButtonEffect_Up(Button);
        }
    }

    public void NewGame_Button()
    {
        MainMenu_GameObject.SetActive(false);
        MainMenu_NewGame_GameObject.SetActive(true);
    }

    public void NewGame_Button_Number()
    {
        MainMenu_Buttons_Selected = 0;
    }

    public void Leaderboard_Button()
    {
        MainMenu_GameObject.SetActive(false);
        MainMenu_Leaderboard_GameObject.SetActive(true);
    }

    public void Leaderboard_Button_Number()
    {
        MainMenu_Buttons_Selected = 1;
    }

    public void Options_Button()
    {
        MainMenu_GameObject.SetActive(false);
        MainMenu_Options_GameObject.SetActive(true);
    }

    public void Options_Button_Number()
    {
        MainMenu_Buttons_Selected = 2;
    }

    public void Credits_Button()
    {
        MainMenu_GameObject.SetActive(false);
        MainMenu_Credits_GameObject.SetActive(true);
    }

    public void Credits_Button_Number()
    {
        MainMenu_Buttons_Selected = 3;
    }

    public void Exit_Button()
    {
        Application.Quit();
    }

    public void Exit_Button_Number()
    {
        MainMenu_Buttons_Selected = 4;
    }

    public void Back_Button()
    {
        MainMenu_GameObject.SetActive(true);
        MainMenu_Credits_GameObject.SetActive(false);
        MainMenu_Options_GameObject.SetActive(false);
        MainMenu_Leaderboard_GameObject.SetActive(false);
        MainMenu_NewGame_GameObject.SetActive(false);
        MainMenu_Credits_Buttons_Selected = -1;
        MainMenu_Leaderboard_Buttons_Selected = -1;
        MainMenu_NewGame_Buttons_Selected = -1;
        MainMenu_Options_Buttons_Selected = -1;
    }

    public void Back_Button_Number()
    {
        MainMenu_Options_Buttons_Selected = 0;
        MainMenu_Credits_Buttons_Selected = 0;
        MainMenu_Leaderboard_Buttons_Selected = 0;
        MainMenu_NewGame_Buttons_Selected = 3;
    }

    public void ArcadeMode_Button()
    {
        MainMenu_NewGame_GameObject.SetActive(false);
        MainMenu_NewGame_ArcadeMode_GameObject.SetActive(true);
        MainMenu_NewGame_ArcadeMode_Buttons_Selected = -1;
    }

    public void ArcadeMode_Button_Number()
    {
        MainMenu_NewGame_Buttons_Selected = 0;
    }

    public void ChallengeMode_Button()
    {
        GameData.GameDifficulty = 10;
        SceneManager.LoadScene(1);
    }

    public void ChallengeMode_Button_Number()
    {
        MainMenu_NewGame_Buttons_Selected = 1;
    }

    public void CoOpMode_Button()
    {

    }

    public void CoOpMode_Button_Number()
    {
        MainMenu_NewGame_Buttons_Selected = 2;
    }

    public void Beginner_Button()
    {
        GameData.GameDifficulty = 1;
        SceneManager.LoadScene(1);
    }

    public void Beginner_Button_Number()
    {
        MainMenu_NewGame_ArcadeMode_Buttons_Selected = 0;
    }

    public void Easy_Button()
    {
        GameData.GameDifficulty = 2;
        SceneManager.LoadScene(1);
    }

    public void Easy_Button_Number()
    {
        MainMenu_NewGame_ArcadeMode_Buttons_Selected = 1;
    }

    public void Medium_Button()
    {
        GameData.GameDifficulty = 3;
        SceneManager.LoadScene(1);
    }

    public void Medium_Button_Number()
    {
        MainMenu_NewGame_ArcadeMode_Buttons_Selected = 2;
    }

    public void Hard_Button()
    {
        GameData.GameDifficulty = 4;
        SceneManager.LoadScene(1);
    }

    public void Hard_Button_Number()
    {
        MainMenu_NewGame_ArcadeMode_Buttons_Selected = 3;
    }

    public void UltraHard_Button()
    {
        GameData.GameDifficulty = 5;
        SceneManager.LoadScene(1);
    }

    public void UltraHard_Button_Number()
    {
        MainMenu_NewGame_ArcadeMode_Buttons_Selected = 4;
    }

    public void BackButton_NewGame()
    {
        MainMenu_NewGame_ArcadeMode_GameObject.SetActive(false);
        MainMenu_NewGame_GameObject.SetActive(true);
   }

    public void BackButton_NewGame_Number()
    {
        MainMenu_NewGame_ArcadeMode_Buttons_Selected = 5;
    }

    private void Error()
    {
       
    }
}
