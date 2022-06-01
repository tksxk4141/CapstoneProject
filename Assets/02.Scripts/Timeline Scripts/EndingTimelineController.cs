using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class EndingTimelineController : MonoBehaviour
{

    public PlayableDirector playableDirector;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            playableDirector.gameObject.SetActive(true);
            playableDirector.Play();
        }
    }
}
