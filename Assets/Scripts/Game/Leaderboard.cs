using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Text[] Arcade_Beginner_HighScores = new Text[10];
    private int[] Arcade_Beginner_HighScoreValues = new int[10];
    private string[] Arcade_Beginner_HighScoreNames = new string[10];

    public Text[] Arcade_Easy_HighScores = new Text[10];
    private int[] Arcade_Easy_HighScoreValues = new int[10];
    private string[] Arcade_Easy_HighScoreNames = new string[10];

    public Text[] Arcade_Medium_HighScores = new Text[10];
    private int[] Arcade_Medium_HighScoreValues = new int[10];
    private string[] Arcade_Medium_HighScoreNames = new string[10];

    public Text[] Arcade_Hard_HighScores = new Text[10];
    private int[] Arcade_Hard_HighScoreValues = new int[10];
    private string[] Arcade_Hard_HighScoreNames = new string[10];

    public Text[] Arcade_UltraHard_HighScores = new Text[10];
    private int[] Arcade_UltraHard_HighScoreValues = new int[10];
    private string[] Arcade_UltraHard_HighScoreNames = new string[10];

    public Text[] Challenge_HighScores = new Text[10];
    private int[] Challenge_HighScoreValues = new int[10];
    private string[] Challenge_HighScoreNames = new string[10];


    void Start()
    {
        GetValues();
    }

    public void Arcade_Beginner_SaveScores()
    {
        for (int x = 0; x < Arcade_Beginner_HighScores.Length; x++)
        {
            PlayerPrefs.SetInt("Arcade_Beginner_HighScoreValues" + x, Arcade_Beginner_HighScoreValues[x]);
            PlayerPrefs.SetString("Arcade_Beginner_HighScoreNames" + x, Arcade_Beginner_HighScoreNames[x]);
        }
    }

    public void Arcade_Beginner_CheckForHighScore(int value, string userName)
    {
        for (int x = 0; x < Arcade_Beginner_HighScores.Length; x++)
        {
            if (value > Arcade_Beginner_HighScoreValues[x])
            {
                for (int y = Arcade_Beginner_HighScores.Length - 1; y > x; y--)
                {
                    Arcade_Beginner_HighScoreValues[y] = Arcade_Beginner_HighScoreValues[y - 1];
                    Arcade_Beginner_HighScoreNames[y] = Arcade_Beginner_HighScoreNames[y - 1];
                }
                Arcade_Beginner_HighScoreValues[x] = value;
                Arcade_Beginner_HighScoreNames[x] = userName;
                Arcade_Beginner_SaveScores();
                break;
            }
        }
    }

    public void Arcade_Beginner_DrawScores()
    {
        for (int x = 0; x < Arcade_Beginner_HighScores.Length; x++)
        {
            
            Arcade_Beginner_HighScores[x].text = x+1 + ".  " + Arcade_Beginner_HighScoreNames[x] + "  -  " + Arcade_Beginner_HighScoreValues[x].ToString();
        }
    }

    public void Arcade_Easy_SaveScores()
    {
        for (int x = 0; x < Arcade_Easy_HighScores.Length; x++)
        {
            PlayerPrefs.SetInt("Arcade_Easy_HighScoreValues" + x, Arcade_Easy_HighScoreValues[x]);
            PlayerPrefs.SetString("Arcade_Easy_HighScoreNames" + x, Arcade_Easy_HighScoreNames[x]);
        }
    }

    public void Arcade_Easy_CheckForHighScore(int value, string userName)
    {
        for (int x = 0; x < Arcade_Easy_HighScores.Length; x++)
        {
            if (value > Arcade_Easy_HighScoreValues[x])
            {
                for (int y = Arcade_Easy_HighScores.Length - 1; y > x; y--)
                {
                    Arcade_Easy_HighScoreValues[y] = Arcade_Easy_HighScoreValues[y - 1];
                    Arcade_Easy_HighScoreNames[y] = Arcade_Easy_HighScoreNames[y - 1];
                }
                Arcade_Easy_HighScoreValues[x] = value;
                Arcade_Easy_HighScoreNames[x] = userName;

                Arcade_Easy_SaveScores();
                break;
            }
        }
    }

    public void Arcade_Easy_DrawScores()
    {
        for (int x = 0; x < Arcade_Easy_HighScores.Length; x++)
        {
            Arcade_Easy_HighScores[x].text = x+1 + ".  " + Arcade_Easy_HighScoreNames[x] + "  -  " + Arcade_Easy_HighScoreValues[x].ToString();
        }
    }

    public void Arcade_Medium_SaveScores()
    {
        for (int x = 0; x < Arcade_Medium_HighScores.Length; x++)
        {
            PlayerPrefs.SetInt("Arcade_Medium_HighScoreValues" + x, Arcade_Medium_HighScoreValues[x]);
            PlayerPrefs.SetString("Arcade_Medium_HighScoreNames" + x, Arcade_Medium_HighScoreNames[x]);
        }
    }

    public void Arcade_Medium_CheckForHighScore(int value, string userName)
    {
        for (int x = 0; x < Arcade_Medium_HighScores.Length; x++)
        {
            if (value > Arcade_Medium_HighScoreValues[x])
            {
                for (int y = Arcade_Medium_HighScores.Length - 1; y > x; y--)
                {
                    Arcade_Medium_HighScoreValues[y] = Arcade_Medium_HighScoreValues[y - 1];
                    Arcade_Medium_HighScoreNames[y] = Arcade_Medium_HighScoreNames[y - 1];
                }
                Arcade_Medium_HighScoreValues[x] = value;
                Arcade_Medium_HighScoreNames[x] = userName;

                Arcade_Medium_SaveScores();
                break;
            }
        }
    }

    public void Arcade_Medium_DrawScores()
    {
        for (int x = 0; x < Arcade_Medium_HighScores.Length; x++)
        {
            Arcade_Medium_HighScores[x].text = x+1 + ".  " + Arcade_Medium_HighScoreNames[x] + "  -  " + Arcade_Medium_HighScoreValues[x].ToString();
        }
    }

    public void Arcade_Hard_SaveScores()
    {
        for (int x = 0; x < Arcade_Hard_HighScores.Length; x++)
        {
            PlayerPrefs.SetInt("Arcade_Hard_HighScoreValues" + x, Arcade_Hard_HighScoreValues[x]);
            PlayerPrefs.SetString("Arcade_Hard_HighScoreNames" + x, Arcade_Hard_HighScoreNames[x]);
        }
    }

    public void Arcade_Hard_CheckForHighScore(int value, string userName)
    {
        for (int x = 0; x < Arcade_Hard_HighScores.Length; x++)
        {
            if (value > Arcade_Hard_HighScoreValues[x])
            {
                for (int y = Arcade_Hard_HighScores.Length - 1; y > x; y--)
                {
                    Arcade_Hard_HighScoreValues[y] = Arcade_Hard_HighScoreValues[y - 1];
                    Arcade_Hard_HighScoreNames[y] = Arcade_Hard_HighScoreNames[y - 1];
                }
                Arcade_Hard_HighScoreValues[x] = value;
                Arcade_Hard_HighScoreNames[x] = userName;

                Arcade_Hard_SaveScores();
                break;
            }
        }
    }

    public void Arcade_Hard_DrawScores()
    {
        for (int x = 0; x < Arcade_Hard_HighScores.Length; x++)
        {
            Arcade_Hard_HighScores[x].text = x+1 + ".  " + Arcade_Hard_HighScoreNames[x] + "  -  " + Arcade_Hard_HighScoreValues[x].ToString();
        }
    }

    public void Arcade_UltraHard_SaveScores()
    {
        for (int x = 0; x < Arcade_UltraHard_HighScores.Length; x++)
        {
            PlayerPrefs.SetInt("Arcade_UltraHard_HighScoreValues" + x, Arcade_UltraHard_HighScoreValues[x]);
            PlayerPrefs.SetString("Arcade_UltraHard_HighScoreNames" + x, Arcade_UltraHard_HighScoreNames[x]);
        }
    }

    public void Arcade_UltraHard_CheckForHighScore(int value, string userName)
    {
        for (int x = 0; x < Arcade_UltraHard_HighScores.Length; x++)
        {
            if (value > Arcade_UltraHard_HighScoreValues[x])
            {
                for (int y = Arcade_UltraHard_HighScores.Length - 1; y > x; y--)
                {
                    Arcade_UltraHard_HighScoreValues[y] = Arcade_UltraHard_HighScoreValues[y - 1];
                    Arcade_UltraHard_HighScoreNames[y] = Arcade_UltraHard_HighScoreNames[y - 1];
                }
                Arcade_UltraHard_HighScoreValues[x] = value;
                Arcade_UltraHard_HighScoreNames[x] = userName;

                Arcade_UltraHard_SaveScores();
                break;
            }
        }
    }

    public void Arcade_UltraHard_DrawScores()
    {
        for (int x = 0; x < Arcade_UltraHard_HighScores.Length; x++)
        {
            Arcade_UltraHard_HighScores[x].text = x+1 + ".  " + Arcade_UltraHard_HighScoreNames[x] + "  -  " + Arcade_UltraHard_HighScoreValues[x].ToString();
        }
    }

    public void Challenge_SaveScores()
    {
        for (int x = 0; x < Challenge_HighScores.Length; x++)
        {
            PlayerPrefs.SetInt("Challenge_HighScoreValues" + x, Challenge_HighScoreValues[x]);
            PlayerPrefs.SetString("Challenge_HighScoreNames" + x, Challenge_HighScoreNames[x]);
        }
    }

    public void Challenge_CheckForHighScore(int value, string userName)
    {
        for (int x = 0; x < Challenge_HighScores.Length; x++)
        {
            if (value > Challenge_HighScoreValues[x])
            {
                for (int y = Challenge_HighScores.Length - 1; y > x; y--)
                {
                    Challenge_HighScoreValues[y] = Challenge_HighScoreValues[y - 1];
                    Challenge_HighScoreNames[y] = Challenge_HighScoreNames[y - 1];
                }
                Challenge_HighScoreValues[x] = value;
                Challenge_HighScoreNames[x] = userName;

                Challenge_SaveScores();
                break;
            }
        }
    }

    public void Challenge_DrawScores()
    {
        for (int x = 0; x < Challenge_HighScores.Length; x++)
        {
            Challenge_HighScores[x].text = x+1 + ".  " + Challenge_HighScoreNames[x] + "  -  " + Challenge_HighScoreValues[x].ToString();
        }
    }

    public void GetValues()
    {
       /* Arcade_Beginner_HighScoreValues = new int[Arcade_Beginner_HighScores.Length];
        Arcade_Beginner_HighScoreNames = new string[Arcade_Beginner_HighScores.Length];

        Arcade_Easy_HighScoreValues = new int[Arcade_Beginner_HighScores.Length];
        Arcade_Easy_HighScoreNames = new string[Arcade_Beginner_HighScores.Length];

        Arcade_Medium_HighScoreValues = new int[Arcade_Beginner_HighScores.Length];
        Arcade_Medium_HighScoreNames = new string[Arcade_Beginner_HighScores.Length];

        Arcade_Hard_HighScoreValues = new int[Arcade_Beginner_HighScores.Length];
        Arcade_Hard_HighScoreNames = new string[Arcade_Beginner_HighScores.Length];

        Arcade_UltraHard_HighScoreValues = new int[Arcade_Beginner_HighScores.Length];
        Arcade_UltraHard_HighScoreNames = new string[Arcade_Beginner_HighScores.Length];

        Challenge_HighScoreValues = new int[Arcade_Beginner_HighScores.Length];
        Challenge_HighScoreNames = new string[Arcade_Beginner_HighScores.Length];*/

        for (int x = 0; x < Arcade_Beginner_HighScores.Length; x++)
        {
            Arcade_Beginner_HighScoreValues[x] = PlayerPrefs.GetInt("Arcade_Beginner_HighScoreValues" + x);
            Arcade_Beginner_HighScoreNames[x] = PlayerPrefs.GetString("Arcade_Beginner_HighScoreNames" + x);
        }

        for (int x = 0; x < Arcade_Easy_HighScores.Length; x++)
        {
            Arcade_Easy_HighScoreValues[x] = PlayerPrefs.GetInt("Arcade_Easy_HighScoreValues" + x);
            Arcade_Easy_HighScoreNames[x] = PlayerPrefs.GetString("Arcade_Easy_HighScoreNames" + x);
        }

        for (int x = 0; x < Arcade_Medium_HighScores.Length; x++)
        {
            Arcade_Medium_HighScoreValues[x] = PlayerPrefs.GetInt("Arcade_Medium_HighScoreValues" + x);
            Arcade_Medium_HighScoreNames[x] = PlayerPrefs.GetString("Arcade_Medium_HighScoreNames" + x);
        }

        for (int x = 0; x < Arcade_Hard_HighScores.Length; x++)
        {
            Arcade_Hard_HighScoreValues[x] = PlayerPrefs.GetInt("Arcade_Hard_HighScoreValues" + x);
            Arcade_Hard_HighScoreNames[x] = PlayerPrefs.GetString("Arcade_Hard_HighScoreNames" + x);
        }

        for (int x = 0; x < Arcade_UltraHard_HighScores.Length; x++)
        {
            Arcade_UltraHard_HighScoreValues[x] = PlayerPrefs.GetInt("Arcade_UltraHard_HighScoreValues" + x);
            Arcade_UltraHard_HighScoreNames[x] = PlayerPrefs.GetString("Arcade_UltraHard_HighScoreNames" + x);
        }

        for (int x = 0; x < Challenge_HighScores.Length; x++)
        {
            Challenge_HighScoreValues[x] = PlayerPrefs.GetInt("Challenge_HighScoreValues" + x);
            Challenge_HighScoreNames[x] = PlayerPrefs.GetString("Challenge_HighScoreNames" + x);
        }
    }
}
