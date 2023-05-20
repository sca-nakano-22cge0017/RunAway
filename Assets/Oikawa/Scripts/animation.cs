using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    private Animator anim = null;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("attack", true);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("scary", true);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("down", true);
        }
        else
        {
            anim.SetBool("attack", false);
        }
    }
}
