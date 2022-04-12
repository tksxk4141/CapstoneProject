using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csOpenDoor : MonoBehaviour
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
        if(Input.GetKey(KeyCode.G) && me.transform.position.x<35 && me.transform.position.x > 31 && me.transform.position.z<-3)
        {
            open = true; 
        }
        if (open && transform.position.x > 28)
        {
            position.x -= 1 * Time.deltaTime;
            transform.position = position;
        }
    }
}
