using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csItemManager : MonoBehaviour
{
    public static csItemManager instance = null;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            instance = this; //���ڽ��� instance�� �־��ݴϴ�.
            DontDestroyOnLoad(gameObject); //OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ����
        }
        else
        {
            if (instance != this) //instance�� ���� �ƴ϶�� �̹� instance�� �ϳ� �����ϰ� �ִٴ� �ǹ�
                Destroy(this.gameObject); //�� �̻� �����ϸ� �ȵǴ� ��ü�̴� ��� AWake�� �ڽ��� ����
        }
    }

    //���� ������ ���̵��� �����ϰ� ���� ��(����)
    public int destination=0;
    public List<string> item_list = new List<string>();
    public List<string> item_list1 = new List<string>();
    public List<string> item_list2 = new List<string>();
}
