using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csLight : MonoBehaviour
{
    public Light theLight;
    private float targetIntensity;
    private float currentIntensity;
    // Start is called before the first frame update
    void Start()
    {
        theLight = GetComponent<Light>();
        currentIntensity = theLight.intensity;
        targetIntensity = Random.Range(0.4f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(targetIntensity - currentIntensity) >= 0.01)
        {

            if (targetIntensity - currentIntensity >= 0)
                currentIntensity += Time.deltaTime * 1f;
            else
            {
                currentIntensity -= Time.deltaTime * 1f;
            }

            theLight.intensity = currentIntensity;
            theLight.range = currentIntensity + 1;

        }
        else
        {
            targetIntensity = Random.Range(0.1f, 1f);
        }
    }
}
