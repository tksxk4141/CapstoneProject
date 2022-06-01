using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class EndingScriptManager : MonoBehaviour
{
    public GameObject TextCanvas;
    GameObject linePanel;

    TextMeshProUGUI chrName;
    TextMeshProUGUI line;

    Dictionary<string, string> lineDictionary = new Dictionary<string, string>();

    public bool isAdded = false;
    public PlayableDirector playableDirector1;
    public GameObject selectButton;


    private void Awake()
    {
        linePanel = TextCanvas.transform.Find("Panel").gameObject;

    }

    void Start()
    {
        
    }

    void Update()
    {

        
    }
    public void InputLine()
    {
        
        lineDictionary.Add("�׷��� ���̾�. ���� �̻����� �ʾ�?", "�Ͽ�");
        lineDictionary.Add("����?", "�ؼ�");
        lineDictionary.Add("�� ����, �и� ������ �Ϻη� ����Ų �ž�. ", "�Ͽ�");
        lineDictionary.Add("�װ� ���� �Ҹ���?", "�ؼ�");
        lineDictionary.Add("�ʵ� ���ݾ�. �� �༺�� ������ �޶� �� ���� �Ը��� ������ �Ͼ �� ���ٴ°�.", "�Ͽ�");
        lineDictionary.Add("�������غ��� �׷� �͵� ����. �׷���? �׷��� ���� �� ������ ����Ų �ǵ�?", "�ؼ�");
        lineDictionary.Add("������ ������ ������ ���ʶ߸����� ���� ���ο� ����� ������ �� �־�� ��. \n������ ���� ������ �� �ϳ���. �ٷ�..", "�Ͽ�");

        StartCoroutine(PrintLine());
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

        selectButton.SetActive(true);
        linePanel.SetActive(false);
        lineDictionary.Clear();

        

        yield break;
    }

}
