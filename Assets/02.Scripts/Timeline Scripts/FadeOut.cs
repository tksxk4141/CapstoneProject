using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public float fadeTime = 1.5f; // Fade효과 재생시간
    Image fadeImg;
    float time = 0f;
    private void Awake()
    {
        fadeImg = GetComponent<Image>();
        StartCoroutine(FadeOutPlay());
    }
    void Start()
    {
        Destroy(GameObject.Find("FadeOutCanvas" + "(Clone)"), 1f);
    }


    void Update()
    {

    }

    IEnumerator FadeOutPlay()

    {
        Color fadecolor = fadeImg.color;

        while (fadecolor.a <= 1f)

        {
            time += Time.deltaTime * fadeTime;
            fadecolor.a = time;
            fadeImg.color = fadecolor;

            yield return null;

        }
    }

}
