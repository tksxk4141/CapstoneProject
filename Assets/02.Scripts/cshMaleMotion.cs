using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshMaleMotion : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Grounded", false);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("Grounded", true);
        }

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetFloat("MoveSpeed", 0.5f);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat("MoveSpeed", 1.0f);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetFloat("MoveSpeed", 0.0f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            anim.SetFloat("MoveSpeed", 1.5f);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat("MoveSpeed", 2.0f);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetFloat("MoveSpeed", 0.0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            anim.SetFloat("MoveSpeed", 2.5f);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat("MoveSpeed", 3.0f);
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetFloat("MoveSpeed", 0.0f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetFloat("MoveSpeed", 3.5f);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat("MoveSpeed", 4.0f);
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetFloat("MoveSpeed", 0.0f);
        }
    }
}
