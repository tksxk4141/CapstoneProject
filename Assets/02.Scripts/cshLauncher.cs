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
    public static cshLauncher Instance;//Launcher��ũ��Ʈ�� �޼���� ����ϱ� ���� ����

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
        Instance = this;//�޼���� ���
    }
    void Start()
    {
        Debug.Log("Connecting to Master");
        if (PhotonNetwork.IsConnected == false)
            PhotonNetwork.ConnectUsingSettings();//������ ���� ������ ���� ������ ������ ����
    }

    void Update()
    {

    }

    public void ConnectToServer()
    {
        Debug.Log("Connecting to Master");
        PhotonNetwork.ConnectUsingSettings();//������ ���� ������ ���� ������ ������ ����
    }

    public override void OnConnectedToMaster()//�����ͼ����� ����� �۵���
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();//������ ���� ����� �κ�� ����
        PhotonNetwork.AutomaticallySyncScene = true;//�ڵ����� ��� ������� scene�� ���� �����ش�. 
    }

    public override void OnJoinedLobby()//�κ� ����� �۵�
    {
        Debug.Log("Joined Lobby");
        PhotonNetwork.NickName = cshLoginValue.username;
    }
    public void CreateRoom()//�游���
    {
        if (string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;//�� �̸��� ���̸� �� �ȸ������
        }
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(roomNameInputField.text, roomOptions);//���� ��Ʈ��ũ������� roomNameInputField.text�� �̸����� ���� �����.
        Debug.Log("Create Room");
        CreateRoomModal.GetComponent<ModalWindowManager>().ModalWindowOut();
        ModalWindows.GetComponent<BlurManager>().BlurOutAnim();
    }

    public override void OnJoinedRoom()//�濡 ������ �۵�
    {
        MenuManager.GetComponent<MainPanelManager>().OpenPanel("Room");
        GameObject.Find("Button List").SetActive(false);
        Instantiate(RoomManager);
        Player[] players = PhotonNetwork.PlayerList;
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;//�� �� �̸�ǥ��
        if (PhotonNetwork.IsMasterClient)
        {
            cshLoginValue.usernum = 1;
        }
        if (!PhotonNetwork.IsMasterClient)
        {
            cshLoginValue.usernum = 0;
        }
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);//���常 ���ӽ��� ��ư ������ ����
        foreach (Transform child in playerListContent)
        {
            if(child.CompareTag("playerbutton"))
                Destroy(child.gameObject);//�濡 ���� �����ִ� �̸�ǥ�� ����
        }
        for (int i = 0; i < players.Count(); i++)
        {
            Instantiate(playerListItemPrefab, playerListContent).GetComponent<cshPlayerList>().SetUp(players[i]);
            //���� �濡 ���� �濡�ִ� ��� ��� ��ŭ �̸�ǥ �߰� �ϱ�
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)//������ ������ ������ �ٲ������
    {
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);//���常 ���ӽ��� ��ư ������ ����
    }

    public override void OnCreateRoomFailed(short returnCode, string message)//�� ����� ���н� �۵�
    {
        errorText.text = "Room Creation Failed: " + message;
        cshLobbyManager.Instance.OpenMenu("error");//���� �޴� ����
    }

    public void StartGame()
    {
        //PhotonNetwork.CurrentRoom.IsVisible = false; //���� �����ϸ� �Ⱥ���
        //Screen.GetComponent<Animator>().Play("Login to Loading");
        //Screen.GetComponent<TimedEvent>().StartIEnumerator();

        PhotonNetwork.LoadLevel(2);//1�� ������ ���忡�� scene ��ȣ�� 1�����̱� �����̴�. 0�� �ʱ� ��.
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();//�涰���� ���� ��Ʈ��ũ ���
        GameObject.Find("Top Panel").transform.Find("Button List").gameObject.SetActive(true);
        MenuManager.GetComponent<MainPanelManager>().OpenPanel("Home");
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);//���� ��Ʈ��ũ�� JoinRoom��� �ش��̸��� ���� ������ �����Ѵ�.
    }
    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnLeftRoom()//���� ������ ȣ��
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(1);
            return;
        }
    }
    
    public override void OnRoomListUpdate(List<RoomInfo> roomList)//������ �� ����Ʈ ���
    {
        GameObject tempRoom = null;
        foreach (Transform room in roomListContent)//�����ϴ� ��� roomListContent
        {
            Destroy(room.gameObject);//�븮��Ʈ ������Ʈ�� �ɶ����� �������
        }
        for (int i = 0; i < roomList.Count; i++)//�氹����ŭ �ݺ�
        {
            if (roomList[i].RemovedFromList)//����� ���� ��� ���Ѵ�. 
                continue;
            Instantiate(roomListItemPrefab, roomListContent).GetComponent<cshRoomList>().SetUp(roomList[i]);
            //instantiate�� prefab�� roomListContent��ġ�� ������ְ� �� �������� i��° �븮��Ʈ�� �ȴ�. 
        }
    }
    
    public override void OnPlayerEnteredRoom(Player newPlayer)//�ٸ� �÷��̾ �濡 ������ �۵�
    {
        Instantiate(playerListItemPrefab, playerListContent).GetComponent<cshPlayerList>().SetUp(newPlayer);
        //instantiate�� prefab�� playerListContent��ġ�� ������ְ� �� �������� �̸� �޾Ƽ� ǥ��.
    }

}
