using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csIceSound : MonoBehaviour
{
    AudioSource audio;
    public AudioClip frozen;
    public AudioClip bomb;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.PlayOneShot(frozen);
        audio.PlayOneShot(bomb);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
