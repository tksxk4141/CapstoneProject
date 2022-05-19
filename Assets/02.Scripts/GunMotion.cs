using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class GunMotion : MonoBehaviour
{
    Animator anim;
    Rig putGunRig;
    float lerpTime;

    //public LayerMask itemLayer;


    void Start()
    {

        anim = GetComponent<Animator>();
        putGunRig = GameObject.Find("PutGunRig").GetComponent<Rig>();

        putGunRig.weight = 0;

        lerpTime = 0.0f;

    }
    IEnumerator LerpRigWeight(Rig rig) 
    {   //Update 함수에서 while문쓰니 유니티가 멈춰서 코루틴 사용
        //원하는 Rig의 Weight를 0에서 1로 선형보간
        while (true)
        {
            if (lerpTime > 1.0f) { yield break; }
            lerpTime += Time.deltaTime;
            rig.weight = Mathf.Lerp(0.0f, 1.0f, lerpTime);

            yield return null;
        }
    }

    void Update()
    {
        //RayItem();


    }


    //Z키로 물건 줍는 모션 시 물건과 손이 충돌하면 rig 이용해 손과 물건 붙임
    /*
    private void RayItem()
    {
        Vector3 origin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 direction = transform.TransformDirection(Vector3.down);
        float distance = 5.0f;
        RaycastHit hit;
        

        if (Physics.Raycast(origin, direction, out hit, 10, itemLayer))
        {
            float hitDistance = hit.distance;
            if (hitDistance < distance)
            {
                putGunRig.weight = 1;
            }

        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");

        if (other.gameObject.tag == "Item")
        {
            putGunRig.weight = 1;
            Debug.Log("aaaaaaaaaaaaaa");
        }
    }

    

}
