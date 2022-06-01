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
        
        lineDictionary.Add("그런데 말이야. 뭔가 이상하지 않아?", "하영");
        lineDictionary.Add("뭐가?", "준수");
        lineDictionary.Add("이 지진, 분명 누군가 일부러 일으킨 거야. ", "하영");
        lineDictionary.Add("그게 무슨 소리야?", "준수");
        lineDictionary.Add("너도 알잖아. 이 행성은 지구와 달라서 이 정도 규모의 지진은 일어날 수 없다는거.", "하영");
        lineDictionary.Add("…생각해보니 그런 것도 같네. 그래서? 그러면 누가 이 지진을 일으킨 건데?", "준수");
        lineDictionary.Add("지진을 가장해 기지를 무너뜨리려면 기지 내부에 깊숙히 잠입할 수 있어야 해. \n범인은 내부 연구원 중 하나야. 바로..", "하영");

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
