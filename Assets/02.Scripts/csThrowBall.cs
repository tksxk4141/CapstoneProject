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
        if (csItemManager.instance.item_list.Contains("IceBomb"))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {

                GameObject instate = Instantiate(ball, ballPos.position, ballPos.parent.rotation);
                //Vector3 speed = new Vector3(0, 200, 2000);
                instate.GetComponent<Rigidbody>().AddForce(instate.transform.forward * 3000f);
            }
        }
    }
    
}
