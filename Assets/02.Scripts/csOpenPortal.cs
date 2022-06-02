using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csOpenPortal : MonoBehaviour
{
    public Transform portalPos;
    public GameObject portal;
    public GameObject openportal;
    float timer = 0.0f;
    float timer2 = 0.0f;
    bool status = false;
    bool status2 = false;
    int waitingTime = 1;
    GameObject open;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<cshPlayerInteraction>().selecteditem.Equals("PortalGun"))
        {
            if (status)
                timer += Time.deltaTime;
            if (status2)
                timer2 += Time.deltaTime;
            if (timer > waitingTime)
            {
                GameObject open = Instantiate(openportal, portalPos.position, portalPos.rotation);
                Destroy(open, 1.0f);
                timer = 0;
                status = false;
                status2 = true;
            }
            if (timer2 > 0.7f)
            {
                timer2 = 0.0f;
                status2 = false;
                GameObject idleportal = Instantiate(portal, portalPos.position, portalPos.rotation);
                Destroy(idleportal, 3.0f);
            }

            if (Input.GetMouseButton(0))
            {
                gameObject.GetComponent<FirstPersonController>().anim.SetBool("isTeleKinesis", true);
                status = true;
            }
            else
            {
                gameObject.GetComponent<FirstPersonController>().anim.SetBool("isTeleKinesis", false);
            }
        }
    }
}
