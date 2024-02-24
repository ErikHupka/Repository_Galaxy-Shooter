using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text HighScore;
    [SerializeField]
    private Image LivesImg;
    [SerializeField]
    private Sprite[] liveSprites;
    [SerializeField]
    private Text gameOverText;
    [SerializeField]
    private GameObject Restart_Button, BackToMainMenu_Button;
    private ColorBlock Restart_Button_Color;
    [SerializeField]
    private Image Restart_Button_Image;
    [SerializeField]
    private Button Restart_Button_Button;
    private GameManager gameManager;
    private int BestScore;
    public GameObject Restart_GameObject;
    public Leaderboard Leaderboard = new Leaderboard();
    public GameData GameData = new GameData();
    public int GameDifficulty;

    public GameManager GameManager = new GameManager();

    private void Start()
    {
        GameDifficulty = GameData.GameDifficulty;
        switch (GameDifficulty)
        {
            case 1:
                BestScore = PlayerPrefs.GetInt("Arcade_Beginner_HighScoreValues" + 0);
                break;
            case 2:
                BestScore = PlayerPrefs.GetInt("Arcade_Easy_HighScoreValues" + 0);
                break;
            case 3:
                BestScore = PlayerPrefs.GetInt("Arcade_Medium_HighScoreValues" + 0);
                break;
            case 4:
                BestScore = PlayerPrefs.GetInt("Arcade_Hard_HighScoreValues" + 0);
                break;
            case 5:
                BestScore = PlayerPrefs.GetInt("Arcade_UltraHard_HighScoreValues" + 0);
                break;
            case 10:
                BestScore = PlayerPrefs.GetInt("Challenge_HighScoreValues" + 0);
                break;
            default:
                break;
        }
        scoreText.text = "Score: ";
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("Game Manager is NULL");
        }

        HighScore.text = "High Score: " + BestScore;
    }

    public void UpdateScore(int PlayerScore)
    {
        scoreText.text = "Score: " + PlayerScore.ToString();
    }

    public void UpdateLives(int currentLives)
    {
        if (currentLives <= 3 && currentLives >= 0)
        {
            LivesImg.sprite = liveSprites[currentLives];
        }

        if (currentLives < 1)
        {
            GameOverSequence();
        }
    }

    void GameOverSequence()
    {
        gameManager.GameOver();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

}
