using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using System.Linq;
using Michsky.UI.Shift;

public class cshLauncher : MonoBehaviourPunCallbacks
{
    public static cshLauncher Instance;//Launcher스크립트를 메서드로 사용하기 위해 선언

    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text errorText;
    [SerializeField] TMP_Text roomNameText;
    [SerializeField] Transform roomListContent;
    [SerializeField] GameObject roomListItemPrefab;
    [SerializeField] Transform playerListContent;
    [SerializeField] GameObject playerListItemPrefab;
    [SerializeField] GameObject startGameButton;
    public GameObject Screen;
    [SerializeField] GameObject RoomManager;
    [SerializeField] GameObject MenuManager;
    [SerializeField] GameObject ModalWindows;
    [SerializeField] GameObject CreateRoomModal;

    void Awake()
    {
        Instance = this;//메서드로 사용
    }
    void Start()
    {
        Debug.Log("Connecting to Master");
        if (PhotonNetwork.IsConnected == false)
            PhotonNetwork.ConnectUsingSettings();//설정한 포톤 서버에 때라 마스터 서버에 연결
    }

    void Update()
    {

    }

    public void ConnectToServer()
    {
        Debug.Log("Connecting to Master");
        PhotonNetwork.ConnectUsingSettings();//설정한 포톤 서버에 때라 마스터 서버에 연결
    }

    public override void OnConnectedToMaster()//마스터서버에 연결시 작동됨
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();//마스터 서버 연결시 로비로 연결
        PhotonNetwork.AutomaticallySyncScene = true;//자동으로 모든 사람들의 scene을 통일 시켜준다. 
    }

    public override void OnJoinedLobby()//로비에 연결시 작동
    {
        Debug.Log("Joined Lobby");
        PhotonNetwork.NickName = cshLoginValue.username;
    }
    public void CreateRoom()//방만들기
    {
        if (string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;//방 이름이 빈값이면 방 안만들어짐
        }
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(roomNameInputField.text, roomOptions);//포톤 네트워크기능으로 roomNameInputField.text의 이름으로 방을 만든다.
        Debug.Log("Create Room");
        CreateRoomModal.GetComponent<ModalWindowManager>().ModalWindowOut();
        ModalWindows.GetComponent<BlurManager>().BlurOutAnim();
    }

    public override void OnJoinedRoom()//방에 들어갔을때 작동
    {
        MenuManager.GetComponent<MainPanelManager>().OpenPanel("Room");
        GameObject.Find("Button List").SetActive(false);
        Instantiate(RoomManager);
        Player[] players = PhotonNetwork.PlayerList;
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;//들어간 방 이름표시
        if (PhotonNetwork.IsMasterClient)
        {
            cshLoginValue.usernum = 1;
        }
        if (!PhotonNetwork.IsMasterClient)
        {
            cshLoginValue.usernum = 0;
        }
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);//방장만 게임시작 버튼 누르기 가능
        foreach (Transform child in playerListContent)
        {
            if(child.CompareTag("playerbutton"))
                Destroy(child.gameObject);//방에 들어가면 전에있던 이름표들 삭제
        }
        for (int i = 0; i < players.Count(); i++)
        {
            Instantiate(playerListItemPrefab, playerListContent).GetComponent<cshPlayerList>().SetUp(players[i]);
            //내가 방에 들어가면 방에있는 사람 목록 만큼 이름표 뜨게 하기
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)//방장이 나가서 방장이 바뀌었을때
    {
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);//방장만 게임시작 버튼 누르기 가능
    }

    public override void OnCreateRoomFailed(short returnCode, string message)//방 만들기 실패시 작동
    {
        errorText.text = "Room Creation Failed: " + message;
        cshLobbyManager.Instance.OpenMenu("error");//에러 메뉴 열기
    }

    public void StartGame()
    {
        //PhotonNetwork.CurrentRoom.IsVisible = false; //게임 시작하면 안보임
        //Screen.GetComponent<Animator>().Play("Login to Loading");
        //Screen.GetComponent<TimedEvent>().StartIEnumerator();

        PhotonNetwork.LoadLevel(2);//1인 이유는 빌드에서 scene 번호가 1번씩이기 때문이다. 0은 초기 씬.
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();//방떠나기 포톤 네트워크 기능
        GameObject.Find("Top Panel").transform.Find("Button List").gameObject.SetActive(true);
        MenuManager.GetComponent<MainPanelManager>().OpenPanel("Home");
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);//포톤 네트워크의 JoinRoom기능 해당이름을 가진 방으로 접속한다.
    }
    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnLeftRoom()//방을 떠나면 호출
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(1);
            return;
        }
    }
    
    public override void OnRoomListUpdate(List<RoomInfo> roomList)//포톤의 룸 리스트 기능
    {
        GameObject tempRoom = null;
        foreach (Transform room in roomListContent)//존재하는 모든 roomListContent
        {
            Destroy(room.gameObject);//룸리스트 업데이트가 될때마다 싹지우기
        }
        for (int i = 0; i < roomList.Count; i++)//방갯수만큼 반복
        {
            if (roomList[i].RemovedFromList)//사라진 방은 취급 안한다. 
                continue;
            Instantiate(roomListItemPrefab, roomListContent).GetComponent<cshRoomList>().SetUp(roomList[i]);
            //instantiate로 prefab을 roomListContent위치에 만들어주고 그 프리펩은 i번째 룸리스트가 된다. 
        }
    }
    
    public override void OnPlayerEnteredRoom(Player newPlayer)//다른 플레이어가 방에 들어오면 작동
    {
        Instantiate(playerListItemPrefab, playerListContent).GetComponent<cshPlayerList>().SetUp(newPlayer);
        //instantiate로 prefab을 playerListContent위치에 만들어주고 그 프리펩을 이름 받아서 표시.
    }

}
