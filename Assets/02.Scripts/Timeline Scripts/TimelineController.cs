using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Photon.Pun;
using UnityEngine.Timeline;

public class TimelineController : MonoBehaviour
{
    GameObject playerf;
    GameObject playerm;
    public PlayableDirector playableDirector;
    public TimelineAsset timeline;

    void Start()
    {

    }


    void Update()
    {

    }

    public void PlayTimeline(PlayableDirector playableDirector)
    {

        GetComponent<ThirdFloorTryToOpenDoorScriptManager>().isAdded = false;
        this.transform.GetChild(1).gameObject.SetActive(true);
        GameObject.Find("Playerf(Clone)").SetActive(false);
        GameObject.Find("Playerm(Clone)").SetActive(false);
        playableDirector.gameObject.SetActive(true);
        playableDirector.Play(timeline);
    }


}
