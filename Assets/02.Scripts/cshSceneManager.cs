using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class cshSceneManager : MonoBehaviour
{
    public GameObject[] destination;
    public GameObject[] Player = new GameObject[2];
    
    int currentScene = 0;
    bool checkplayer1 = false;
    bool checkplayer2 = false;
    bool SceneChanging = false;
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

        if (!SceneChanging)
            StartCoroutine(CheckLocation());
    }
    public void CheckPlayer()
    {
        Player[0] = GameObject.Find("Playerf(Clone)").transform.Find("SurvGirl").gameObject;
        Player[1] = GameObject.Find("Playerm(Clone)").transform.Find("SurvMan").gameObject;
    }
    IEnumerator CheckLocation()
    {
        Collider[] check1 = Physics.OverlapSphere(destination[0].transform.position, 1);
        Collider[] check2 = Physics.OverlapSphere(destination[1].transform.position, 2);

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
            if(checkplayer1&&checkplayer2)
                SceneChange();
        }
        for (int i = 0; i < check2.Length; i++)
        {
            if (check2[i].transform.name.Equals("Playerf(Clone)"))
            {
                checkplayer1 = true;
            }
            if (check2[i].transform.name.Equals("Playerm(Clone)"))
            {
                checkplayer2 = true;
            }
            if (checkplayer1 && checkplayer2)
            {
                csItemManager.instance.destination = 1;
                SceneChange();
            }
        }
        yield return null;
    }
    void SceneChange()
    {
        StopCoroutine(CheckLocation());
        SceneChanging = true;
        PhotonNetwork.LoadLevel(currentScene + 1);
    }
}