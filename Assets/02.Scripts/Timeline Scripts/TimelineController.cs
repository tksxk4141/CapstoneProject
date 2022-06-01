using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector playableDirector;
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            playableDirector.gameObject.SetActive(true);
            playableDirector.Play();
        }   
    }
}
