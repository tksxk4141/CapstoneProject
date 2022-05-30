using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigBlit.ActivePack;

public class csOpenDoor2 : MonoBehaviour
{
    Vector3 position;
    Vector3 startPosition;
    public bool open = false;
    public bool close = false;
    GameObject lever;
    GameObject lever2;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        startPosition = transform.position;
        lever = GameObject.Find("Lever");
        lever2 = GameObject.Find("Lever2");
    }

    // Update is called once per frame
    void Update()
    {
        if ((lever.GetComponent<Lever>()._value == 1) || (lever2.GetComponent<Lever>()._value == 1))
        {
            open = true;
            close = false;
        }
        else if ((lever.GetComponent<Lever>()._value == 0) || (lever2.GetComponent<Lever>()._value == 0))
        {
            open = false;
            close = true;
        }
        if (open && transform.position.z > 11)
        {
            position.z -= 1 * Time.deltaTime;
            transform.position = position;
        }
        else if(close && transform.position.z < startPosition.z)
        {
            position.z += 1 * Time.deltaTime;
            transform.position = position;
        }
    }
}
