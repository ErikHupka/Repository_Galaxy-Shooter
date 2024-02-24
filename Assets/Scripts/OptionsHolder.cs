using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsHolder : MonoBehaviour
{
    Options optionHolder = new Options();

    private void Awake()
    {
        DuplicateCheck();
    }

    void DuplicateCheck()
    {
        if (FindObjectsOfType<OptionsHolder>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public Options GetOptions()
    {
        return optionHolder;
    }

    public void SetOptions(Options newOptions)
    {
        optionHolder = newOptions;
    }
}
