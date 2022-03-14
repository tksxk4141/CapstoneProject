using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class GunMotion : MonoBehaviour
{
    Animator anim;
    Rig holdGunRig;
    Rig putGunRig;
    Rig touchRig;
    float lerpTime;

    public GameObject rightHand;//rightHand객체가 트리 깊숙히 있어 .Find가 오래걸릴까봐 public으로 직접 배치
    GameObject scifiGun;
    int touchFlag;
    int holdGunFlag;

    void Start()
    {

        anim = GetComponent<Animator>();
        holdGunRig = GameObject.Find("HoldGunRig").GetComponent<Rig>();
        putGunRig = GameObject.Find("PutGunRig").GetComponent<Rig>();
        touchRig = GameObject.Find("TouchRig").GetComponent<Rig>();
        scifiGun = GameObject.Find("SciFiGunLightBlue");

        holdGunRig.weight = 0;
        putGunRig.weight = 0;
        touchRig.weight = 0;

        lerpTime = 0.0f;

        touchFlag = 0;
        holdGunFlag = 0;
    }
    IEnumerator lerpRigWeight(Rig rig) 
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
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {   //Z키로 물건줍기
            anim.SetBool("isPickUp", true);
        }
        float handGunDistance;
        handGunDistance = Vector3.Distance(rightHand.transform.position, scifiGun.transform.position);
        if (handGunDistance <= 0.5f)
        {   //총을 집어들때 오른손과 총의 거리가 0.5f이하로 가까워지면
            //손이 총의 부모가됨
            putGunRig.weight = 1;

        }



        if (Input.GetKeyDown(KeyCode.G))
        {   //G키로 터치하기
            touchFlag++;
            if(touchFlag == 1)
            {
                anim.SetBool("isTouch", true);
                //lerpRigWeight코루틴 시작전 lerpTime 꼭 초기화필수, 안하면 첫줄에서 yield break
                lerpTime = 0.0f;
                StartCoroutine(lerpRigWeight(touchRig));
            }
            if(touchFlag == 2)
            {   //G키 한번 더누르면 터치 취소
                anim.SetBool("isTouch", false);
                touchRig.weight = 0;
                touchFlag = 0;
            }
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            holdGunFlag++;
            if (holdGunFlag == 1)
            {   //총 조준, idle상태로 전환
                anim.SetBool("isIdle", true);

                //lerpRigWeight코루틴 시작전 lerpTime 꼭 초기화필수, 안하면 첫줄에서 yield break
                lerpTime = 0.0f;
                StartCoroutine(lerpRigWeight(holdGunRig));

            }
            if (holdGunFlag == 2)
            {   //스페이스바 두번째 눌렀을때
                //팔에 적용된 rig의 weight를 0으로 해 총 내려놓기, idle상태 해제하고 run상태로 변경

                holdGunRig.weight = 0;
                anim.SetBool("isIdle", false);
                holdGunFlag = 0;
            }
        }
        


    }
}
