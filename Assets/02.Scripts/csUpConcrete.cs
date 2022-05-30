using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csUpConcrete : MonoBehaviour
{
    Vector3 position;
    Vector3 start;
    GameObject me;
    float pos;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        position = transform.position;
        me = GameObject.Find("FirstPersonController");
        pos = 0;
        //gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (csItemManager.instance.item_list.Contains("Necklace"))
        {
            if (Input.GetKey(KeyCode.G) && me.transform.position.x > 32 && me.transform.position.x < 34 && me.transform.position.z > 4)
            {
                //gameObject.GetComponent<Rigidbody>().useGravity = false;
                if (transform.position.y - start.y <= 1)
                {
                    shake();
                    position.y += 0.5f * Time.deltaTime;
                    transform.position = position;
                }
            }
            else
            {
                if (transform.position.y >= start.y)
                {
                    position.y -= 7 * Time.deltaTime;
                    transform.position = position;
                }
            }
        }
    }
    void shake()
    {
        pos = Random.Range(-0.005f, 0.005f);
        position.x += pos;
    }
}
