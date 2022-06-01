using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csThrowBall : MonoBehaviour
{
    public Transform ballPos;
    public GameObject ball;

    float timer = 0.0f;
    int waitingTime = 1;
    bool isthrow = false;
    // Update is called once per frame
    void Update()
    {
        if(isthrow)
            timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            GameObject instate = Instantiate(ball, ballPos.position, ballPos.parent.rotation);
            instate.GetComponent<Rigidbody>().AddForce(instate.transform.forward * 3000f);
            timer = 0;
            isthrow = false;
        }
        if (gameObject.GetComponent<cshPlayerInteraction>().selecteditem.Equals("IceBomb"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameObject.GetComponent<FirstPersonController>().anim.SetBool("isThrow", true);
                isthrow = true;
            }
           else
            {
                gameObject.GetComponent<FirstPersonController>().anim.SetBool("isThrow", false);
            }
        }
    }
}
