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
    Transform spawnpoint;
    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        if (PV.IsMine)//�� ���� ��Ʈ��ũ�̸�
        {
            CreateController();//�÷��̾� ��Ʈ�ѷ� �ٿ��ش�.
            GameObject.Find("SceneManager").GetComponent<cshSceneManager>().CheckPlayer();
        }
    }
    void CreateController()//�÷��̾� ��Ʈ�ѷ� �����
    {
        Debug.Log("Instantiated Player Controller");

        if((SceneManager.GetActiveScene().buildIndex == 3 && csItemManager.instance.destination == 1) || (SceneManager.GetActiveScene().buildIndex == 7&& csItemManager.instance.destination==1))
            spawnpoint = cshSpawnManager.Instance.GetSpawnpoint(cshLoginValue.usernum+2);
        else 
        {
            spawnpoint = cshSpawnManager.Instance.GetSpawnpoint(cshLoginValue.usernum);
        }
        if (cshLoginValue.usernum==0)
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Playerf"), spawnpoint.position, spawnpoint.rotation, 0, new object[] { PV.ViewID });
        else if(cshLoginValue.usernum==1)
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Playerm"), spawnpoint.position, spawnpoint.rotation, 0, new object[] { PV.ViewID });
        //���� �����鿡 �ִ� �÷��̾� ��Ʈ�ѷ��� �� ��ġ�� �� ������ ������ֱ�
    }

}