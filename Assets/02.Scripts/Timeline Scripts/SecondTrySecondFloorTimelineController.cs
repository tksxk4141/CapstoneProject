using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class SecondTrySecondFloorTimelineController : MonoBehaviour
{
    public PlayableDirector[] playableDirectors = new PlayableDirector[10];

    public int storyFlag;

    void Start()
    {
        
    }


    void Update()
    {

    }

    public void PlayTimeline(PlayableDirector playableDirector)
    {
        GetComponentInChildren<SecondTrySecondFloorScriptManager>().isAdded = false;
        playableDirector.gameObject.SetActive(true);
        playableDirector.Play();
    }

    public void PlayAfterTimeline5()
    {
        storyFlag = cshRoomManager.Instance.storyFlag;
        if (storyFlag == 0)
        {
            PlayTimeline(playableDirectors[7]);

        }
        else
        {
            PlayTimeline(playableDirectors[6]);
        }
    }

   
    public void DestroyButton(GameObject button)
    {
        button.SetActive(false);
    }

    public void IsFlag()
    {
        cshRoomManager.Instance.storyFlag++;
    }

}
