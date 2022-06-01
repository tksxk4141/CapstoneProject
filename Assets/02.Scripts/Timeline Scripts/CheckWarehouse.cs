using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWarehouse : MonoBehaviour
{
    GameObject checkElevator;
    void Start()
    {
        checkElevator = GameObject.Find("CheckElevator");
    }

    void Update()
    {
        Collider[] checkpoint = Physics.OverlapSphere(this.transform.position, 3f);
        for (int i = 0; i < checkpoint.Length; i++)
        {
            if (checkpoint[i].transform.name == "Playerf(Clone)"
                || checkpoint[i].transform.name == "Playerm(Clone)")
            {
                checkElevator.GetComponent<CheckElevator>().checkWarehouse = true;
            }
        }
    }
}
