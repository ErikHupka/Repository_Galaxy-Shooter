using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard_DropDown : MonoBehaviour
{
    public Dropdown DropDown;
    public GameObject[] LeaderBoards;
    public GameObject GameManager;
    private Leaderboard LeaderBoards_Script;

    void Start()
    {
    }

    void Update()
    {
        switch (DropDown.value)
        {
            case 0:
                foreach(GameObject Boards in LeaderBoards)
                {
                    Boards.SetActive(false);
                }
                LeaderBoards[DropDown.value].SetActive(true);
                break;
            case 1:
                foreach (GameObject Boards in LeaderBoards)
                {
                    Boards.SetActive(false);
                }
                LeaderBoards[DropDown.value].SetActive(true);
                break;
            case 2:
                foreach (GameObject Boards in LeaderBoards)
                {
                    Boards.SetActive(false);
                }
                LeaderBoards[DropDown.value].SetActive(true);
                break;
            case 3:
                foreach (GameObject Boards in LeaderBoards)
                {
                    Boards.SetActive(false);
                }
                LeaderBoards[DropDown.value].SetActive(true);
                break;
            case 4:
                foreach (GameObject Boards in LeaderBoards)
                {
                    Boards.SetActive(false);
                }
                LeaderBoards[DropDown.value].SetActive(true);
                break;
            case 5:
                foreach (GameObject Boards in LeaderBoards)
                {
                    Boards.SetActive(false);
                }
                LeaderBoards[DropDown.value].SetActive(true);
                break;
            default:
                break;

        }
    }
}
