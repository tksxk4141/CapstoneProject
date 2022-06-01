using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class ThirdFloorTryToOpenDoorScriptManager : MonoBehaviour
{
    public GameObject TextCanvas;
    GameObject linePanel;

    TextMeshProUGUI chrName;
    TextMeshProUGUI line;

    Dictionary<string, string> lineDictionary = new Dictionary<string, string>();

    public bool isAdded = false;

    public PlayableDirector playableDirector1;

    private void Awake()
    {
        linePanel = TextCanvas.transform.Find("Panel").gameObject;
    }

    void Start()
    {
        
        
    }

    void Update()
    {


        InputLine();



    }
    void InputLine()
    {
        if (playableDirector1.state == PlayState.Playing && !isAdded)
        {
            lineDictionary.Add("�� ���� 3���̴�! �� ������ ������ Ż�⼱�� �����ž�!", "�ؼ�");

            isAdded = true;
            StartCoroutine(PrintLine());
        }

    }

    IEnumerator PrintLine()
    {
        linePanel.SetActive(true);
        chrName = GameObject.Find("TextName").GetComponent<TextMeshProUGUI>();
        line = GameObject.Find("TextLine").GetComponent<TextMeshProUGUI>();

        foreach (var lineDict in lineDictionary)
        {
            chrName.text = lineDict.Value;
            line.text = lineDict.Key;
            yield return new WaitForSecondsRealtime(3.0f);

        }

        linePanel.SetActive(false);
    }
}
