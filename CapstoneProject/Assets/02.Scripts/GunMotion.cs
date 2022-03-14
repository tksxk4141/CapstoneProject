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

    public GameObject rightHand;//rightHand��ü�� Ʈ�� ����� �־� .Find�� �����ɸ���� public���� ���� ��ġ
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
    {   //Update �Լ����� while������ ����Ƽ�� ���缭 �ڷ�ƾ ���
        //���ϴ� Rig�� Weight�� 0���� 1�� ��������
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
        {   //ZŰ�� �����ݱ�
            anim.SetBool("isPickUp", true);
        }
        float handGunDistance;
        handGunDistance = Vector3.Distance(rightHand.transform.position, scifiGun.transform.position);
        if (handGunDistance <= 0.5f)
        {   //���� ����鶧 �����հ� ���� �Ÿ��� 0.5f���Ϸ� ���������
            //���� ���� �θ𰡵�
            putGunRig.weight = 1;

        }



        if (Input.GetKeyDown(KeyCode.G))
        {   //GŰ�� ��ġ�ϱ�
            touchFlag++;
            if(touchFlag == 1)
            {
                anim.SetBool("isTouch", true);
                //lerpRigWeight�ڷ�ƾ ������ lerpTime �� �ʱ�ȭ�ʼ�, ���ϸ� ù�ٿ��� yield break
                lerpTime = 0.0f;
                StartCoroutine(lerpRigWeight(touchRig));
            }
            if(touchFlag == 2)
            {   //GŰ �ѹ� �������� ��ġ ���
                anim.SetBool("isTouch", false);
                touchRig.weight = 0;
                touchFlag = 0;
            }
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            holdGunFlag++;
            if (holdGunFlag == 1)
            {   //�� ����, idle���·� ��ȯ
                anim.SetBool("isIdle", true);

                //lerpRigWeight�ڷ�ƾ ������ lerpTime �� �ʱ�ȭ�ʼ�, ���ϸ� ù�ٿ��� yield break
                lerpTime = 0.0f;
                StartCoroutine(lerpRigWeight(holdGunRig));

            }
            if (holdGunFlag == 2)
            {   //�����̽��� �ι�° ��������
                //�ȿ� ����� rig�� weight�� 0���� �� �� ��������, idle���� �����ϰ� run���·� ����

                holdGunRig.weight = 0;
                anim.SetBool("isIdle", false);
                holdGunFlag = 0;
            }
        }
        


    }
}
