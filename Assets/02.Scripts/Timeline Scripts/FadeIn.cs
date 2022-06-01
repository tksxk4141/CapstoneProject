using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float fadeTime = 1.5f; // Fade효과 재생시간
    Image fadeImg;
    float time = 0f;
    Color fadecolor;
    private void Awake()
    {
        fadeImg = GetComponent<Image>();
        StartCoroutine(FadeInPlay());
    }

    void Start()
    {
        Destroy(GameObject.Find("FadeInCanvas" + "(Clone)"), 1f);
    }


    void Update()
    {
        
    }

    IEnumerator FadeInPlay()

    {
        fadecolor = fadeImg.color;

        while (fadecolor.a > 0f)
        {
            time += Time.deltaTime* fadeTime;
            fadecolor.a = 1-time;
            fadeImg.color = fadecolor;

            yield return null;
        }
    }

}
