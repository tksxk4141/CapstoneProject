using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SecondFloorTimelineController : MonoBehaviour
{
    public PlayableDirector playableDirector1;
    public PlayableDirector playableDirector2;
    public PlayableDirector playableDirector3;
    public PlayableDirector playableDirector4;
    public PlayableDirector playableDirector5;

    void Start()
    {

    }


    void Update()
    {
        

    }

    public void PlayTimeline(PlayableDirector playableDirector)
    {
        GetComponentInChildren<SecondFloorScriptManager>().isAdded = false;
        playableDirector.gameObject.SetActive(true);
        playableDirector.Play();
    }

}
