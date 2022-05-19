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

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        if (PV.IsMine)//내 포톤 네트워크이면
        {
            CreateController();//플레이어 컨트롤러 붙여준다. 
        }
    }
    void CreateController()//플레이어 컨트롤러 만들기
    {
        Transform spawnpoint = cshSpawnManager.Instance.GetSpawnpoint(cshLoginValue.usernum);
        Debug.Log("Instantiated Player Controller");
        controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"), spawnpoint.position, spawnpoint.rotation, 0, new object[] { PV.ViewID });
        //포톤 프리펩에 있는 플레이어 컨트롤러를 저 위치에 저 각도로 만들어주기
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(1);
        //Destroy(gameObject);
    }
}