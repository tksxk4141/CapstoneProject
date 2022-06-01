using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FirstFloorTimelineController : MonoBehaviour
{
    public PlayableDirector playableDirector1;
    public PlayableDirector playableDirector2;
    public PlayableDirector playableDirector3;

    void Start()
    {

    }


    void Update()
    {
    }

    public void PlayTimeline(PlayableDirector playableDirector)
    {
        GetComponentInChildren<FirstFloorScriptManager>().isAdded = false;
        playableDirector.gameObject.SetActive(true);
        playableDirector.Play();
    }

}
