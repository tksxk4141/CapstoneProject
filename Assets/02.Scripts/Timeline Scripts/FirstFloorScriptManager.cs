using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class FirstFloorScriptManager : MonoBehaviour
{
    public GameObject TextCanvas;
    GameObject linePanel;

    TextMeshProUGUI chrName;
    TextMeshProUGUI line;

    Dictionary<string, string> lineDictionary = new Dictionary<string, string>();

    public PlayableDirector playableDirector1;
    public PlayableDirector playableDirector2;
    public PlayableDirector playableDirector3;

    public bool isAdded = false;

    private void Awake()
    {
        linePanel = TextCanvas.transform.Find("Panel").gameObject;
        linePanel.SetActive(true);
        chrName = GameObject.Find("TextName").GetComponent<TextMeshProUGUI>();
        line = GameObject.Find("TextLine").GetComponent<TextMeshProUGUI>();

        linePanel.SetActive(false);
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

            //Spawn Script
            lineDictionary.Add("�������� ������ ū ����� �� �� ����. �ʿ��� ���ǵ��� ì�� ������ ��������. ", "��");

            isAdded = true;
            StartCoroutine(PrintLine());

        }

        if (playableDirector2.state == PlayState.Playing && !isAdded)
        {
            //FirstMeet Script
            lineDictionary.Add("...", "�ؼ�");
            lineDictionary.Add("�ؼ���, �ؼ��� ������??", "�Ͽ�");
            lineDictionary.Add("����, �Ͽ���", "�ؼ�");
            lineDictionary.Add("�� �Ȼ��� �ʹ� ������. ������� ��� ��ģ �� �ƴϾ�?", "�Ͽ�");
            lineDictionary.Add("�Ӹ��� �ʹ� ����. ��򰡿� �Ӹ��� �ε��� �� ����. ", "�ؼ�");
            lineDictionary.Add("�̷����켱 ���� ã�ƾ߰ڳ�. �������� �ö󰡺���. ", "�Ͽ�");

            isAdded = true;
            StartCoroutine(PrintLine());
        }
        if (playableDirector3.state == PlayState.Playing && !isAdded)
        {
            //ToGoUpfloor Script
            lineDictionary.Add("���������ʹ� ����� ��ܵ� ��������. �������� �ö� ����� ������?", "�ؼ�");
            lineDictionary.Add("�Ʊ� �ôµ� â���� õ���� ������ �־���. �ö� ����� �� õ����� �� ����. ", "�Ͽ�");
            lineDictionary.Add("�������غ���. ���������͸� �۵���ų ����� ������?", "�ؼ�");

            isAdded = true;
            StartCoroutine(PrintLine());
        }
        


    }

    IEnumerator PrintLine()
    {
        linePanel.SetActive(true);

        foreach (var lineDict in lineDictionary)
        {
            chrName.text = lineDict.Value;
            line.text = lineDict.Key;
            yield return new WaitForSecondsRealtime(3.0f);

        }

        linePanel.SetActive(false);
        lineDictionary.Clear();

        yield break;


    }
}
