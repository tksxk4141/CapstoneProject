using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cshIntroToGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        if (PhotonNetwork.IsMasterClient)
            PhotonNetwork.LoadLevel(2);
        // 다음신 로딩용, 따옴표에 신 이름 넣으면 된다고 한다.
        // NextSceneLoader등의 빈 오브젝트 만들고 타임라인에서 액티브.
    }
}
