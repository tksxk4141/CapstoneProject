using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CheckLastDoor : MonoBehaviour
{
    public GameObject timelineController;

    public PlayableDirector playableDirector;

    public bool isPlayed = false;
    public bool checkPlayer1 = false;
    public bool checkPlayer2 = false;

    public bool isExitMiro = false;

    bool isPlayedTimeline2 = false;


    void Start()
    {

    }


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
            timelineController.GetComponent<SecondTryThirdFloorTimelineController>().PlayTimeline(playableDirector);
            isPlayed = true;
        }

        if (checkPlayer1 && checkPlayer2 && !isPlayedTimeline2 && isExitMiro)
        {
            //��ǻ�� �̷� Ż�� �� �������� ������ 2�� Ÿ�Ӷ���(��/���� ����) ����
            timelineController.GetComponent<SecondTryThirdFloorTimelineController>().PlayTimeline2();
            isPlayedTimeline2 = true;
        }

        checkPlayer1 = false;
        checkPlayer2 = false;

    }



}
