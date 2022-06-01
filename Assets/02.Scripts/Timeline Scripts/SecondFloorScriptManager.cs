using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class SecondFloorScriptManager : MonoBehaviour
{
    public GameObject TextCanvas;
    GameObject linePanel;

    TextMeshProUGUI chrName;
    TextMeshProUGUI line;

    Dictionary<string, string> lineDictionary = new Dictionary<string, string>();

    public PlayableDirector playableDirector1;
    public PlayableDirector playableDirector2;
    public PlayableDirector playableDirector3;
    public PlayableDirector playableDirector4;
    public PlayableDirector playableDirector5;

    public bool isAdded = false;

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
            //Spawn Script
            lineDictionary.Add("�����ǿ� ���޻��ڰ� �����ž�. �����Ƿ� ���� ������. ", "�Ͽ�");
            lineDictionary.Add("�׷�. �������� �����̾���...", "�ؼ�");

            isAdded = true;
            StartCoroutine(PrintLine());

        }

        if (playableDirector2.state == PlayState.Playing && !isAdded)
        {
            //FindMedicine Script
            lineDictionary.Add("���� ������ �־�! �� ġ������.", "�Ͽ�");
            lineDictionary.Add("������ ���� �Դ� �� ���ھ�. ", "�ؼ�");

            isAdded = true;
            StartCoroutine(PrintLine());

        }

        if (playableDirector3.state == PlayState.Playing && !isAdded)
        {
            //MoveToRestaurant Script
            lineDictionary.Add("�ٸ� ������� ��� �� �ɱ�?", "�ؼ�");
            lineDictionary.Add("�׷���. �� ū ������ �߻��ߴµ� ��� ������ �ɱ�? �ٵ� ���� �����Ѱ���?", "�Ͽ�");
            lineDictionary.Add("�׳����� �� �Ӹ� ���� �� �� ����������?", "�Ͽ�");
            lineDictionary.Add("�����Ӹ��� ��������. ������ ���� ������� ��ã�� ����̾�. ", "�ؼ�");

            isAdded = true;
            StartCoroutine(PrintLine());
        }
        if (playableDirector4.state == PlayState.Playing && !isAdded)
        {
            //DiscoverFire Script
            lineDictionary.Add("�̷�, ������ �Ը��� ȭ�簡 �߻��ߴµ� ȭ�� ��ȭ �ý��۵� �������� �ʴ� �� ����. �������� ������ ����� �ǳ���. �� ������ Ż���ϴ� �� ���ھ�. ", "�Ͽ�");
            lineDictionary.Add("�׷�, �׷� ��� ���ּ��� �ִ� 3������ ����. �켱 ���� ����ؼ� �������� ���� �ϴµ�...", "�ؼ�");

            isAdded = true;
            StartCoroutine(PrintLine());
        }
        if (playableDirector5.state == PlayState.Playing && !isAdded)
        {
            //ReachedFan Script
            lineDictionary.Add("���������͵� �����̰� ��ܵ� �������µ� �̹��� ��� �������� �ö���?", "�ؼ�");
            lineDictionary.Add("�۽ꡦ.��! ���� ȯǳ���� �־�. ȯǳ�� ��δ� ���� �̾��� �����ϱ� 3������ ���ϴ� ���� �����ž�. ", "�Ͽ�");

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
        lineDictionary.Clear();

        yield break;


    }
}
