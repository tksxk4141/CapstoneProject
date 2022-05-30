using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.Shift;
using TMPro;

public class cshPlayerButton : MonoBehaviour
{
    public static string friendname = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickButton()
    {
        friendname = this.GetComponent<cshPlayerList>().text.text;
        GameObject.Find("Modal Windows").GetComponent<BlurManager>().BlurInAnim();
        GameObject.Find("Modal Windows").transform.Find("Add Friend").GetComponent<ModalWindowManager>().ModalWindowIn();
    }
}
