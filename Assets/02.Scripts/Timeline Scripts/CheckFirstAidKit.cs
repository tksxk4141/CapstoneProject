using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CheckFirstAidKit : MonoBehaviour
{
    bool checkPlayer1 = false;

    public GameObject timelineController;

    public PlayableDirector playableDirector;

    public bool isPlayed = false;

    GameObject checkMoveToRestaurant;

    void Start()
    {
        checkMoveToRestaurant = GameObject.Find("CheckMoveToRestaurant");
    }


    void Update()
    {
        Collider[] checkpoint = Physics.OverlapSphere(this.transform.position, 2.5f);
        for (int i = 0; i < checkpoint.Length; i++)
        {
            if (checkpoint[i].transform.name == "Playerf(Clone)")
            {
                checkPlayer1 = true;
            }
            
        }
        if (checkPlayer1 && !isPlayed)
        {
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                timelineController.GetComponent<SecondFloorTimelineController>().PlayTimeline(playableDirector);
                isPlayed = true;
                checkMoveToRestaurant.GetComponent<CheckMoveToRestaurant>().isPlayedTimeline2 = true;
            }
            if (SceneManager.GetActiveScene().buildIndex == 7)
            {
                timelineController.GetComponent<SecondTrySecondFloorTimelineController>().PlayTimeline(playableDirector);
                isPlayed = true;
                checkMoveToRestaurant.GetComponent<CheckMoveToRestaurant>().isPlayedTimeline2 = true;
            }
            
        }
    }
}
