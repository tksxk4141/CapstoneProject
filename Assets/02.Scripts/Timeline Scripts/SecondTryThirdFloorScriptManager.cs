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
            lineDictionary.Add("이 문만 열면 탈출선이 있을거야!", "준수");
            lineDictionary.Add("근데 문 개폐시스템이 고장인 것 같아. 아무래도 제어실 컴퓨터를 직접 수리하는 수 밖엔 없겠는걸. ", "하영");


            isAdded = true;
            StartCoroutine(PrintLine());

        }

        if (playableDirector2.state == PlayState.Playing && !isAdded)
        {

            //Before Selecting_Explaining Script
            //컷씬 동영상 있음, 원래 플레이어 잠시 끄기
            playerf.SetActive(false);
            playerm.SetActive(false);

            EndingScriptManager.GetComponent<EndingScriptManager>().InputLine();

            isAdded = true;
            
            //EndingScriptManager에서 선택지(남주엔딩/여주엔딩) 띄움
            //선택지에 따라 3번 또는 4번타임라인 실행
        }

        if (playableDirector3.state == PlayState.Playing && !isAdded)
        {
            //BadEnding_SelectGirl Script
            lineDictionary.Add("…그게 말이 돼? 이 상황에서 갑자기 네가 범인이라고 고백한다고? ", "준수");
            lineDictionary.Add("그래. 내가 범인이야. 이대로 너를 탈출하게 둘 순 없지... 미안하게 됐어. ", "하영");

            isAdded = true;
            StartCoroutine(PrintLine());


        }



        if (playableDirector4.state == PlayState.Playing && !isAdded)
        {
            //Ending_SelectMan Script
            lineDictionary.Add("뭐? 그게 대체 무슨 소리야. 뭔가 오해한 거 아니야? ", "준수");
            lineDictionary.Add("어제 지하 창고에서 나랑 마주친 적 있었지. 그때 넌 액체산소 통을 옮기는 중이라고 했었는데… 오늘 지진이 나고 나서 생각해보니 자주 쓰이는 산소통을 창고에 둔다는 게 이상해서 아까 너 몰래 네 자리를 조사해봤어. ", "하영");
            lineDictionary.Add("급하게 옮겨 담은 건지, 네 책상에 검출 시약을 뿌려봤더니 폭발물 재료로 쓰이는 액체 자국 범벅이더라. ", "하영");
            lineDictionary.Add("왜 그랬어? ", "하영");
            lineDictionary.Add("...", "준수");

            isAdded = true;
            isTimeline4 = true;

            StartCoroutine(PrintLine());
        }
        if (playableDirector5.state == PlayState.Playing && !isAdded)
        {
            //Ending_SelectMan_0 Script
            lineDictionary.Add("아…그래. 내가 범인인 것 같아…", "준수");
            lineDictionary.Add("왜 이런 짓을 벌인거야? 도대체 이유가 뭐야. 아무리 생각해도 모르겠어. ", "하영");
            lineDictionary.Add("미안. 나도 모르겠어. 머릿속에 안개가 낀 것 같아…", "준수");
            lineDictionary.Add("…널 죽인 것도 나인 것 같아. ", "준수");
            lineDictionary.Add("뭐? 무슨 소리야? 날 죽이다니. ", "하영");
            lineDictionary.Add("널 또 죽일 순 없어. 탈출선을 타고 먼저 떠나줘. 제발", "준수");
            lineDictionary.Add("…알겠어. 이유 같은 건 나중에 심문실에서 들으면 되겠지. ", "하영");

            isAdded = true;

            isTimeline5 = true;

            StartCoroutine(PrintLine());
        }
        if (playableDirector6.state == PlayState.Playing && !isAdded)
        {
            //Ending_SelectMan_1 Script
            lineDictionary.Add("우리 연구는 실패했어. ", "준수");
            lineDictionary.Add("뭐?", "하영");
            lineDictionary.Add("처음부터 우리에게 희망 같은 건 없었던 거야. ", "준수");
            lineDictionary.Add("인간은 지구를 떠나 살 수 없어. 지구를 버리고 제 2의 지구를 찾겠다는 발상 자체가 잘못된 거라고. 이 우주에 지구 이외에 인간의 집은 없는거야. ", "준수");
            lineDictionary.Add("소장님은 이 기지에서의 연구가 실패한 걸 알고 다른 행성으로 탐사를 떠날 준비를 하고 계시더라. 하지만 아니. 제일 지구와 환경이 근접했던 이 행성조차 실패했는데, 이제 더 이상 희망은 없어. ", "준수");
            lineDictionary.Add("너…지금 제정신 아닌 것 같아. 우리 연구가 몇 번의 실패를 거듭하다 이 행성까지 온 건 맞지만, 그렇다고 기지 전체를 폭발시켜? 아무 죄 없는 연구원들은? 다들 어떻게 된건데?", "하영");
            lineDictionary.Add("너를 비롯해서 연구원들에겐 미안하게 생각하고 있어. 하지만 이 기지가 있고 연구원들이 있는 이상 이 무의미한 연구는 계속될 거야. 그렇다면…모두 죽일 수 밖에. ", "준수");
            lineDictionary.Add("미쳤어… 너 진짜 미친거야. ", "하영");
            lineDictionary.Add("다른 연구원들은 모두 죽었고… 남은 너 하나만으론 연구 진행은 불가능 할 것 같아 살려줄까 생각했는데. 비밀을 알아버린 이상 어쩔 수 없지. ", "준수");
            lineDictionary.Add("미안. ", "준수");

            isAdded = true;

            isTimeline6 = true;

            StartCoroutine(PrintLine());
        }
        if (playableDirector7.state == PlayState.Playing && !isAdded)
        {
            //BanEnding_Fire Script
            lineDictionary.Add("!! 이게 무슨 소리야?", "하영");
            lineDictionary.Add("이런…아래층에서의 불이 여기까지 옮겨붙었나 보네. ", "준수");
            lineDictionary.Add("우리는 모두 여기서 죽을 운명이었던 거야. ", "준수");
            lineDictionary.Add("말도 안되는 소리 그만하고 이 문이나 열어!", "하영");
            lineDictionary.Add("아니, 우린 여기서 끝내야 해. ", "준수");

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
            //4번 타임라인(남주선택 엔딩초반) 실행 후 storyFlag에 따라 5또는 6번타임라인 실행
            GetComponentInParent<SecondTryThirdFloorTimelineController>().PlayAfterTimeline4();
            isTimeline4 = false;
        }

        if( (isTimeline5 || isTimeline6) && isFireExists)
        {
            //5번이나 6번 타임라인(남주엔딩) 실행 후 2층에 불 진화 안하고 파이프타고 올라왔을 시 배드엔딩 플레이
            GetComponentInParent<SecondTryThirdFloorTimelineController>().PlayAfterTimeline6();
            isTimeline5 = false;
            isTimeline6 = false;
        }


        //컷씬 동영상 끝나면 원래 플레이어 다시 켜기
        playerf.SetActive(true);
        playerm.SetActive(true);

        yield break;


    }
}
