using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csMainBoard : MonoBehaviour
{
    bool up = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Light>().intensity <= 1) 
        {
            up = true;    
        }
        else if (GetComponent<Light>().intensity >= 10)
        {
            up = false;
        }
        if (up)
        {
            GetComponent<Light>().intensity += 10.0f * Time.deltaTime;
        }
        else
        {
            GetComponent<Light>().intensity -= 10.0f * Time.deltaTime;
        }
        
    }
}
