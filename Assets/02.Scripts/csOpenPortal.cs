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
    GameObject open;
    // Update is called once per frame
    void Update()
    {
        if (csItemManager.instance.item_list.Contains("PortalGun"))
        {
            if (status)
            {
                timer += Time.deltaTime;
                if (timer >= 0.7f)
                {
                    timer = 0.0f;
                    status = false;
                    GameObject idleportal = Instantiate(portal, open.transform.position, open.transform.rotation);
                    Destroy(idleportal, 3.0f);
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                status = true;
                open = Instantiate(openportal, portalPos.position, portalPos.rotation);
                Destroy(open, 1.0f);
            }

        }
    }
}
