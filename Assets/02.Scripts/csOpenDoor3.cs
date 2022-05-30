using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csOpenDoor3 : MonoBehaviour
{
    Vector3 position;
    public Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < -5)
        {
            position.x += 1 * Time.deltaTime;
            transform.position = position;
        }
        else
        {
            this.enabled = false;
            position = startPosition;
        }
    }
}
