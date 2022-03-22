using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class csChangeScene2 : MonoBehaviour
{
    GameObject me; 
    bool ch = false;
    // Start is called before the first frame update
    void Start()
    {
        me = GameObject.Find("FirstPersonController");
    }

    // Update is called once per frame
    void Update()
    {
        if((me.transform.position.z > 7.5 && me.transform.position.z < 8.2) ||
             (me.transform.position.z > 9.7 && me.transform.position.z < 10.4) ||
              (me.transform.position.z > 11.6 && me.transform.position.z < 12.3) ||
                (me.transform.position.z > 14 && me.transform.position.z < 14.7) ||
                 (me.transform.position.z > 16.2 && me.transform.position.z < 16.9))
        {
            ch = true;
        }
        else
        {
            ch = false;
        }
        if (me.transform.position.x>33 && me.transform.position.x < 34 &&
             me.transform.position.y > 3 && ch)
        {

            SceneManager.LoadScene("thirdFloor");
        }
    }
}
