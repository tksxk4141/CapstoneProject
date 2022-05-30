using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csIceage : MonoBehaviour
{
    float timer;
    public GameObject frozen;
    bool status = false;
    GameObject[] fire;
    void Start()
    {
        fire = GameObject.FindGameObjectsWithTag("Fire");
    }
 
    void Update()
    {
        if (status)
        {
            timer += Time.deltaTime;
            if (timer >= 1.0f)
            {
                status = false;
                Instantiate(frozen, gameObject.transform.position, Quaternion.identity);
                for(int i=0; i < fire.Length; i++)
                {
                    if((Mathf.Abs(fire[i].transform.position.x - gameObject.transform.position.x) <10) && (Mathf.Abs(fire[i].transform.position.z - gameObject.transform.position.z) < 10))
                    {
                        Destroy(fire[i]);
                    }
                   
                }
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Floor")
        {
            status = true;
           
        }
    }
}
