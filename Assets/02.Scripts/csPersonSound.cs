using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csPersonSound : MonoBehaviour
{
    public GameObject jumpSound;
    public GameObject runSound;
    public GameObject walkSound;
    public Transform soundPos;
    GameObject instance = null;
    public AudioClip jump;
    public AudioClip run;
    public AudioClip walk;
    bool isRun = false;
    bool isWalk = false;
    void Update()
    {
        
        if (GetComponent<FirstPersonController>().isWalking && !GetComponent<FirstPersonController>().isHanging) 
        {
            if (instance == null)
            {
                if (GetComponent<FirstPersonController>().isSprinting) //Ã³À½ºÎÅÍ ¶Ù´Â °æ¿ì
                {
                    instance = Instantiate(runSound, soundPos, soundPos);
                }
                else
                {
                    instance = Instantiate(walkSound, soundPos, soundPos); //°È´Â °æ¿ì
                }
            }
            else
            {
                if (GetComponent<FirstPersonController>().isSprinting) 
                {
                    if(!isRun)//°È´Ù°¡ ¶Ù´Â °æ¿ì
                    {
                        Destroy(instance);
                        isRun = true;
                        instance = Instantiate(runSound, soundPos, soundPos);
                    }
                    else if(isWalk && isRun) //°È´Ù°¡ ¶Ù´Ù°¡ ´Ù½Ã °È´Â °æ¿ì
                    {
                        isWalk = false;
                        isRun = false;
                        Destroy(instance);
                        instance = Instantiate(runSound, soundPos, soundPos);
                    }
                }
                else { //¶Ù´Ù°¡ °È´Â °æ¿ì
                    if (!isWalk && isRun)
                    {
                        Destroy(instance);
                        isWalk = true;
                        instance = Instantiate(walkSound, soundPos, soundPos);
                    }
                }
            }
        }
        else 
        {
            /*if (GetComponent<FirstPersonController>().isGrounded)
            {
                if (instance == null)
                {
                    instance = Instantiate(jumpSound, soundPos, soundPos);
                }
                else
                {
                    Destroy(instance);
                }
            }*/
            if (instance != null)
            {
                Destroy(instance);
                isRun = false;
                isWalk = false;
            }
        }
    }
}
