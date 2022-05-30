using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class csUpLadder : MonoBehaviour
{
    GameObject me;
    Vector3 position;
    bool up = false;
    // Start is called before the first frame update
    void Start()
    {
        me = GameObject.Find("FirstPersonController");
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (me.transform.position.z > 25)
        {
            if (Input.GetKey(KeyCode.G))
            {
                up = true;
            }
            if (up && Input.GetKey(KeyCode.F))
            {
                position.y += 1 * Time.deltaTime;
                transform.position = position;
            }
        }
        if (me.transform.position.y >= 10)
        {
            //SceneManager.LoadScene("thirdFloor2");
        }
    }
}
