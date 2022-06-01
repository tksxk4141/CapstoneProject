using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class SecondTryThirdFloorScriptManager : MonoBehaviour
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
    public PlayableDirector playableDirector6;
    public PlayableDirector playableDirector7;

    public bool isAdded = false;
    public bool isTimeline4 = false;

    public bool isTimeline5 = false;
    public bool isTimeline6 = false;

    public bool isFireExists = false;

    GameObject EndingScriptManager;

    GameObject playerf;
    GameObject playerm;

    private void Awake()
    {
        linePanel = TextCanvas.transform.Find("Panel").gameObject;
    }

    void Start()
    {
        linePanel.SetActive(true);
        chrName = GameObject.Find("TextName").GetComponent<TextMeshProUGUI>();
        line = GameObject.Find("TextLine").GetComponent<TextMeshProUGUI>();
        linePanel.SetActive(false);


        EndingScriptManager = GameObject.Find("EndingScriptManager");

        isFireExists = GameObject.Find("RoomManager").GetComponent<cshRoomManager>().isFireExists;

        playerf = GameObject.Find("Playerf(Clone)");
        playerm = GameObject.Find("Playerm(Clone)");
    }

    void Update()
    {

        InputLine();




    }
    void InputLine()
    {
        if (playableDirector1.state == PlayState.Playing && !isAdded)
        {

            //ReachedLastDoor Script
            lineDictionary.Add("�� ���� ���� Ż�⼱�� �����ž�!", "�ؼ�");
            lineDictionary.Add("�ٵ� �� ����ý����� ������ �� ����. �ƹ����� ����� ��ǻ�͸� ���� �����ϴ� �� �ۿ� ���ڴ°�. ", "�Ͽ�");


            isAdded = true;
            StartCoroutine(PrintLine());

        }

        if (playableDirector2.state == PlayState.Playing && !isAdded)
        {

            //Before Selecting_Explaining Script
            //�ƾ� ������ ����, ���� �÷��̾� ��� ����
            playerf.SetActive(false);
            playerm.SetActive(false);

            EndingScriptManager.GetComponent<EndingScriptManager>().InputLine();

            isAdded = true;
            
            //EndingScriptManager���� ������(���ֿ���/���ֿ���) ���
            //�������� ���� 3�� �Ǵ� 4��Ÿ�Ӷ��� ����
        }

        if (playableDirector3.state == PlayState.Playing && !isAdded)
        {
            //BadEnding_SelectGirl Script
            lineDictionary.Add("���װ� ���� ��? �� ��Ȳ���� ���ڱ� �װ� �����̶�� ����Ѵٰ�? ", "�ؼ�");
            lineDictionary.Add("�׷�. ���� �����̾�. �̴�� �ʸ� Ż���ϰ� �� �� ����... �̾��ϰ� �ƾ�. ", "�Ͽ�");

            isAdded = true;
            StartCoroutine(PrintLine());


        }



        if (playableDirector4.state == PlayState.Playing && !isAdded)
        {
            //Ending_SelectMan Script
            lineDictionary.Add("��? �װ� ��ü ���� �Ҹ���. ���� ������ �� �ƴϾ�? ", "�ؼ�");
            lineDictionary.Add("���� ���� â���� ���� ����ģ �� �־���. �׶� �� ��ü��� ���� �ű�� ���̶�� �߾��µ��� ���� ������ ���� ���� �����غ��� ���� ���̴� ������� â�� �дٴ� �� �̻��ؼ� �Ʊ� �� ���� �� �ڸ��� �����غþ�. ", "�Ͽ�");
            lineDictionary.Add("���ϰ� �Ű� ���� ����, �� å�� ���� �þ��� �ѷ��ô��� ���߹� ���� ���̴� ��ü �ڱ� �����̴���. ", "�Ͽ�");
            lineDictionary.Add("�� �׷���? ", "�Ͽ�");
            lineDictionary.Add("...", "�ؼ�");

            isAdded = true;
            isTimeline4 = true;

            StartCoroutine(PrintLine());
        }
        if (playableDirector5.state == PlayState.Playing && !isAdded)
        {
            //Ending_SelectMan_0 Script
            lineDictionary.Add("�ơ��׷�. ���� ������ �� ���ơ�", "�ؼ�");
            lineDictionary.Add("�� �̷� ���� ���ΰž�? ����ü ������ ����. �ƹ��� �����ص� �𸣰ھ�. ", "�Ͽ�");
            lineDictionary.Add("�̾�. ���� �𸣰ھ�. �Ӹ��ӿ� �Ȱ��� �� �� ���ơ�", "�ؼ�");
            lineDictionary.Add("���� ���� �͵� ���� �� ����. ", "�ؼ�");
            lineDictionary.Add("��? ���� �Ҹ���? �� ���̴ٴ�. ", "�Ͽ�");
            lineDictionary.Add("�� �� ���� �� ����. Ż�⼱�� Ÿ�� ���� ������. ����", "�ؼ�");
            lineDictionary.Add("���˰ھ�. ���� ���� �� ���߿� �ɹ��ǿ��� ������ �ǰ���. ", "�Ͽ�");

            isAdded = true;

            isTimeline5 = true;

            StartCoroutine(PrintLine());
        }
        if (playableDirector6.state == PlayState.Playing && !isAdded)
        {
            //Ending_SelectMan_1 Script
            lineDictionary.Add("�츮 ������ �����߾�. ", "�ؼ�");
            lineDictionary.Add("��?", "�Ͽ�");
            lineDictionary.Add("ó������ �츮���� ��� ���� �� ������ �ž�. ", "�ؼ�");
            lineDictionary.Add("�ΰ��� ������ ���� �� �� ����. ������ ������ �� 2�� ������ ã�ڴٴ� �߻� ��ü�� �߸��� �Ŷ��. �� ���ֿ� ���� �̿ܿ� �ΰ��� ���� ���°ž�. ", "�ؼ�");
            lineDictionary.Add("������� �� ���������� ������ ������ �� �˰� �ٸ� �༺���� Ž�縦 ���� �غ� �ϰ� ��ô���. ������ �ƴ�. ���� ������ ȯ���� �����ߴ� �� �༺���� �����ߴµ�, ���� �� �̻� ����� ����. ", "�ؼ�");
            lineDictionary.Add("�ʡ����� ������ �ƴ� �� ����. �츮 ������ �� ���� ���и� �ŵ��ϴ� �� �༺���� �� �� ������, �׷��ٰ� ���� ��ü�� ���߽���? �ƹ� �� ���� ����������? �ٵ� ��� �Ȱǵ�?", "�Ͽ�");
            lineDictionary.Add("�ʸ� ����ؼ� �������鿡�� �̾��ϰ� �����ϰ� �־�. ������ �� ������ �ְ� ���������� �ִ� �̻� �� ���ǹ��� ������ ��ӵ� �ž�. �׷��ٸ顦��� ���� �� �ۿ�. ", "�ؼ�");
            lineDictionary.Add("���ƾ �� ��¥ ��ģ�ž�. ", "�Ͽ�");
            lineDictionary.Add("�ٸ� ���������� ��� �׾��� ���� �� �ϳ������� ���� ������ �Ұ��� �� �� ���� ����ٱ� �����ߴµ�. ����� �˾ƹ��� �̻� ��¿ �� ����. ", "�ؼ�");
            lineDictionary.Add("�̾�. ", "�ؼ�");

            isAdded = true;

            isTimeline6 = true;

            StartCoroutine(PrintLine());
        }
        if (playableDirector7.state == PlayState.Playing && !isAdded)
        {
            //BanEnding_Fire Script
            lineDictionary.Add("!! �̰� ���� �Ҹ���?", "�Ͽ�");
            lineDictionary.Add("�̷����Ʒ��������� ���� ������� �Űܺپ��� ����. ", "�ؼ�");
            lineDictionary.Add("�츮�� ��� ���⼭ ���� ����̾��� �ž�. ", "�ؼ�");
            lineDictionary.Add("���� �ȵǴ� �Ҹ� �׸��ϰ� �� ���̳� ����!", "�Ͽ�");
            lineDictionary.Add("�ƴ�, �츰 ���⼭ ������ ��. ", "�ؼ�");

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


        if (isTimeline4)
        {
            //4�� Ÿ�Ӷ���(���ּ��� �����ʹ�) ���� �� storyFlag�� ���� 5�Ǵ� 6��Ÿ�Ӷ��� ����
            GetComponentInParent<SecondTryThirdFloorTimelineController>().PlayAfterTimeline4();
            isTimeline4 = false;
        }

        if( (isTimeline5 || isTimeline6) && isFireExists)
        {
            //5���̳� 6�� Ÿ�Ӷ���(���ֿ���) ���� �� 2���� �� ��ȭ ���ϰ� ������Ÿ�� �ö���� �� ��忣�� �÷���
            GetComponentInParent<SecondTryThirdFloorTimelineController>().PlayAfterTimeline6();
            isTimeline5 = false;
            isTimeline6 = false;
        }


        //�ƾ� ������ ������ ���� �÷��̾� �ٽ� �ѱ�
        playerf.SetActive(true);
        playerm.SetActive(true);

        yield break;


    }
}
