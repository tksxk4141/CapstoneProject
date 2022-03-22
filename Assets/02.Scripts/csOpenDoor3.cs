using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csOpenDoor3 : MonoBehaviour
{
    Vector3 position;
    public bool open = false;
    GameObject me;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        me = GameObject.Find("FirstPersonController");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.G) && me.transform.position.z > 24 && me.transform.position.x > -4 && me.transform.position.x < -2)
        {
            open = true;
        }
        if (open && transform.position.x < -5)
        {
            position.x += 1 * Time.deltaTime;
            transform.position = position;
        }
    }
}
