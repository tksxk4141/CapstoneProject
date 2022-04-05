using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class cshRoomList : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    public RoomInfo info;//���� ����Ÿ���� ������ ���. �ۺ����� �����ؼ� �ٸ������� ���� �����ϵ��� ����. 
    public void SetUp(RoomInfo _info)//������ �޾ƿ���
    {
        info = _info;
        text.text = _info.Name;
    }

    public void OnClick()
    {
        cshLauncher.Instance.JoinRoom(info);//��ó��ũ��Ʈ �޼���� JoinRoom����
    }
}
