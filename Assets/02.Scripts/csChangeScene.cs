using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class csChangeScene : MonoBehaviour
{
    GameObject me;

    // Start is called before the first frame update
    void Start()
    {
        me = GameObject.Find("FirstPersonController");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<=28)
        {
            SceneManager.LoadScene("SecondFloor2");
        }
        else if(SceneManager.GetActiveScene().name == "capstoneScene" && me.transform.position.x>=31 && me.transform.position.y >= 5.7f)
        {
            SceneManager.LoadScene("SecondFloor2");
        }
    }
}