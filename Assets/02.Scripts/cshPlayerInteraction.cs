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

    //private string[] Item = new string[4];
    GameObject tempitem;

    GameObject pressF, pressE, checkBar, checkCircle, HpBar, PauseMenu, gameMessage;
    PointerEventData pointerEventData;
    List<RaycastResult> results;
    public string selecteditem = "";

    GameObject pointerhit;

    Vector3 hang, hang2;
    Transform hangPos;

    private bool isChecking = false;
    private int itemnum = 0;
    public float hp = 100;
    // Start is called before the first frame update
    void Start()
    {
        pointerEventData = new PointerEventData(EventSystem.current);
        pressF = GameObject.Find("Interaction").transform.Find("PressF").gameObject;
        pressE = GameObject.Find("Interaction").transform.Find("PressE").gameObject;
        checkBar = GameObject.Find("Interaction").transform.Find("Checking").gameObject;
        checkCircle = GameObject.Find("Interaction").transform.Find("Checking Circle Panel").gameObject;
        gameMessage = GameObject.Find("Interaction").transform.Find("GameMessage").gameObject;

        PauseMenu = GameObject.Find("Canvas").transform.Find("Pause Menu Manager").gameObject;

        HpBar = GameObject.Find("Health");
        HpBar.transform.Find("Slider").GetComponent<Slider>().value = hp;
        HpBar.GetComponentInChildren<TextMeshProUGUI>().text = ((int)hp).ToString() + "%";

        hang = gameObject.transform.position;
        if(SceneManager.GetActiveScene().buildIndex == 3|| SceneManager.GetActiveScene().buildIndex == 7)
        {
            hangPos = GameObject.Find("hangPos").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckItemlist();
        SelectItem();
        checkHp();

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
            if (Vector3.Distance(pointerhit.transform.position, gameObject.transform.position) <= 7f)
            {
                ShowInteractionKey();
                TryMovingObstacle();
            }
            OnPipeline();
        }
    }
    void SelectItem()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            for(int i=0;i<ItemWindow.Length; i++)
            {
                ItemWindow[i].transform.Find("Border").gameObject.SetActive(false);
            }
            SelectedItem(0);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            for (int i = 0; i < ItemWindow.Length; i++)
            {
                ItemWindow[i].transform.Find("Border").gameObject.SetActive(false);
            }
            SelectedItem(1);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            for (int i = 0; i < ItemWindow.Length; i++)
            {
                ItemWindow[i].transform.Find("Border").gameObject.SetActive(false);
            }
            SelectedItem(2);
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            for (int i = 0; i < ItemWindow.Length; i++)
            {
                ItemWindow[i].transform.Find("Border").gameObject.SetActive(false);
            }
            SelectedItem(3);
        }
    }
    void checkHp()
    {
        HpBar.transform.Find("Slider").GetComponent<Slider>().value = hp;
        HpBar.GetComponentInChildren<TextMeshProUGUI>().text = ((int)hp).ToString() + "%";
    }
    void SelectedItem(int select)
    {
        ItemWindow[select].transform.Find("Border").gameObject.SetActive(true);
        if (ItemWindow[select].transform.Find("ItemImage(Clone)"))
            selecteditem = ItemWindow[select].transform.Find("ItemImage(Clone)").GetComponent<Image>().sprite.name;
    }
    void CheckItemlist()
    {
        if (cshLoginValue.usernum == 0)
        {
            //itemlist = csItemManager.instance.item_list1.ToList();
        }
        if (cshLoginValue.usernum == 1)
        {
            //itemlist = csItemManager.instance.item_list2.ToList();
        }
    }

    void ShowInteractionKey()
    {
        if (pointerhit.CompareTag("door")||pointerhit.CompareTag("obstacle")||pointerhit.CompareTag("Pipe"))
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
        if (Input.GetKey(KeyCode.F) && pointerhit.tag == "obstacle" && !selecteditem.Equals("Crown"))
        {
            StartCoroutine(ShowText(gameMessage, "힘이 부족한것 같다.", 2f));
        }
        if (Input.GetKey(KeyCode.F) && pointerhit.tag == "obstacle" && selecteditem.Equals("Crown"))
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
        hang = gameObject.transform.position;
        if (GetComponent<FirstPersonController>().isHanging) //매달린 상태면
        {
            hang2 = new Vector3(hang.x, 2.8f, 36.3f);
            gameObject.transform.position = hang2;
            gameObject.transform.rotation = hangPos.rotation;
            if (Input.GetKey(KeyCode.Space))
            {
                GetComponent<FirstPersonController>().isHanging = false;
            }
        }

        if (Input.GetKey(KeyCode.F)&& pointerhit.CompareTag("Pipe"))
        {
            GetComponent<FirstPersonController>().isHanging = true;

            //StartCoroutine(CheckCircle(checkCircle.transform, 3f));
            //isChecking = true;
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
                    if (pointerhit.name == ItemPrefab[i].name)
                    {
                        tempitem = Instantiate(ItemPrefab[i], new Vector3(0, 0, 0), Quaternion.identity);
                    }
                }
                if (pointerhit.transform.name.Equals("Crown"))
                {
                    tempitem.transform.SetParent(bodyParts[0].transform);
                    tempitem.transform.position = bodyParts[0].transform.position;
                    tempitem.transform.Translate(new Vector3(0.0f, 0.2f, 0.0f));
                    tempitem.tag = "crown";
                }
                
                for(int i = 0; i < ItemImage.Length; i++)
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