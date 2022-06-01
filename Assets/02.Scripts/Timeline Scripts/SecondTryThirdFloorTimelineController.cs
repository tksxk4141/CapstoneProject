using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SecondTryThirdFloorTimelineController : MonoBehaviour
{
    public PlayableDirector playableDirector1;
    public PlayableDirector playableDirector2;
    public PlayableDirector playableDirector3;
    public PlayableDirector playableDirector4;
    public PlayableDirector playableDirector5;
    public PlayableDirector playableDirector6;
    public PlayableDirector playableDirector7;

    public int storyFlag;


    GameObject playerf;
    GameObject playerm;

    void Start()
    {
        storyFlag = cshRoomManager.Instance.storyFlag;

        playerf = GameObject.Find("Playerf(Clone)");
        playerm = GameObject.Find("Playerm(Clone)");
    }


    void Update()
    {

        


    }


    public void PlayTimeline(PlayableDirector playableDirector)
    {
        GetComponentInChildren<SecondTryThirdFloorScriptManager>().isAdded = false;
        playableDirector.gameObject.SetActive(true);
        playableDirector.Play();
    }

    public void DestroyButton(GameObject button)
    {
        button.SetActive(false);

        //컷씬 동영상 끝나면 원래 플레이어 다시 켜기
        playerf.SetActive(true);
        playerm.SetActive(true);
    }


    public void PlayTimeline2()
    {
        PlayTimeline(playableDirector2);
    }

    public void PlayAfterTimeline4()
    {
        if (storyFlag == 0)
        {
            //Ending_SelectMan0
            PlayTimeline(playableDirector5);

        }
        else
        {
            //Ending_SelectMan1
            PlayTimeline(playableDirector6);

        }
    }


    public void PlayAfterTimeline6()
    {
        PlayTimeline(playableDirector7);

    }
}
