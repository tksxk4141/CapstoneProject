using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class csOpenMiro : MonoBehaviour
{
    Vector3 pos;
    Vector3 posBack;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        posBack = transform.position;
        pos.x = 58; pos.y = 39; pos.z = -275;
        posBack.x = 3; posBack.y = 1; posBack.z = 30;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (GetComponent<csSizeCalc>().isSmall)
        {
            if (other.gameObject.CompareTag("miro"))
            {
                transform.position = pos;
                GetComponent<csSizeCalc>().isSmall = false;
            }
        }
        if (other.gameObject.CompareTag("ExitMiro"))
        {
            GameObject.Find("CheckLastDoor").GetComponent<CheckLastDoor>().isExitMiro = true;
            transform.position = posBack;
        }
    }
}
