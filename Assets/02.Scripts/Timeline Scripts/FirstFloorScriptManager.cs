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
            lineDictionary.Add("지진으로 기지에 큰 충격이 온 것 같아. 필요한 물건들을 챙겨 밖으로 나가보자. ", "나");

            isAdded = true;
            StartCoroutine(PrintLine());

        }

        if (playableDirector2.state == PlayState.Playing && !isAdded)
        {
            //FirstMeet Script
            lineDictionary.Add("...", "준수");
            lineDictionary.Add("준수야, 준수야 괜찮아??", "하영");
            lineDictionary.Add("…어, 하영아", "준수");
            lineDictionary.Add("너 안색이 너무 안좋아. 충격으로 어디 다친 거 아니야?", "하영");
            lineDictionary.Add("머리가 너무 아파. 어딘가에 머리를 부딪힌 것 같아. ", "준수");
            lineDictionary.Add("이런…우선 약을 찾아야겠네. 위층으로 올라가보자. ", "하영");

            isAdded = true;
            StartCoroutine(PrintLine());
        }
        if (playableDirector3.state == PlayState.Playing && !isAdded)
        {
            //ToGoUpfloor Script
            lineDictionary.Add("엘리베이터는 멈췄고 계단도 무너졌네. 위층으로 올라갈 방법이 없을까?", "준수");
            lineDictionary.Add("아까 봤는데 창고쪽 천장이 무너져 있었어. 올라갈 방법은 그 천장뿐인 것 같아. ", "하영");
            lineDictionary.Add("…위험해보여. 엘리베이터를 작동시킬 방법은 없을까?", "준수");

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
