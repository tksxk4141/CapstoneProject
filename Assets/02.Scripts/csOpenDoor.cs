using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class csOpenDoor : MonoBehaviour
{
    Vector3 position;
    public bool open;
    GameObject btn;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "capstoneScene")
        {
            position = transform.position;
            btn = GameObject.Find("ButtonHead C3B");
            open = false;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "capstoneScene")
        {
            if (btn.transform.position.z<-5.7f)
            {
               if (GameObject.Find("Electronic").GetComponent<csTurnOnElec>().turnOn)
                    open = true;
            }
            if (open && transform.position.x > 28)
            {
                position.x -= 1 * Time.deltaTime;
                transform.position = position;
            }
        }        
    }
}
