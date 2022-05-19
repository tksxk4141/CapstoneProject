using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;//path�������
using UnityEngine.SceneManagement;


public class cshPlayerManager : MonoBehaviourPunCallbacks
{
    PhotonView PV;//����� ����
    GameObject controller;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        if (PV.IsMine)//�� ���� ��Ʈ��ũ�̸�
        {
            CreateController();//�÷��̾� ��Ʈ�ѷ� �ٿ��ش�. 
        }
    }
    void CreateController()//�÷��̾� ��Ʈ�ѷ� �����
    {
        Transform spawnpoint = cshSpawnManager.Instance.GetSpawnpoint(cshLoginValue.usernum);
        Debug.Log("Instantiated Player Controller");
        controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"), spawnpoint.position, spawnpoint.rotation, 0, new object[] { PV.ViewID });
        //���� �����鿡 �ִ� �÷��̾� ��Ʈ�ѷ��� �� ��ġ�� �� ������ ������ֱ�
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(1);
        //Destroy(gameObject);
    }
}