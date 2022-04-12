using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class cshPlayerController : MonoBehaviour
{
    [SerializeField] float mouseSensitivity, sprintSpeed, walkSpeed, jumpForce, smoothTime;
    [SerializeField] GameObject cameraHolder;
    //���콺���� �ٴ¼ӵ� �ȴ¼ӵ� ������ �ٱ�ȱ�ٲܶ� ���ӽð�
    float verticalLookRotation;
    bool grounded;//������ ���� �ٴ�üũ
    Vector3 smoothMoveVelocity;
    Vector3 moveAmount;//���� �̵��Ÿ�

    Rigidbody rb;
    PhotonView PV;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        if (!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            //���� �ƴϸ� ī�޶� ���ֱ�
            Destroy(rb);
            //���žƴϸ� ������ �ٵ� �����ֱ�
        }
    }

    void Update()
    {
        if (!PV.IsMine)
            return;//�����ƴϸ� �۵�����
        Look();
        Move();
        Jump();
    }

    void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity);
        //���콺 �����̴� ����*�ΰ�����ŭ ���� �����̱�
        verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivity;
        //���콺 �����̴� ����*�ΰ�����ŭ ���� �� �ޱ�
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        //y�� -90������ 90���� ������ ����
        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
        //���� ������ ī�޶� ������
    }

    void Move()
    {
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        //���������� �������� ũ��� 1�� �븻������
        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);
        //���� ����Ʈ�� ������ �ٴ¼ӵ�, �������� �ȴ¼ӵ����ϱ�
        //smoothTime��ŭ�� ���ļ� �̵����ֱ�. 
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)//�������� �����̽��� ������
        {
            rb.AddForce(transform.up * jumpForce);//�����¸�ŭ���� ������
        }
    }

    public void SetGroundedState(bool _grounded)
    {
        grounded = _grounded;
    }

    void FixedUpdate()
    {
        if (!PV.IsMine)
            return;//�����ƴϸ� �۵�����
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
        //�̵��ϴ°Ŵ� ��� ���� moveAmount��ŭ�� �����Ƚð�(0.2��)���ٿ� ���缭
    }
}
