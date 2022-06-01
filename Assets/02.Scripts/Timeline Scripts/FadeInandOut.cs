using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class FadeInandOut : MonoBehaviour
{
    public GameObject FadeIn;
    public GameObject FadeOut;
    public PlayableDirector playableDirector;

    public float[] FadeInTimeLeft;
    public float[] FadeOutTimeLeft;

    private float FadeInnextTime = 0.0f;
    private float FadeOutnextTime = 0.0f;

    int fadeincount = 0;
    int fadeoutcount = 0;

    // Start is called before the first frame update
    void Start()
    {
        playableDirector.initialTime = Time.time;
        FadeInnextTime = FadeInTimeLeft[0];
        FadeOutnextTime = FadeOutTimeLeft[0];
    }

    // Update is called once per frame
    void Update()
    {
        if ((float)playableDirector.time >= FadeInnextTime && fadeincount< FadeInTimeLeft.Length) {
            startFadeIn();
            if (fadeincount < FadeInTimeLeft.Length)
            {
                if (fadeincount == 0)
                {
                    FadeInnextTime = (float)playableDirector.time + FadeInTimeLeft[fadeincount];
                }
                else
                {
                    FadeInnextTime = (float)playableDirector.time + FadeInTimeLeft[fadeincount] - FadeInTimeLeft[fadeincount - 1];
                }
            }
        }
        if ((float)playableDirector.time >= FadeOutnextTime && fadeoutcount < FadeOutTimeLeft.Length)
        {
            startFadeOut();
            if (fadeoutcount < FadeOutTimeLeft.Length)
            {
                if (fadeoutcount == 0)
                {
                    FadeOutnextTime = (float)playableDirector.time + FadeOutTimeLeft[fadeoutcount];
                }
                else
                {
                    FadeOutnextTime = (float)playableDirector.time + FadeOutTimeLeft[fadeoutcount]- FadeOutTimeLeft[fadeoutcount-1];
                }
            }
        }
    }
    void startFadeIn()
    {
        Instantiate(FadeIn, new Vector3(0, 0, 0), Quaternion.identity).SetActive(true);
        fadeincount++;
    }
    void startFadeOut()
    {
        Instantiate(FadeOut, new Vector3(0, 0, 0), Quaternion.identity).SetActive(true);
        fadeoutcount++;
    }
}
