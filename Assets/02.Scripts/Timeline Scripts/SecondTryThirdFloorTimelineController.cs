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

    public int storyFlag = 0;


    GameObject playerf;
    GameObject playerm;

    private void Awake()
    {
        playerf = GameObject.Find("Playerf(Clone)");
        playerm = GameObject.Find("Playerm(Clone)");
    }

    void Start()
    {
        storyFlag = cshRoomManager.Instance.storyFlag;

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
        EndingScriptManager.instance.StopCoroutine(EndingScriptManager.SetCursor());
        Cursor.lockState = CursorLockMode.Locked;

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
