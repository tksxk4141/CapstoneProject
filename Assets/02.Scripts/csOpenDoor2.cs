using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csOpenDoor2 : MonoBehaviour
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
        if (Input.GetKey(KeyCode.G) && me.transform.position.x > 3 && me.transform.position.z > 16 && me.transform.position.z < 19)
        {
            open = true;
        }
        if (open && transform.position.z > 11)
        {
            position.z -= 1 * Time.deltaTime;
            transform.position = position;
        }
    }
}
