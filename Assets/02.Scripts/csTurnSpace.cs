using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csTurnSpace : MonoBehaviour
{
    float degree;
    float bright;
    bool right;
    // Start is called before the first frame update
    void Start()
    {
        degree = 0;
        bright = 1;
        right = false;
    }

    // Update is called once per frame
    void Update()
    {
        degree += Time.deltaTime;
        if (degree >= 360)
            degree = 0;
        RenderSettings.skybox.SetFloat("_Rotation", degree);

        if (!right)
            bright += Time.deltaTime * 0.3f;
        else
            bright -= Time.deltaTime * 0.3f;
        RenderSettings.skybox.SetFloat("_Exposure", bright);

        if (bright >= 2)
        {
            right = true;
        }
        else if (bright <= 1)
            right = false;
    }
}
