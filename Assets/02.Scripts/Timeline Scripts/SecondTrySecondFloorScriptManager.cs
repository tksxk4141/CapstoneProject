using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SecondTrySecondFloorScriptManager : MonoBehaviour
{
    public GameObject TextCanvas;
    GameObject linePanel;

    TextMeshProUGUI chrName;
    TextMeshProUGUI line;

    Dictionary<string, string> lineDictionary = new Dictionary<string, string>();


    public PlayableDirector[] playableDirectors = new PlayableDirector[10];



    public bool isAdded = false;

    public int storyFlag;

    public bool isTimeline5 = false;

    public GameObject selectButton1;
    public GameObject selectButton2;

    bool isTimeline1 = false;
    bool isTimeline2 = false;
    bool isTimeline3 = false;
    bool isTimeline4 = false;

    bool isTimeline6 = false;
    bool isTimeline7 = false;

    public bool checkrestaurant = false;

    GameObject BeforeEndMoving;

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
        storyFlag = cshRoomManager.Instance.storyFlag;
        BeforeEndMoving = GameObject.Find("BeforeEndMoving");
    }

    void Update()
    {

        InputLine();

        


    }
    void InputLine()
    {
        
        if (playableDirectors[0].state == PlayState.Playing && !isAdded)
        {

            //Spawn Script
            lineDictionary.Add("�����ǿ� ���޻��ڰ� �����ž�. �����Ƿ� ���� ������. ", "�Ͽ�");
            lineDictionary.Add("�׷�. �������� �����̾���...", "�ؼ�");

            isAdded = true;
            StartCoroutine(PrintLine());

        }
        if (playableDirectors[1].state == PlayState.Playing && !isAdded)
        {

            //FindMedicine Script
            lineDictionary.Add("���� ������ �־�! �� ġ������.", "�Ͽ�");

            isAdded = true;
            isTimeline1 = true;
            checkrestaurant = true;
            StartCoroutine(PrintLine());

        }

        if (playableDirectors[2].state == PlayState.Playing && !isAdded)
        {
            //MoveToRestaurant Script - 01Before Selecting
            lineDictionary.Add("�ٸ� ������� ��� �� �ɱ�?", "�ؼ�");

            isAdded = true;
            isTimeline2 = true;

            StartCoroutine(PrintLine());
        }
        if (playableDirectors[3].state == PlayState.Playing && !isAdded)
        {
            //MoveToRestaurant Script - 01After Selecting Show
            lineDictionary.Add("�Ʊ� �����ǿ��� �̷� �� ã�Ҿ�. �ƹ����� �̹� ���� �쿬�� �ƴ� �� ����. ���� ������ �� �𸣴� ����ؾ߰ھ�. ", "�Ͽ�");
            lineDictionary.Add("�׷��ٸ� ������ ������ ��Ȳ�̳�. ���ѷ� Ż������. ", "�ؼ�");

            isAdded = true;
            isTimeline3 = true;

            StartCoroutine(PrintLine());
        }
        
        if (playableDirectors[4].state == PlayState.Playing && !isAdded)
        {
            //MoveToRestaurant Script - 01After Selecting Don't Show
            lineDictionary.Add("�׷���. �� ū ������ �߻��ߴµ� ��� ������ �ɱ�? �ٵ� ���� �����Ѱ���?", "�Ͽ�");

            isAdded = true;
            isTimeline4 = true;

            StartCoroutine(PrintLine());
        }
        if (playableDirectors[5].state == PlayState.Playing && !isAdded)
        {
            //MoveToRestaurant Script - 02Headache 
            lineDictionary.Add("�׳����� �� �Ӹ� ���� �� �� ����������?", "�Ͽ�");

            isAdded = true;
            isTimeline5 = true;

            StartCoroutine(PrintLine());
        }
        if (playableDirectors[6].state == PlayState.Playing && !isAdded)
        {
            //MoveToRestaurant Script - 02Selected PainKiller 
            lineDictionary.Add("�����Ӹ��� ��������. ������ ���� ������� ��ã�� ����̾�. ", "�ؼ�");

            isAdded = true;
            //6�̳� 7�� Ÿ�Ӷ��� ���� �� �Ĵ� ���� ����
            isTimeline6 = true;

            StartCoroutine(PrintLine());
        }
        if (playableDirectors[7].state == PlayState.Playing && !isAdded)
        {
            //MoveToRestaurant Script - 02Selected Cream
            lineDictionary.Add("�۽ꡦ�� �𸣰ھ�. �ð��� �� ������ ������������. ", "�ؼ�");

            isAdded = true;
            //6�̳� 7�� Ÿ�Ӷ��� ���� �� �Ĵ� ���� ����
            isTimeline7 = true;

            StartCoroutine(PrintLine());
        }

        if (playableDirectors[8].state == PlayState.Playing && !isAdded)
        {
            //DiscoverFire Script (Same As 1st)
            lineDictionary.Add("�̷�, ������ �Ը��� ȭ�簡 �߻��ߴµ� ȭ�� ��ȭ �ý��۵� �������� �ʴ� �� ����. �������� ������ ����� �ǳ���. �� ������ Ż���ϴ� �� ���ھ�. ", "�Ͽ�");
            lineDictionary.Add("�׷�, �׷� ��� ���ּ��� �ִ� 3������ ����. �켱 ���� ����ؼ� �������� ���� �ϴµ�...", "�ؼ�");

            isAdded = true;
            StartCoroutine(PrintLine());
        }
        if (playableDirectors[9].state == PlayState.Playing && !isAdded)
        {
            //ReachedFan Script (Same As 1st)
            lineDictionary.Add("���������͵� �����̰� ��ܵ� �������µ� �̹��� ��� �������� �ö���?", "�ؼ�");
            lineDictionary.Add("�۽ꡦ.��! ���� ȯǳ���� �־�. ȯǳ�� ��δ� ���� �̾��� �����ϱ� 3������ ���ϴ� ���� �����ž�. ", "�Ͽ�");

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

        if (isTimeline1)
        {
            //1�� Ÿ�Ӷ���(���޻��� �߰�) ���� �� ��Ա�/���� ������ ����
            selectButton1.SetActive(true);
            isTimeline1 = false;
        }
        if (isTimeline2)
        {
            //2�� Ÿ�Ӷ���(�ٸ�������� ������?) ���� �� �ܼ� �����ش�/�ƴϴ� ������ ����
            selectButton2.SetActive(true);
            isTimeline2 = false;
        }
        if(isTimeline3 || isTimeline4)
        {
            //3�̳� 4�� Ÿ�Ӷ��� (�ܼ��� �����ش�/�ƴϴ�) ���� �� �ٷ� 5�� Ÿ�Ӷ���(�Ӹ� ������?) ����
            isTimeline3 = false;
            isTimeline4 = false;
            GetComponentInParent<SecondTrySecondFloorTimelineController>().PlayTimeline(playableDirectors[5]);
        }
        if (isTimeline5)
        {
            //5�� Ÿ�Ӷ���(�Ӹ� ������?) ���� �� �ٷ� 6�̳� 7�� Ÿ�Ӷ��� (������/�ƴ�) ����
            GetComponentInParent<SecondTrySecondFloorTimelineController>().PlayAfterTimeline5();
            isTimeline5 = false;
        }

        if(isTimeline6 || isTimeline7)
        {
            //6�̳� 7�� Ÿ�Ӷ���(�Ӹ� ������/�ƴ�) ���� �� �Ĵ� ���� ���� (���� ����)
            BeforeEndMoving.SetActive(false);
            isTimeline6 = false;
            isTimeline7 = false;
        }


        yield break;


    }

    

}
