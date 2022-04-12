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
    [SerializeField] GameObject RoomManagerPrefab;


    void Awake()
    {
        Instance = this;//�޼���� ���
    }
    void Start()
    {
        Debug.Log("Connecting to Master");
        PhotonNetwork.ConnectUsingSettings();//������ ���� ������ ���� ������ ������ ����
    }

    void Update()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }

    public override void OnConnectedToMaster()//�����ͼ����� ����� �۵���
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();//������ ���� ����� �κ�� ����
        PhotonNetwork.AutomaticallySyncScene = true;//�ڵ����� ��� ������� scene�� ���� �����ش�. 
    }

    public override void OnJoinedLobby()//�κ� ����� �۵�
    {
        cshLobbyManager.Instance.OpenMenu("title");//�κ� ������ Ÿ��Ʋ �޴� Ű��
        Debug.Log("Joined Lobby");
        PhotonNetwork.NickName = cshLoginValue.username;
    }
    public void CreateRoom()//�游���
    {
        if (string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;//�� �̸��� ���̸� �� �ȸ������
        }
        PhotonNetwork.CreateRoom(roomNameInputField.text);//���� ��Ʈ��ũ������� roomNameInputField.text�� �̸����� ���� �����.
        Instantiate(RoomManagerPrefab);
        cshLobbyManager.Instance.OpenMenu("loading");//�ε�â ����
    }

    public override void OnJoinedRoom()//�濡 ������ �۵�
    {
        cshLobbyManager.Instance.OpenMenu("room");//�� �޴� ����
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;//�� �� �̸�ǥ��
        Player[] players = PhotonNetwork.PlayerList;
        foreach (Transform child in playerListContent)
        {
            Destroy(child.gameObject);//�濡 ���� �����ִ� �̸�ǥ�� ����
        }
        for (int i = 0; i < players.Count(); i++)
        {
            Instantiate(playerListItemPrefab, playerListContent).GetComponent<cshPlayerList>().SetUp(players[i]);
            //���� �濡 ���� �濡�ִ� ��� ��� ��ŭ �̸�ǥ �߰� �ϱ�
        }
        if (PhotonNetwork.IsMasterClient)
        {
            cshLoginValue.usernum = 1;
        }
        if (!PhotonNetwork.IsMasterClient)
        {
            cshLoginValue.usernum = 0;
        }
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);//���常 ���ӽ��� ��ư ������ ����
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
        PhotonNetwork.CurrentRoom.IsVisible = false; //���� �����ϸ� �Ⱥ���
        PhotonNetwork.LoadLevel(2);//1�� ������ ���忡�� scene ��ȣ�� 1�����̱� �����̴�. 0�� �ʱ� ��.
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();//�涰���� ���� ��Ʈ��ũ ���
        cshLobbyManager.Instance.OpenMenu("loading");//�ε�â ����
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);//���� ��Ʈ��ũ�� JoinRoom��� �ش��̸��� ���� ������ �����Ѵ�. 
        cshLobbyManager.Instance.OpenMenu("loading");//�ε�â ����
    }

    public override void OnLeftRoom()//���� ������ ȣ��
    {
        cshLobbyManager.Instance.OpenMenu("title");//�涰���� ������ Ÿ��Ʋ �޴� ȣ��
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)//������ �� ����Ʈ ���
    {
        foreach (Transform trans in roomListContent)//�����ϴ� ��� roomListContent
        {
            Destroy(trans.gameObject);//�븮��Ʈ ������Ʈ�� �ɶ����� �������
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
