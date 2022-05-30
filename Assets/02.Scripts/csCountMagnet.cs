using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csCountMagnet : MonoBehaviour
{
    public GameObject portal;
    public Transform portalPos;
    public int countMagnet = 0;

    void Update()
    {
        if (countMagnet == 30)
        {
            Instantiate(portal, portalPos.position, portalPos.rotation);
            countMagnet = 0;
        }
    }
}
