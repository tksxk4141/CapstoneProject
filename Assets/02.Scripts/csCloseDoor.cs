using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csCloseDoor : MonoBehaviour
{
    Vector3 position;
    Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (position.x > GetComponent<csOpenDoor4>().startPosition.x)
        {
            position.x -= 1 * Time.deltaTime;
            transform.position = position;
        }
        else
        {
            this.enabled = false;
            position = lastPosition;
        }
    }
}
