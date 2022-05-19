using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using TMPro;
using Michsky.UI.Shift;

public class cshLogin : MonoBehaviour
{
    public GameObject Screen;
    public GameObject MainPanel;
    public GameObject ID_Input;
    public GameObject PW_Input;
    public GameObject RegisterID_Input;
    public GameObject RegisterPW_Input;
    public GameObject Email_Input;
    public GameObject LoginErrorText;
    public GameObject RegisterErrorText;

    private string username;
    private string password;
    private string email;
    private string rg_username;
    private string rg_password;

    // Use this for initialization
    void Start()
    {
        PlayFabSettings.TitleId = "CEAC0";
    }

    public void ID_value_Changed()
    {
        username = ID_Input.GetComponent<TMP_InputField>().text;
        rg_username = RegisterID_Input.GetComponent<TMP_InputField>().text;
    }

    public void PW_value_Changed()
    {
        password = PW_Input.GetComponent<TMP_InputField>().text;
        rg_password = RegisterPW_Input.GetComponent<TMP_InputField>().text;
    }

    public void Email_value_Changed()
    {
        email = Email_Input.GetComponent<TMP_InputField>().text;
    }

    public void Login()
    {
        var request = new LoginWithPlayFabRequest {
            Username = username,
            Password = password,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams()
            {
                GetPlayerProfile = true,
                ProfileConstraints = new PlayerProfileViewConstraints()
                {
                    ShowDisplayName = true, // 이 옵션으로 DisplayName,
                    //ShowAvatarUrl = true  // 이 옵션으로 AvatarUrl을 가져올 수 있다.
                },
                //- 이 옵션으로 DisplayName, AvatarUrl을 가져올 수 있다.
                //GetPlayerStatistics = true, //- 이 옵션으로 통계값(순위표에 관여하는)을 불러올 수 있다.
                GetUserData = true, //- 이 옵션으로 < 플레이어 데이터(타이틀) >값을 불러올 수 있다.
            }
        };
        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnLoginFailure);
    }

    public void Register()
    {
        var request = new RegisterPlayFabUserRequest { Username = rg_username, Password = rg_password, Email = email, DisplayName = rg_username };
        PlayFabClientAPI.RegisterPlayFabUser(request, RegisterSuccess, RegisterFailure);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("로그인 성공");
        cshLoginValue.username = result.InfoResultPayload.PlayerProfile.DisplayName;

        SceneManager.LoadScene(1);
        /*
        Screen.GetComponent<Animator>().Play("Login to Loading");
        Screen.GetComponent<TimedEvent>().StartIEnumerator();
        MainPanel.GetComponent<cshLauncher>().ConnectToServer();
        */
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("로그인 실패");
        Debug.LogWarning(error.GenerateErrorReport());
        //LoginErrorText.text = error.GenerateErrorReport();
    }

    private void RegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("가입 성공");
        Screen.GetComponent<Animator>().Play("Sign Up to Login");
    }

    private void RegisterFailure(PlayFabError error)
    {
        Debug.LogWarning("가입 실패");
        Debug.LogWarning(error.GenerateErrorReport());
        //RegisterErrorText.text = error.GenerateErrorReport();
    }

    void Update()
    {
        Tab();
        Enter();
    }

    private void Tab() {
            if (ID_Input.GetComponent<TMP_InputField>().isFocused == true){ if (Input.GetKeyUp(KeyCode.Tab)) PW_Input.GetComponent<TMP_InputField>().Select(); }
            if (PW_Input.GetComponent<TMP_InputField>().isFocused == true) { if (Input.GetKeyUp(KeyCode.Tab)) ID_Input.GetComponent<TMP_InputField>().Select(); }
            if (RegisterID_Input.GetComponent<TMP_InputField>().isFocused == true) { if (Input.GetKeyUp(KeyCode.Tab)) RegisterPW_Input.GetComponent<TMP_InputField>().Select(); }
            if (RegisterPW_Input.GetComponent<TMP_InputField>().isFocused == true) { if (Input.GetKeyUp(KeyCode.Tab)) Email_Input.GetComponent<TMP_InputField>().Select(); }
            if (Email_Input.GetComponent<TMP_InputField>().isFocused == true) { if (Input.GetKeyUp(KeyCode.Tab)) RegisterID_Input.GetComponent<TMP_InputField>().Select(); }
    }
    private void Enter()
    {
        if (Input.GetKeyDown(KeyCode.Return)) Login();
        if (Input.GetKeyDown(KeyCode.Return)) Register();
    }
}
