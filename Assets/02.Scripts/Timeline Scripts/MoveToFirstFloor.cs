using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class MoveToFirstFloor : MonoBehaviour
{

    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
            PhotonNetwork.LoadLevel(6);
    }

    void Update()
    {
        
    }
}
