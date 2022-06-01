using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csShootRay : MonoBehaviour
{
    public Transform rayPos;
    public GameObject Ray;
    bool isRay = false;
    GameObject ins;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<cshPlayerInteraction>().selecteditem.Equals("Repulsor")&&Input.GetMouseButton(0))
        {
            if (!isRay)
            {
                gameObject.GetComponent<FirstPersonController>().anim.SetBool("isSuperPower", true);
                ins = Instantiate(Ray, rayPos.position, rayPos.rotation);
                ins.transform.parent = GameObject.Find("PlayerCamera").transform;
                isRay = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            gameObject.GetComponent<FirstPersonController>().anim.SetBool("isSuperPower", false);
            Destroy(ins, 0.2f);
            isRay = false;
        }
    }
}
