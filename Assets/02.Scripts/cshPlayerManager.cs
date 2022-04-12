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
        controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), spawnpoint.position, spawnpoint.rotation, 0, new object[] { PV.ViewID });
        //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"), Vector3.zero, Quaternion.identity);
        //���� �����鿡 �ִ� �÷��̾� ��Ʈ�ѷ��� �� ��ġ�� �� ������ ������ֱ�
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        //PhotonNetwork.LeaveLobby();
        PhotonNetwork.LoadLevel(1);
        //SceneManager.LoadScene("LobbyScene");
        //Destroy(gameObject);
    }
}