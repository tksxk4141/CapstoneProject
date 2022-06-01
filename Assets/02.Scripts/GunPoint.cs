using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPoint : MonoBehaviour
{
    public GameObject Gun;
    public GameObject point;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = point.GetComponent<Transform>().position;

        Gun.transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
