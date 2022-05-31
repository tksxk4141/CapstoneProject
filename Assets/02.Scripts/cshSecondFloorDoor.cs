using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshSecondFloorDoor : MonoBehaviour
{
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 52)
        {
            position.x -= 1 * Time.deltaTime;
            transform.position = position;
        }
    }
}
