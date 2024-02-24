using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator anim;
    private bool A, B = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && B == false)
        {
            anim.SetBool("Turn_Left", true); 
            anim.SetBool("Turn_Right", false);

            A = true;
            B = false;
        }

        if ((Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) && A == true)
        {
            anim.SetBool("Turn_Left", false);
            anim.SetBool("Turn_Right", false);

            A = false;
            B = false;
        }
        
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && A == false)
        {
            anim.SetBool("Turn_Left", false);
            anim.SetBool("Turn_Right", true);

            A = false;
            B = true;
        }

        if ((Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) && B == true)
        {
            anim.SetBool("Turn_Left", false);
            anim.SetBool("Turn_Right", false);

            A = false;
            B = false;
        }
    }
}
