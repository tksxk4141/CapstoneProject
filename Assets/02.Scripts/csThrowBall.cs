using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csThrowBall : MonoBehaviour
{
    public Transform ballPos;
    public GameObject ball;
    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<cshPlayerInteraction>().selecteditem.Equals("IceBomb"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject instate = Instantiate(ball, ballPos.position, ballPos.parent.rotation);
                instate.GetComponent<Rigidbody>().AddForce(instate.transform.forward * 3000f);
            }
        }
    }
}
