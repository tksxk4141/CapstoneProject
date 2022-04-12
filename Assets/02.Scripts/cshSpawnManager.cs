using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshSpawnManager : MonoBehaviour
{
    public static cshSpawnManager Instance;
    //다른곳에서 쓰기 쉽게 정적 클래스 선언
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
