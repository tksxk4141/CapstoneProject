using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshSpawnManager : MonoBehaviour
{
    public static cshSpawnManager Instance;
    //�ٸ������� ���� ���� ���� Ŭ���� ����
    [SerializeField] cshSpawnpoint[] spawnpoints;

    void Awake()
    {
        Instance = this;
        //spawnpoints = GetComponentsInChildren<cshSpawnpoint>();
    }

    public Transform GetSpawnpoint(int usernum)
    {
        return spawnpoints[usernum].transform;
    }
}
