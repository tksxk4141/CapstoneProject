using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csInFire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other) //불에 데미지 입음
    {
        if(other.gameObject.tag == "Fire")
        {
            if(GetComponent<cshPlayerInteraction>().hp > 0)
            {
                GetComponent<cshPlayerInteraction>().hp -= Time.deltaTime * 20.0f;
            }
            
        }
    }
}
