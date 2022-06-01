using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SecondTryFirstFloorTimelineController : MonoBehaviour
{
    public PlayableDirector playableDirector1;
    public PlayableDirector playableDirector2;
    public PlayableDirector playableDirector3;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha8))
        {
            GetComponentInChildren<SecondTryFirstFloorScriptManager>().isAdded = false;
            playableDirector1.gameObject.SetActive(true);
            playableDirector1.Play();
        }
        if (Input.GetKey(KeyCode.Alpha9))
        {
            GetComponentInChildren<SecondTryFirstFloorScriptManager>().isAdded = false;
            playableDirector2.gameObject.SetActive(true);
            playableDirector2.Play();
        }
        if (Input.GetKey(KeyCode.Alpha0))
        {
            GetComponentInChildren<SecondTryFirstFloorScriptManager>().isAdded = false;
            playableDirector3.gameObject.SetActive(true);
            playableDirector3.Play();
        }
    }

    public void PlayTimeline(PlayableDirector playableDirector)
    {
        GetComponentInChildren<SecondTryFirstFloorScriptManager>().isAdded = false;
        playableDirector.gameObject.SetActive(true);
        playableDirector.Play();
    }

}
