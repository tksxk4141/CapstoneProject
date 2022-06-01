using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;


public class CheckFristMeet : MonoBehaviour
{
    bool checkPlayer1 = false;
    bool checkPlayer2 = false;

    public GameObject timeLine;

    public PlayableDirector playableDirector;

    public bool isPlayed = false;

    void Start()
    {
        
    }

   

    void Update()
    {
        Collider[] checkpoint = Physics.OverlapSphere(this.transform.position, 6.5f);
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
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                timeLine.GetComponent<FirstFloorTimelineController>().PlayTimeline(playableDirector);
                isPlayed = true;
            }
            if (SceneManager.GetActiveScene().buildIndex == 6)
            {
                timeLine.GetComponent<SecondTryFirstFloorTimelineController>().PlayTimeline(playableDirector);
                isPlayed = true;
            }
        }
    }
}
