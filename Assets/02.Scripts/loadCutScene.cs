using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadCutScene : MonoBehaviour
{
    bool checkPlayer1 = false;
    bool checkPlayer2 = false;
    bool isPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] checkpoint = Physics.OverlapSphere(this.transform.position, 2.0f);
        for (int i = 0; i < checkpoint.Length; i++)
        {
            if (checkpoint[i].transform.name == "Playerf(Clone)")
            {
                checkPlayer1 = true;
            }
            if (checkpoint[i].transform.name == "Playerm(Clone)")
            {
                checkPlayer2 = true;
            }
        }
        if (checkPlayer1 && checkPlayer2 && !isPlayed)
        {
            if(SceneManager.GetActiveScene().buildIndex==5)
               loadCut();
            if (SceneManager.GetActiveScene().buildIndex == 8)
                loadCut2();
            isPlayed = true;
        }

    }

    public void loadCut()
    {
        if (PhotonNetwork.IsMasterClient)
            PhotonNetwork.LoadLevel(17);
    }
    public void loadCut2()
    {
        if (PhotonNetwork.IsMasterClient)
            PhotonNetwork.LoadLevel(18);
    }
}
