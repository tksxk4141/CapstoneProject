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
            lineDictionary.Add("연구실에 구급상자가 있을거야. 연구실로 먼저 가보자. ", "하영");
            lineDictionary.Add("그래. 연구실이 왼쪽이었나...", "준수");

            isAdded = true;
            StartCoroutine(PrintLine());

        }

        if (playableDirector2.state == PlayState.Playing && !isAdded)
        {
            //FindMedicine Script
            lineDictionary.Add("여기 비상약이 있어! 얼른 치료하자.", "하영");
            lineDictionary.Add("연고보단 약을 먹는 게 좋겠어. ", "준수");

            isAdded = true;
            StartCoroutine(PrintLine());

        }

        if (playableDirector3.state == PlayState.Playing && !isAdded)
        {
            //MoveToRestaurant Script
            lineDictionary.Add("다른 사람들은 어떻게 된 걸까?", "준수");
            lineDictionary.Add("그러게. 꽤 큰 지진이 발생했는데 모두 무사한 걸까? 다들 어디로 대피한거지?", "하영");
            lineDictionary.Add("그나저나 너 머리 아픈 건 좀 괜찮아졌어?", "하영");
            lineDictionary.Add("응…머리가 맑아졌어. 이제야 원래 컨디션을 되찾은 기분이야. ", "준수");

            isAdded = true;
            StartCoroutine(PrintLine());
        }
        if (playableDirector4.state == PlayState.Playing && !isAdded)
        {
            //DiscoverFire Script
            lineDictionary.Add("이런, 이정도 규모의 화재가 발생했는데 화재 진화 시스템도 동작하지 않는 것 같아. 생각보다 지진의 충격이 컸나봐. 이 기지를 탈출하는 게 좋겠어. ", "하영");
            lineDictionary.Add("그래, 그럼 비상 우주선이 있는 3층으로 가자. 우선 여길 통과해서 저쪽으로 가야 하는데...", "준수");

            isAdded = true;
            StartCoroutine(PrintLine());
        }
        if (playableDirector5.state == PlayState.Playing && !isAdded)
        {
            //ReachedFan Script
            lineDictionary.Add("엘리베이터도 고장이고 계단도 무너졌는데 이번엔 어떻게 위층으로 올라가지?", "준수");
            lineDictionary.Add("글쎄….아! 여기 환풍구가 있어. 환풍구 통로는 전부 이어져 있으니까 3층으로 통하는 길이 있을거야. ", "하영");

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
