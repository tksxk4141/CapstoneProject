using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cshIntroToGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        // ������ �ε���, ����ǥ�� �� �̸� ������ �ȴٰ� �Ѵ�.
        // NextSceneLoader���� �� ������Ʈ ����� Ÿ�Ӷ��ο��� ��Ƽ��.
    }
}
