using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csOpenPortal : MonoBehaviour
{
    public Transform portalPos;
    public GameObject portal;
    public GameObject openportal;
    float timer = 0.0f;
    bool status = false;
    int waitingTime = 1;
    GameObject open;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<cshPlayerInteraction>().selecteditem.Equals("PortalGun"))
        {
            if (status)
                timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                GameObject open = Instantiate(openportal, portalPos.position, portalPos.rotation);
                Destroy(open, 1.0f);
                timer = 0;
                status = false;
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
