using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csInFire : MonoBehaviour
{
    Vector3 hang;
    Vector3 hang2;
    public Transform hangPos;
    // Start is called before the first frame update
    void Start()
    {
        hang = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        hang = gameObject.transform.position;
        if (GetComponent<FirstPersonController>().isHanging) //매달린 상태면
        {
            hang2 = new Vector3(hang.x, 2.8f, 36.3f);
            gameObject.transform.position = hang2;
            gameObject.transform.rotation = hangPos.rotation;
            if (Input.GetKey(KeyCode.Space))
            {
                GetComponent<FirstPersonController>().isHanging = false;
            }
        }

    }
    private void OnTriggerStay(Collider other) //불에 데미지 입음
    {
        if(other.gameObject.tag == "Fire")
        {
            GetComponent<cshPlayerInteraction>().hp -= Time.deltaTime;
        }
    }
    private void OnCollisionEnter(Collision col) //파이프에 매달리기
    {
        if (col.gameObject.tag == "Pipe")
        {
            GetComponent<FirstPersonController>().isHanging = true;
        }
    }
}
