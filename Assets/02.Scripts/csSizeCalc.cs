using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csSizeCalc : MonoBehaviour
{
    public bool isSmall = false;
    float timer = 3.0f;
    bool isSkilltime = false;
    bool useWingShoes = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isSkilltime)
        {
            timer -= Time.deltaTime;
        }
        if (gameObject.GetComponent<cshPlayerInteraction>().selecteditem.Equals("WingShoes"))
        {
            useWingShoes = true;
        }
        else
        {
            useWingShoes = false;
        }
        if (isSmall)
        {
            gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            GetComponent<FirstPersonController>().walkSpeed = 2f;
            if (useWingShoes) 
            {
                GetComponent<FirstPersonController>().jumpPower = 6f;
            }
            else
            {
                GetComponent<FirstPersonController>().jumpPower = 2f;
            }
        }
        else if (!isSmall)
        {
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            GetComponent<FirstPersonController>().walkSpeed = 5f;
            if (useWingShoes)
            {
                GetComponent<FirstPersonController>().jumpPower = 15f;
            }
            else
            {
                GetComponent<FirstPersonController>().jumpPower = 5f;
            }
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Portal")
        {
            if (!isSmall)
            {
                isSmall = true;
                isSkilltime = true;
            }
            else if (isSmall && timer<0.0f)
            {
                isSmall = false;
                isSkilltime = false;
                timer = 3.0f;
            }
        }
    }
}
