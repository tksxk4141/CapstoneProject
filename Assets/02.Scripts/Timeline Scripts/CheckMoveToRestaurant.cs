using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CheckMoveToRestaurant : MonoBehaviour
{
    bool checkPlayer1 = false;
    bool checkPlayer2 = false;

    public GameObject timelineController;

    public PlayableDirector playableDirector;

    public bool isPlayed = false;
    public bool isPlayedTimeline2 = false;

    GameObject isTimeline1;

    void Start()
    {
        isTimeline1 = GameObject.Find("2nd_SecondFloorScriptManager");
    }


    void Update()
    {
        Collider[] checkpoint = Physics.OverlapSphere(this.transform.position, 2.5f);
        for (int i = 0; i < checkpoint.Length; i++)
        {
            if (isTimeline1.GetComponent<SecondTrySecondFloorScriptManager>().checkrestaurant)
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

            

        }
        if (checkPlayer1 && checkPlayer2 
            && !isPlayed && isPlayedTimeline2)
        {
            
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                timelineController.GetComponent<SecondFloorTimelineController>().PlayTimeline(playableDirector);
                isPlayed = true;
            }
            if (SceneManager.GetActiveScene().buildIndex == 7)
            {
                timelineController.GetComponent<SecondTrySecondFloorTimelineController>().PlayTimeline(playableDirector);
                isPlayed = true;
            }
        }


    }
}
