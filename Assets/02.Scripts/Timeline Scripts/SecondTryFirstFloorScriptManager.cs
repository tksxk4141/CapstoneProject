using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class SecondTryFirstFloorScriptManager : MonoBehaviour
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

            //2nd_Spawn Script
            lineDictionary.Add("��..�Ӹ�. �ߵ��� ��. �̹��� �Ͽ��̸� �츱 ������ ��ȸ��. �ϳ��� �Ǽ��� �־ �ȵ�. ", "�ؼ�");
            lineDictionary.Add("�� ���������� �ڿ��� �߻��� �� �ִ� ������ �ƴϾ�. ���Ŀ� ������ �־�. ", "�Ͽ�");

            isAdded = true;
            StartCoroutine(PrintLine(3.0f));

        }

        if (playableDirector2.state == PlayState.Playing && !isAdded)
        {
            //2nd_FirstMeet Script (Same as 1st)
            lineDictionary.Add("...", "�ؼ�");
            lineDictionary.Add("�ؼ���, �ؼ��� ������??", "�Ͽ�");
            lineDictionary.Add("����, �Ͽ���", "�ؼ�");
            lineDictionary.Add("�� �Ȼ��� �ʹ� ������. ������� ��� ��ģ �� �ƴϾ�?", "�Ͽ�");
            lineDictionary.Add("�Ӹ��� �ʹ� ����. ��򰡿� �Ӹ��� �ε��� �� ����. ", "�ؼ�");
            lineDictionary.Add("�̷����켱 ���� ã�ƾ߰ڳ�. �������� �ö󰡺���. ", "�Ͽ�");

            isAdded = true;
            StartCoroutine(PrintLine(3.0f));
        }
        if (playableDirector3.state == PlayState.Playing && !isAdded)
        {
            //2nd_ToGoUpfloor Script (Same as 1st)
            lineDictionary.Add("���������ʹ� ����� ��ܵ� ��������. �������� �ö� ����� ������?", "�ؼ�");
            lineDictionary.Add("���� õ���� ������ �־�. �ö� ����� �� õ����� �� ����. ", "�Ͽ�");
            lineDictionary.Add("�������غ���. ���������͸� �۵���ų ����� ������?", "�ؼ�");

            isAdded = true;
            StartCoroutine(PrintLine(3.0f));
        }



    }

    IEnumerator PrintLine(float waitTime)
    {
        linePanel.SetActive(true);

        foreach (var lineDict in lineDictionary)
        {
            chrName.text = lineDict.Value;
            line.text = lineDict.Key;
            yield return new WaitForSecondsRealtime(waitTime);

        }

        linePanel.SetActive(false);
        lineDictionary.Clear();

        yield break;


    }
}
