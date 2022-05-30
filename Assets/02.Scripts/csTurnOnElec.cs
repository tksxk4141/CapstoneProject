using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigBlit.ActivePack;

public class csTurnOnElec : MonoBehaviour
{
    Vector3 position;
    GameObject lever;
    public bool turnOn;
    float pos;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        lever = GameObject.FindWithTag("lever");
        turnOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (lever.GetComponent<Lever>()._value == 1)
        {
            turnOn = true;
            GameObject.Find("ElecLight").GetComponent<Light>().color = Color.green;
        }
        else
        {
            turnOn = false;
            GameObject.Find("ElecLight").GetComponent<Light>().color = Color.yellow;
        }
        if (turnOn)
        {
            pos = Random.Range(-0.005f, 0.005f);
            position.x += pos;
            transform.position = position;
        }
    }
}
