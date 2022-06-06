using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class cshSceneManager : MonoBehaviour
{
    public GameObject[] destination;
    public GameObject[] Player = new GameObject[2];
    
    public int currentScene = 0;
    public bool checkplayer1 = false;
    public bool checkplayer2 = false;
    public int checkDestination = 0;
    public bool SceneChanging = false;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player[0]==null || Player[1]==null)
            CheckPlayer();
        if (currentScene == 6 && !SceneChanging)
            StartCoroutine(CheckLocation2());
        if (currentScene != 6&&!SceneChanging)
            StartCoroutine(CheckLocation());
        /*
        if (currentScene == 5)
            csItemManager.instance.destination = 0;
        */
    }
    public void CheckPlayer()
    {
        Player[0] = GameObject.Find("Playerf(Clone)").transform.Find("SurvGirl").gameObject;
        Player[1] = GameObject.Find("Playerm(Clone)").transform.Find("SurvMan").gameObject;
    }
    IEnumerator CheckLocation()
    {
        Collider[] check1 = Physics.OverlapSphere(destination[0].transform.position, 3);

        for (int i = 0; i < check1.Length; i++)
        {
            if (check1[i].transform.name.Equals("Playerf(Clone)"))
            {
                checkplayer1 = true;
            }
            if (check1[i].transform.name.Equals("Playerm(Clone)"))
            {
                checkplayer2 = true;
            }
        }


        if (checkplayer1 && checkplayer2)
        {
            SceneChange();
        }

        yield return null;
    }
    IEnumerator CheckLocation2()
    {
        Collider[] check2 = Physics.OverlapSphere(destination[1].transform.position, 3);

        for (int i = 0; i < check2.Length; i++)
        {
            if (check2[i].transform.name.Equals("Playerf(Clone)"))
            {
                checkplayer1 = true;
                checkDestination++;
            }
            if (check2[i].transform.name.Equals("Playerm(Clone)"))
            {
                checkplayer2 = true;
                checkDestination++;
            }
        }
        
        if (checkDestination >= 2 && checkplayer1 && checkplayer2)
        {
            csItemManager.instance.destination = 1;
            SceneChange2();
        }
        yield return null;
    }

    void SceneChange()
    {
        StopCoroutine(CheckLocation());
        SceneChanging = true;
        if(PhotonNetwork.IsMasterClient)
            PhotonNetwork.LoadLevel(currentScene + 1);
    }
    void SceneChange2()
    {
        StopCoroutine(CheckLocation2());
        SceneChanging = true;
        if (PhotonNetwork.IsMasterClient)
            PhotonNetwork.LoadLevel(currentScene + 1);
    }
}