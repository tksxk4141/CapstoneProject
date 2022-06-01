using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cshCutSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.SetActiveScene(gameObject.scene);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.C))
        {
            OpenCutScene("1sf1f");
        }
        if (Input.GetKey(KeyCode.V))
        {
            CloseCutScene("1sf1f");
        }
    }

    public void OpenCutScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
    }
    public void CloseCutScene(string scene)
    {
        SceneManager.UnloadSceneAsync(scene);
    }
}
