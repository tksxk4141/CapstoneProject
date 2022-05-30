using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Chat;
using Photon.Realtime;
using Photon.Pun;
using AuthenticationValues = Photon.Chat.AuthenticationValues;
using ExitGames.Client.Photon;
using TMPro;

public class cshChat : MonoBehaviour, IChatClientListener
{

    private ChatClient chatClient;
    private string userName;
    private string currentChannelName;

    public TMP_InputField inputFieldChat;
    public Text currentChannelText;
    public Text outputText;

    // Use this for initialization
    void Start()
    {
        Application.runInBackground = true;

        // ���� �г����� ������ �����ϸ� �����ϱ� �����
        // �׽�Ʈ�� ������ ������ ���Ͽ� ���� �ð��� ���������� �ӽ� ����
        userName = DateTime.Now.ToShortTimeString()+ " " + PhotonNetwork.NickName;
        currentChannelName = "Channel 001";

        chatClient = new ChatClient(this);

        // true �� �ƴ� ��� ������ ��׶���� �� �� ������ ��������
        chatClient.UseBackgroundWorkerForSending = true;
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, "1.0", new AuthenticationValues(userName));
        AddLine(string.Format("����õ�", userName));
    }

    // ���� ä�� ���¸� ������� UI.Text
    public void AddLine(string lineString)
    {
        outputText.text += lineString + "\r\n";
    }

    // ���ø����̼��� ����Ǿ��� �� ȣ��
    public void OnApplicationQuit()
    {
        if (chatClient != null)
        {
            chatClient.Disconnect();
        }
    }

    // DebugLevel �� ���� �� enum Ÿ�Կ� ���� �޼����� ����Ѵ�
    public void DebugReturn(ExitGames.Client.Photon.DebugLevel level, string message)
    {
        if (level == ExitGames.Client.Photon.DebugLevel.ERROR)
        {
            Debug.LogError(message);
        }
        else if (level == ExitGames.Client.Photon.DebugLevel.WARNING)
        {
            Debug.LogWarning(message);
        }
        else
        {
            Debug.Log(message);
        }
    }

    // ������ ������ ������
    public void OnConnected()
    {
        AddLine("������ ����Ǿ����ϴ�.");

        // ������ ä�θ����� ����
        chatClient.Subscribe(new string[] { currentChannelName }, 10);
    }

    // �������� ������ ������
    public void OnDisconnected()
    {
        AddLine("������ ������ ���������ϴ�.");
    }

    // ���� Ŭ���̾�Ʈ�� ���¸� ���
    public void OnChatStateChange(ChatState state)
    {
        Debug.Log("OnChatStateChange = " + state);
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        AddLine(string.Format("ä�� ���� ({0})", string.Join(",", channels)));
    }

    public void OnUnsubscribed(string[] channels)
    {
        AddLine(string.Format("ä�� ���� ({0})", string.Join(",", channels)));
    }

    // Update() �� chatClient.Service() ��
    // �� ȣ�� �� OnGetMessages �� ȣ���Ѵ�.
    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        if (channelName.Equals(currentChannelName))
        {
            // update text
            this.ShowChannel(currentChannelName);
        }
    }
    public void ShowChannel(string channelName)
    {
        if (string.IsNullOrEmpty(channelName))
        {
            return;
        }

        ChatChannel channel = null;
        bool found = this.chatClient.TryGetChannel(channelName, out channel);
        if (!found)
        {
            Debug.Log("ShowChannel failed to find channel: " + channelName);
            return;
        }

        this.currentChannelName = channelName;
        // ä�ο� ���� �� ��� ä�� �޼����� �ҷ��´�.
        // ���� �̸��� ä�� ������ �Ѳ����� �ҷ�������.
        this.currentChannelText.text = channel.ToStringMessages();
        Debug.Log("ShowChannel: " + currentChannelName);
    }


    // ���� �޼����� ���� ��� ����ϴ� �޼ҵ�
    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        Debug.Log("OnPrivateMessage : " + message);
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        Debug.Log("status : " + string.Format("{0} is {1}, Msg : {2} ", user, status, message));
    }

    // ���� ���� ���� Ȩ���������� ����Ǿ� �ִ� �����̴�
    // chatClient.Service() �� Update ���� ȣ���ϴ���
    // �ʿ信 ���� chatClient.Service() �� �ݵ�� ȣ�� �ؾ��Ѵ�
    void Update()
    {
        chatClient.Service();
    }

    public void OnUserSubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }


    // �ν������� InputField ���� �Է¹��� �޼����� ���� �� ����Ѵ�.
    // InputField �� On End Edit �� �� �޼ҵ带 �Ҵ�����.
    public void OnEnterSend()
    {
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            this.SendChatMessage(this.inputFieldChat.text);
            this.inputFieldChat.text = "";
        }
    }

    // �Է��� ä���� ������ �����Ѵ�.
    private void SendChatMessage(string inputLine)
    {
        if (string.IsNullOrEmpty(inputLine))
        {
            return;
        }

        this.chatClient.PublishMessage(currentChannelName, inputLine);
    }
}
