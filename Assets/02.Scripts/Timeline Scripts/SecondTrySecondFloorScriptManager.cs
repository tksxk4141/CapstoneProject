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
            lineDictionary.Add("연구실에 구급상자가 있을거야. 연구실로 먼저 가보자. ", "하영");
            lineDictionary.Add("그래. 연구실이 왼쪽이었나...", "준수");

            isAdded = true;
            StartCoroutine(PrintLine());

        }
        if (playableDirectors[1].state == PlayState.Playing && !isAdded)
        {

            //FindMedicine Script
            lineDictionary.Add("여기 비상약이 있어! 얼른 치료하자.", "하영");

            isAdded = true;
            isTimeline1 = true;
            checkrestaurant = true;
            StartCoroutine(PrintLine());

        }

        if (playableDirectors[2].state == PlayState.Playing && !isAdded)
        {
            //MoveToRestaurant Script - 01Before Selecting
            lineDictionary.Add("다른 사람들은 어떻게 된 걸까?", "준수");

            isAdded = true;
            isTimeline2 = true;

            StartCoroutine(PrintLine());
        }
        if (playableDirectors[3].state == PlayState.Playing && !isAdded)
        {
            //MoveToRestaurant Script - 01After Selecting Show
            lineDictionary.Add("아까 연구실에서 이런 걸 찾았어. 아무래도 이번 지진 우연이 아닌 것 같아. 누가 범인일 지 모르니 경계해야겠어. ", "하영");
            lineDictionary.Add("그렇다면 더더욱 위험한 상황이네. 서둘러 탈출하자. ", "준수");

            isAdded = true;
            isTimeline3 = true;

            StartCoroutine(PrintLine());
        }
        
        if (playableDirectors[4].state == PlayState.Playing && !isAdded)
        {
            //MoveToRestaurant Script - 01After Selecting Don't Show
            lineDictionary.Add("그러게. 꽤 큰 지진이 발생했는데 모두 무사한 걸까? 다들 어디로 대피한거지?", "하영");

            isAdded = true;
            isTimeline4 = true;

            StartCoroutine(PrintLine());
        }
        if (playableDirectors[5].state == PlayState.Playing && !isAdded)
        {
            //MoveToRestaurant Script - 02Headache 
            lineDictionary.Add("그나저나 너 머리 아픈 건 좀 괜찮아졌어?", "하영");

            isAdded = true;
            isTimeline5 = true;

            StartCoroutine(PrintLine());
        }
        if (playableDirectors[6].state == PlayState.Playing && !isAdded)
        {
            //MoveToRestaurant Script - 02Selected PainKiller 
            lineDictionary.Add("응…머리가 맑아졌어. 이제야 원래 컨디션을 되찾은 기분이야. ", "준수");

            isAdded = true;
            //6이나 7번 타임라인 실행 후 식당 진입 가능
            isTimeline6 = true;

            StartCoroutine(PrintLine());
        }
        if (playableDirectors[7].state == PlayState.Playing && !isAdded)
        {
            //MoveToRestaurant Script - 02Selected Cream
            lineDictionary.Add("글쎄…잘 모르겠어. 시간이 좀 지나면 괜찮아질지도. ", "준수");

            isAdded = true;
            //6이나 7번 타임라인 실행 후 식당 진입 가능
            isTimeline7 = true;

            StartCoroutine(PrintLine());
        }

        if (playableDirectors[8].state == PlayState.Playing && !isAdded)
        {
            //DiscoverFire Script (Same As 1st)
            lineDictionary.Add("이런, 이정도 규모의 화재가 발생했는데 화재 진화 시스템도 동작하지 않는 것 같아. 생각보다 지진의 충격이 컸나봐. 이 기지를 탈출하는 게 좋겠어. ", "하영");
            lineDictionary.Add("그래, 그럼 비상 우주선이 있는 3층으로 가자. 우선 여길 통과해서 저쪽으로 가야 하는데...", "준수");

            isAdded = true;
            StartCoroutine(PrintLine());
        }
        if (playableDirectors[9].state == PlayState.Playing && !isAdded)
        {
            //ReachedFan Script (Same As 1st)
            lineDictionary.Add("엘리베이터도 고장이고 계단도 무너졌는데 이번엔 어떻게 위층으로 올라가지?", "준수");
            lineDictionary.Add("글쎄….아! 여기 환풍구가 있어. 환풍구 통로는 전부 이어져 있으니까 3층으로 통하는 길이 있을거야. ", "하영");

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
            //1번 타임라인(구급상자 발견) 실행 후 약먹기/연고 선택지 등장
            selectButton1.SetActive(true);
            isTimeline1 = false;
        }
        if (isTimeline2)
        {
            //2번 타임라인(다른사람들은 괜찮나?) 실행 후 단서 보여준다/아니다 선택지 등장
            selectButton2.SetActive(true);
            isTimeline2 = false;
        }
        if(isTimeline3 || isTimeline4)
        {
            //3이나 4번 타임라인 (단서를 보여준다/아니다) 실행 후 바로 5번 타임라인(머리 괜찮아?) 실행
            isTimeline3 = false;
            isTimeline4 = false;
            GetComponentInParent<SecondTrySecondFloorTimelineController>().PlayTimeline(playableDirectors[5]);
        }
        if (isTimeline5)
        {
            //5번 타임라인(머리 괜찮아?) 실행 후 바로 6이나 7번 타임라인 (괜찮아/아니) 실행
            GetComponentInParent<SecondTrySecondFloorTimelineController>().PlayAfterTimeline5();
            isTimeline5 = false;
        }

        if(isTimeline6 || isTimeline7)
        {
            //6이나 7번 타임라인(머리 괜찮아/아니) 실행 후 식당 진입 가능 (투명벽 있음)
            BeforeEndMoving.SetActive(false);
            isTimeline6 = false;
            isTimeline7 = false;
        }


        yield break;


    }

    

}
