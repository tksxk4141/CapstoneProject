using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshSlider : MonoBehaviour
{
    public Slider slider;
    public Text text;
    private float Value = 0;
    private int p = 0;

    public void slidervalue()
    {
        Value = 100*slider.GetComponent<Slider>().value;
        p = (int)Value;
        text.text = p.ToString() + "%";
    }
    public void slider_minus()
    {
        slider.GetComponent<Slider>().value = Value;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

        // Update is called once per frame
    void Update()
    {
        slidervalue();
     }

}
