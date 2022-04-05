using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class cshLogin : MonoBehaviour
{
    public InputField ID_Input;
    public InputField PW_Input;
    public InputField RegisterID_Input;
    public InputField RegisterPW_Input;
    public InputField Email_Input;
    public Text LoginErrorText;
    public Text RegisterErrorText;
    public GameObject LoginPanel;
    public GameObject RegisterPanel;

    private string username;
    private string password;
    private string email;

    // Use this for initialization
    void Start()
    {
        PlayFabSettings.TitleId = "CEAC0";
    }

    public void ID_value_Changed()
    {
        if(LoginPanel.activeSelf == true) username = ID_Input.text.ToString();
        if (RegisterPanel.activeSelf == true) username = RegisterID_Input.text.ToString();
    }

    public void PW_value_Changed()
    {
        if (LoginPanel.activeSelf == true) password = PW_Input.text.ToString();
        if (RegisterPanel.activeSelf == true) password = RegisterPW_Input.text.ToString();
    }

    public void Email_value_Changed()
    {
        email = Email_Input.text.ToString();
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
        var request = new RegisterPlayFabUserRequest { Username = username, Password = password, Email = email, DisplayName = username };
        PlayFabClientAPI.RegisterPlayFabUser(request, RegisterSuccess, RegisterFailure);
    }

    public void OnClickRegisterButton()
    {
        if (LoginPanel != null) LoginPanel.SetActive(false);
        if (RegisterPanel != null) RegisterPanel.SetActive(true);
    }

    public void OnClickResetButton()
    {
        if (LoginPanel != null) LoginPanel.SetActive(false);
        if (RegisterPanel != null) RegisterPanel.SetActive(true);
    }

    public void OnClickBackButton()
    {
        if (LoginPanel != null) LoginPanel.SetActive(true);
        if (RegisterPanel != null) RegisterPanel.SetActive(false);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("로그인 성공");
        cshLoginValue.username = result.InfoResultPayload.PlayerProfile.DisplayName;
        SceneManager.LoadScene("LobbyScene");
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("로그인 실패");
        Debug.LogWarning(error.GenerateErrorReport());
        LoginErrorText.text = error.GenerateErrorReport();
    }

    private void RegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("가입 성공");
        RegisterErrorText.text = "가입 성공";
        if (LoginPanel != null) LoginPanel.SetActive(true);
        if (RegisterPanel != null) RegisterPanel.SetActive(false);
    }

    private void RegisterFailure(PlayFabError error)
    {
        Debug.LogWarning("가입 실패");
        Debug.LogWarning(error.GenerateErrorReport());
        RegisterErrorText.text = error.GenerateErrorReport();
    }

    void Update()
    {
        Tab();
        Enter();
    }

    private void Tab() {
        if (LoginPanel.activeSelf == true) {
            if (ID_Input.isFocused == true){ if (Input.GetKeyUp(KeyCode.Tab)) PW_Input.Select(); }
            if (PW_Input.isFocused == true) { if (Input.GetKeyUp(KeyCode.Tab)) ID_Input.Select(); }
        }
        if (RegisterPanel.activeSelf == true) {
            if (RegisterID_Input.isFocused == true) { if (Input.GetKeyUp(KeyCode.Tab)) RegisterPW_Input.Select(); }
            if (RegisterPW_Input.isFocused == true) { if (Input.GetKeyUp(KeyCode.Tab)) Email_Input.Select(); }
            if (Email_Input.isFocused == true) { if (Input.GetKeyUp(KeyCode.Tab)) RegisterID_Input.Select(); }
        }
    }
    private void Enter()
    {
        if (LoginPanel.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Return)) Login(); 
        }
        if (RegisterPanel.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Return)) Register();
        }
    }
}
