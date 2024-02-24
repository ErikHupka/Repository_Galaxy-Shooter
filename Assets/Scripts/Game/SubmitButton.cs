using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitButton : MonoBehaviour
{
    public GameObject GameManager;
    private GameManager GameManager_Script;

    void Start()
    {
        GameManager_Script = GameManager.GetComponent<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameManager_Script.SaveHighScore();
            Debug.Log("Save");
        }
    }
}
