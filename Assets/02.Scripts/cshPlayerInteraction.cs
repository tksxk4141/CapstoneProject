using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class cshPlayerInteraction : MonoBehaviour
{
    public GameObject player;
    public Camera camera;
    public GameObject[] bodyParts;
    public GameObject[] ItemPrefab;
    public Sprite[] ItemImage;
    public GameObject ItemImagePrefab;
    public GameObject[] ItemWindow;
    public GameObject CheckingCircle;
    Transform ladderPos;
    Transform ladderTopPos;
    Vector3 new_ladder;
    //private string[] Item = new string[4];
    GameObject tempitem;

    GameObject pressF, pressE, checkBar, checkCircle, HpBar, PauseMenu, gameMessage, storyLine;
    PointerEventData pointerEventData;
    List<RaycastResult> results;
    public string selecteditem = "";

    List<string> itemlist;

    GameObject pointerhit;

    Vector3 hang, hang2;
    Transform hangPos;

    private bool isChecking = false;
    private int itemnum = 0;
    public float hp = 100;
    private float high = 0;
    // Start is called before the first frame update
    void Start()
    {
        pointerEventData = new PointerEventData(EventSystem.current);
        pressF = GameObject.Find("Interaction").transform.Find("PressF").gameObject;
        pressE = GameObject.Find("Interaction").transform.Find("PressE").gameObject;
        checkBar = GameObject.Find("Interaction").transform.Find("Checking").gameObject;
        checkCircle = GameObject.Find("Interaction").transform.Find("Checking Circle Panel").gameObject;
        gameMessage = GameObject.Find("Interaction").transform.Find("GameMessage").gameObject;
        storyLine = GameObject.Find("TextCanvas").transform.Find("Panel").gameObject;
        PauseMenu = GameObject.Find("Canvas").transform.Find("Pause Menu Manager").gameObject;

        HpBar = GameObject.Find("Health");
        HpBar.transform.Find("Slider").GetComponent<Slider>().value = hp;
        HpBar.GetComponentInChildren<TextMeshProUGUI>().text = ((int)hp).ToString() + "%";
        CheckItemlist();
        ShowstroyLine();
    }

    // Update is called once per frame
    void Update()
    {
        SelectItem();
        CheckHp();
        ShowstroyLine();

        PhysicsRaycaster ray = camera.GetComponent<PhysicsRaycaster>();
        results = new List<RaycastResult>();
        pointerEventData.position = Input.mousePosition;
        ray.Raycast(pointerEventData, results);

        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        if (results.Count != 0)
        {
            pointerhit = results[0].gameObject;

            if (PauseMenu.activeSelf)
            {
                if (pointerhit.CompareTag("lever") || pointerhit.CompareTag("button"))
                {
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = false;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }

            if (Vector3.Distance(pointerhit.transform.position, gameObject.transform.position) <= 2f)
            {
                ShowInteractionKey();
                GetItem();
            }
            if (Vector3.Distance(pointerhit.transform.position, gameObject.transform.position) <= 7f&& pointerhit.CompareTag("obstacle"))
            {
                ShowInteractionKey();
                TryMovingObstacle();
            }
            OnPipeline();
            OnLadder();
        }
    }
    void CheckHp()
    {
        HpBar.transform.Find("Slider").GetComponent<Slider>().value = hp;
        HpBar.GetComponentInChildren<TextMeshProUGUI>().text = ((int)hp).ToString() + "%";
    }
    void CheckItemlist()
    {
        if (cshLoginValue.usernum == 0)
        {
            itemlist = csItemManager.instance.item_list1.ToList();
        }
        if (cshLoginValue.usernum == 1)
        {
            itemlist = csItemManager.instance.item_list2.ToList();
        }
        if (itemlist.Count != 0)
        {
            for (int i = 0; i < itemlist.Count; i++)
            {
                for (int j = 0; j < ItemImage.Length; j++)
                {
                    if (ItemImage[j].name.Equals(itemlist[i]))
                    {
                        GameObject tempimg = Instantiate(ItemImagePrefab);
                        tempimg.GetComponent<Image>().sprite = ItemImage[j];
                        tempimg.transform.SetParent(ItemWindow[itemnum].transform);
                        tempimg.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                        tempimg.transform.localScale = Vector3.one;
                        itemnum++;
                        if (itemlist[i].Equals("Crown"))
                        {
                            tempitem.transform.SetParent(bodyParts[0].transform);
                            tempitem.transform.position = bodyParts[0].transform.position;
                            tempitem.transform.Translate(new Vector3(0.0f, 0.2f, 0.0f));
                        }
                        if (itemlist[i].Equals("Repulsor"))
                        {
                            GameObject temp = tempitem.transform.Find("Medieval_Fantasy_Glove_Right").gameObject;
                            temp.transform.SetParent(bodyParts[2].transform);
                            temp.transform.position = bodyParts[2].transform.position;
                            temp.transform.localScale = new Vector3(2.0f, 1.5f, 1.5f);
                            if (this.name.Equals("Playerf(Clone)"))
                            {
                                temp.transform.localRotation = Quaternion.Euler(new Vector3(0f, 90f, 180f));
                                temp.transform.localPosition = new Vector3(0.191f, 0.041f, -0.047f);
                            }
                            else
                            {
                                temp.transform.localRotation = Quaternion.Euler(new Vector3(0f, 90f, 270f));
                                temp.transform.localPosition = new Vector3(0.195f, -0.054f, 0.007f);
                            }
                        }
                        if (itemlist[i].Equals("WingShoes"))
                        {
                            GameObject temp1 = tempitem.transform.Find("WingShoes_Left").gameObject;
                            GameObject temp2 = tempitem.transform.Find("WingShoes_Right").gameObject;
                            temp1.transform.SetParent(bodyParts[3].transform);
                            temp2.transform.SetParent(bodyParts[4].transform);
                            temp1.transform.position = bodyParts[3].transform.position;
                            temp2.transform.position = bodyParts[4].transform.position;
                            if (this.name.Equals("Playerf(Clone)"))
                            {
                                temp1.transform.localPosition = new Vector3(0.1f, -0.095f, 0.015f);
                                temp1.transform.localRotation = Quaternion.Euler(new Vector3(70f, 10f, 97f));
                                temp2.transform.localPosition = new Vector3(-0.1f, 0.146f, -0.017f);
                                temp2.transform.localRotation = Quaternion.Euler(new Vector3(-110f, 12f, -97f));
                            }
                            else
                            {
                                temp1.transform.localPosition = new Vector3(0.1f, -0.13f, -0.01f);
                                temp2.transform.localPosition = new Vector3(-0.1f, 0.17f, 0.01f);
                            }
                        }
                    }
                }
            }
        }
    }
    void SelectItem()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (ItemWindow[0].transform.Find("Border").gameObject.activeSelf)
            {
                DeselectItem(0);
            }
            else
            {
                for (int i = 0; i < ItemWindow.Length; i++)
                {
                    ItemWindow[i].transform.Find("Border").gameObject.SetActive(false);
                }
                SelectedItem(0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (ItemWindow[1].transform.Find("Border").gameObject.activeSelf)
            {
                DeselectItem(1);
            }
            else
            {
                for (int i = 0; i < ItemWindow.Length; i++)
                {
                    ItemWindow[i].transform.Find("Border").gameObject.SetActive(false);
                }
                SelectedItem(1);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (ItemWindow[2].transform.Find("Border").gameObject.activeSelf)
            {
                DeselectItem(2);
            }
            else
            {
                for (int i = 0; i < ItemWindow.Length; i++)
                {
                    ItemWindow[i].transform.Find("Border").gameObject.SetActive(false);
                }
                SelectedItem(2);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (ItemWindow[3].transform.Find("Border").gameObject.activeSelf)
            {
                DeselectItem(3);
            }
            else
            {
                for (int i = 0; i < ItemWindow.Length; i++)
                {
                    ItemWindow[i].transform.Find("Border").gameObject.SetActive(false);
                }
                SelectedItem(3);
            }
        }
    }
    void SelectedItem(int select)
    {
        ItemWindow[select].transform.Find("Border").gameObject.SetActive(true);
        if (ItemWindow[select].transform.Find("ItemImage(Clone)"))
            selecteditem = ItemWindow[select].transform.Find("ItemImage(Clone)").GetComponent<Image>().sprite.name;
    }
    void DeselectItem(int deselect)
    {
        ItemWindow[deselect].transform.Find("Border").gameObject.SetActive(false);
        selecteditem = "";
    }
  
    void ShowstroyLine()
    {
        if (storyLine.activeSelf)
        {
            for(int i = 0; i < ItemWindow.Length; i++)
            {
                ItemWindow[i].SetActive(false);
            }
            HpBar.SetActive(false);
        }
        else
        {
            for (int i = 0; i < ItemWindow.Length; i++)
            {
                ItemWindow[i].SetActive(true);
            }
            HpBar.SetActive(true);
        }
    }

    void ShowInteractionKey()
    {
        if (pointerhit.CompareTag("door")||pointerhit.CompareTag("obstacle")||pointerhit.CompareTag("Pipe") || pointerhit.CompareTag("Ladder"))
            pressF.SetActive(true);
        else
            pressF.SetActive(false);
        if (pointerhit.CompareTag("Item"))
            pressE.SetActive(true);
        else
            pressE.SetActive(false);
    }

    void TryMovingObstacle()
    {
        if (Input.GetKey(KeyCode.F) && !selecteditem.Equals("Crown"))
        {
            StartCoroutine(ShowText(gameMessage, "힘이 부족한것 같다.", 2f));
        }
        if (Input.GetKey(KeyCode.F) && selecteditem.Equals("Crown"))
        {
            StartCoroutine(RotateCheckBar(checkBar.transform.Find("CheckBar").gameObject.transform, 3f));
        }
    }
    void MoveObstacle()
    {
        StartCoroutine(MoveToPosition(pointerhit.transform.parent, pointerhit.transform.parent.position + new Vector3(0, 1, 0), 3f));
    }
    void OnPipeline()
    {
        if (GetComponent<FirstPersonController>().isHanging) //매달린 상태면
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GetComponent<FirstPersonController>().isHanging = false;
            }
        }
        if (Input.GetKey(KeyCode.F)&& pointerhit.CompareTag("Pipe"))
        {
            if(gameObject.transform.position.y < 2.0f)
            {
                StartCoroutine(ShowText(gameMessage, "밟을 곳이 필요하다.", 2f));
            }
            else
            {
                GetComponent<FirstPersonController>().isHanging = true;
                hangPos = GameObject.Find("hangPos").transform;
                hang = pointerhit.transform.position;
                hang2 = new Vector3(hang.x, 2.8f, hang.z);
                gameObject.transform.position = hang2;
                gameObject.transform.rotation = hangPos.rotation;
            }
        }
    }

    void OnLadder()
    {
        if (GetComponent<FirstPersonController>().isLadder) //매달린 상태면
        {
            if (gameObject.transform.position.y > 9)
            {
                ladderTopPos = GameObject.Find("ladderTopPos").transform;
                gameObject.transform.position = ladderTopPos.position;
                GetComponent<FirstPersonController>().isLadder = false;
            }
            else
            {
                if (Input.GetKey(KeyCode.W))
                {
                    high += Time.deltaTime;
                    new_ladder = new Vector3(ladderPos.position.x, high, ladderPos.position.z);
                    gameObject.transform.position = new_ladder;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    high -= Time.deltaTime;
                    new_ladder = new Vector3(ladderPos.position.x, high, ladderPos.position.z);
                    gameObject.transform.position = new_ladder;
                }
            }
        }
        if (Input.GetKey(KeyCode.F) && pointerhit.CompareTag("Ladder"))
        {
            if (gameObject.transform.position.z < 24)
            {
                StartCoroutine(ShowText(gameMessage, "가까이 가야 할 것 같다.", 2f));
            }
            else
            {
                GetComponent<FirstPersonController>().isLadder = true;
                ladderPos = GameObject.Find("ladderPos").transform;
                gameObject.transform.position = ladderPos.position;
                gameObject.transform.rotation = ladderPos.rotation;
            }
        }
    }

    void GetItem()
    {
        if (Input.GetKey(KeyCode.E))
        {
            pressE.SetActive(false);
            if (pointerhit.CompareTag("Item")) {
                if (cshLoginValue.usernum == 0)
                {
                    csItemManager.instance.item_list1.Add(pointerhit.transform.name);
                }
                if (cshLoginValue.usernum == 1)
                {
                    csItemManager.instance.item_list2.Add(pointerhit.transform.name);
                }

                for (int i = 0; i < ItemPrefab.Length; i++)
                {
                    if (pointerhit.name.Equals(ItemPrefab[i].name))
                    {
                        tempitem = Instantiate(ItemPrefab[i], new Vector3(0, 0, 0), Quaternion.identity);
                    }
                }
                if (pointerhit.transform.name.Equals("Crown"))
                {
                    tempitem.transform.SetParent(bodyParts[0].transform);
                    tempitem.transform.position = bodyParts[0].transform.position;
                    tempitem.transform.Translate(new Vector3(0.0f, 0.2f, 0.0f));
                }
                if (pointerhit.transform.name.Equals("Repulsor"))
                {
                    GameObject temp = tempitem.transform.Find("Medieval_Fantasy_Glove_Right").gameObject;
                    temp.transform.SetParent(bodyParts[2].transform);
                    temp.transform.position = bodyParts[2].transform.position;
                    temp.transform.localScale = new Vector3(2.0f, 1.5f, 1.5f);
                    if (this.name.Equals("Playerf(Clone)"))
                    {
                        temp.transform.localRotation = Quaternion.Euler(new Vector3(0f, 90f, 180f));
                        temp.transform.localPosition = new Vector3(0.191f, 0.041f, -0.047f);
                    }
                    else
                    {
                        temp.transform.localRotation = Quaternion.Euler(new Vector3(0f, 90f, 270f));
                        temp.transform.localPosition = new Vector3(0.195f, -0.054f, 0.007f);
                    }
                }
                if (pointerhit.transform.name.Equals("WingShoes"))
                {
                    GameObject temp1 = tempitem.transform.Find("WingShoes_Left").gameObject;
                    GameObject temp2 = tempitem.transform.Find("WingShoes_Right").gameObject;
                    temp1.transform.SetParent(bodyParts[3].transform);
                    temp2.transform.SetParent(bodyParts[4].transform);
                    temp1.transform.position = bodyParts[3].transform.position;
                    temp2.transform.position = bodyParts[4].transform.position;
                    if (this.name.Equals("Playerf(Clone)"))
                    {
                        temp1.transform.localPosition = new Vector3(0.1f, -0.095f, 0.015f);
                        temp1.transform.localRotation = Quaternion.Euler(new Vector3(70f, 10f, 97f));
                        temp2.transform.localPosition = new Vector3(-0.1f, 0.146f, -0.017f);
                        temp2.transform.localRotation = Quaternion.Euler(new Vector3(-110f, 12f, -97f));
                    }
                    else
                    {
                        temp1.transform.localPosition = new Vector3(0.1f, -0.13f, -0.01f);
                        temp2.transform.localPosition = new Vector3(-0.1f, 0.17f, 0.01f);
                    }
                }
                if (pointerhit.transform.name.Equals("PortalGun"))
                {
                    tempitem.transform.SetParent(bodyParts[1].transform);
                    tempitem.transform.position = bodyParts[1].transform.position;

                    if (this.name.Equals("Playerf(Clone)"))
                    {
                        tempitem.transform.localPosition = new Vector3(-0.08f, 0.019f, 0.056f);
                        tempitem.transform.localRotation = Quaternion.Euler(new Vector3(165f, 90f, 0f));
                    }
                    else
                    {
                        tempitem.transform.localPosition = new Vector3(-0.405f, 0.077f, -0.089f);
                        tempitem.transform.localRotation = Quaternion.Euler(new Vector3(165f, 90f, 0f));
                    }

                }
                for (int i = 0; i < ItemImage.Length; i++)
                {
                    if (ItemImage[i].name.Equals(pointerhit.transform.name))
                    {
                        GameObject temp = Instantiate(ItemImagePrefab);
                        temp.GetComponent<Image>().sprite = ItemImage[i];
                        temp.transform.SetParent(ItemWindow[itemnum].transform);
                        temp.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                        temp.transform.localScale = Vector3.one;
                        itemnum++;
                    }
                }
                Destroy(pointerhit);
            }
        }
    }

    public IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove)
    {
        var currentPos = transform.position;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, position, t);
            yield return null;
        }
    }
    public IEnumerator RotateCheckBar(Transform transform, float timeToRotate)
    {
        var t = 0f;
        checkBar.SetActive(true);

        while (t < 1)
        {
            t += Time.deltaTime / timeToRotate;
            transform.Rotate(Vector3.Lerp(new Vector3(0, 0,0), new Vector3(0, 0, 360), 2*Time.deltaTime/timeToRotate));
            if (0.375f < t && t < 0.5f || 0.875f < t && t < 1f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    checkBar.SetActive(false);
                    MoveObstacle();
                    yield return null;
                }
            }
            yield return null;
        }
        checkBar.SetActive(false);
    }

    public IEnumerator CheckCircle(Transform transform, float timeToCheck)
    {
        var t = 0f;
        var ranx = Random.Range(-450, 450);
        var rany = Random.Range(-250, 250);

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        checkCircle.SetActive(true);
        
        GameObject temp = Instantiate(CheckingCircle, transform.position + new Vector3(ranx, rany, 0), Quaternion.identity);
        temp.transform.SetParent(transform);

        while (t < 1)
        {
            t += Time.deltaTime / timeToCheck;

            Vector2 size = temp.transform.Find("CheckCircle").GetComponent<RectTransform>().sizeDelta;
            Debug.Log(size);
            size -= new Vector2(100/t, 100/t);
            temp.transform.Find("CheckCircle").GetComponent<RectTransform>().sizeDelta = size;

            if (0.375f < t && t < 0.5f || 0.875f < t && t < 1f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    checkCircle.SetActive(false);
                    yield return null;
                }
            }
            yield return null;
        }
        checkCircle.SetActive(false);
        isChecking = false;
        Destroy(temp);
    }
    public IEnumerator ShowText(GameObject ob, string message, float timeToShow)
    {
        var t = 0f;
        while (t < 1)
        {
            ob.SetActive(true);
            t += Time.deltaTime / timeToShow;
            ob.GetComponentInChildren<TextMeshProUGUI>().text = message;
            yield return null;
        }
        ob.SetActive(false);
    }
}