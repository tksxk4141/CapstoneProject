using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;//path사용위해
using UnityEngine.SceneManagement;


public class cshPlayerManager : MonoBehaviourPunCallbacks
{
    PhotonView PV;//포톤뷰 선언
    GameObject controller;
    Transform spawnpoint;
    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        if (PV.IsMine)//내 포톤 네트워크이면
        {
            CreateController();//플레이어 컨트롤러 붙여준다.
            GameObject.Find("SceneManager").GetComponent<cshSceneManager>().CheckPlayer();
        }
    }
    void CreateController()//플레이어 컨트롤러 만들기
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
        //포톤 프리펩에 있는 플레이어 컨트롤러를 저 위치에 저 각도로 만들어주기
    }

}