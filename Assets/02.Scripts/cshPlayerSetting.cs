using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class cshPlayerSetting : MonoBehaviour
{
    public GameObject SettingPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SettingPanel != null) if (Input.GetKeyDown(KeyCode.Escape)) if (SettingPanel.activeSelf == false) SettingPanel.SetActive(true); else SettingPanel.SetActive(false);
    }

    public void QuitGame()
    {
        //PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("LobbyScene");
    }
}
