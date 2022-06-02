using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csCountFire : MonoBehaviour
{
    GameObject[] fires;
    int count = 0;
    int count2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        fires = GameObject.FindGameObjectsWithTag("Fire");
        count = fires.Length;
    }

    // Update is called once per frame
    void Update()
    {
        fires = GameObject.FindGameObjectsWithTag("Fire");
        count2 = fires.Length;
        if((count - count2) >= (count / 2))
        {
            cshRoomManager.Instance.isFireExists = true;
        }
        else
        {
            cshRoomManager.Instance.isFireExists = false;
        }
    }
}
