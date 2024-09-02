using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemManager : MonoBehaviour
{
    private ItemManager() { }

    private static ItemManager _instance;

    private static readonly object _lock = new object();

    public static ItemManager Instance
    {
        get
        {
            // �ν��Ͻ��� ���� �������� �ʾҴٸ�
            if (_instance == null)
            {
                // ������ �������� ���� lock ���
                lock (_lock)
                {
                    // �ٽ� �� �� Ȯ���Ͽ� ���� �����忡�� ���ÿ� �ν��Ͻ��� �������� �ʵ��� ��
                    if (_instance == null)
                    {
                        _instance = new ItemManager();
                    }
                }
            }
            return _instance;
        }
    }

    //������ ���� ���� ���� ����
    private int ironCount = 0;
    private int stoneCount = 0;
    private int woodCount = 0;
    private int seedlingCount = 0;
    private int seedCount = 0;
    private int fruitCount = 0;

    public int IronCount
    {
        get { return ironCount; }
        set { ironCount = value; }
    }
    public int StoneCount
    {
        get { return stoneCount; }
        set { stoneCount = value; }
    }
    public int WoodCount
    {
        get { return woodCount; }
        set { woodCount = value; }
    }
    public int SeedlingCount
    {
        get { return seedlingCount; }
        set { seedlingCount = value; }
    }
    public int SeedCount
    {
        get { return seedCount; }
        set { seedCount = value; }
    }
    public int FruitCount
    {
        get { return fruitCount; }
        set { fruitCount = value; }
    }

    //�ɱ� ���� ������ ���� ����
    public GameObject[] treePrefabs = null;
    public GameObject flowerPrefab = null;
    public GameObject axePrefab = null;
    public GameObject pickaxePrefab = null;


    //������ ��ġ �ľ��ϱ� ���� ����
    Transform playerTr = null;

    public PlayerState playerState = null;

    UIManager uiManager = null;


    // ���� ������ �����ϱ� ���� ����Ʈ
    public List<GameObject> itemList = null;
    public List<GameObject> iItemList = null;
    int iItemCount = 10;

    private void Awake()
    {
        //������ PlayerState ã��
        playerState = FindObjectOfType<PlayerState>();

        if (playerState == null)
        {
            Debug.LogError("PlayerState is not found in the scene.");
        }

        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            // �ν��Ͻ��� �����ϰ� �� ��ü�� �ı����� �ʰ� ����
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        treePrefabs = Resources.LoadAll<GameObject>("Prefabs/TreePrefabs");
        flowerPrefab = Resources.Load<GameObject>("Prefabs/Flower");
        axePrefab = Resources.Load<GameObject>("Prefabs/Tools/Axe");
        pickaxePrefab = Resources.Load<GameObject>("Prefabs/Tools/PickAxe");

        //�÷��̾� ��ġ �޾ƿ�
        playerTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();
        //Ȥ�� �÷��̾ Ray Sphere �ѷ��� �ٴڰ� �´��� ���� �ϳ� �����ؼ� �� ��ġ�� �޾Ƽ� ���� => ��Ż�濡 �ɱ� ����

        for(int i = 0; i < iItemCount; i++)
        {
            itemList.Add(null);
        }

        AddItemList(axePrefab);
        AddItemList(pickaxePrefab);
    }

    public void AddItemList(GameObject item)
    {
        int idx = 0;
        foreach (GameObject itemnull in itemList)
        {
            if(itemnull == null)
            {
                break;
            }
            idx++;
        }

        itemList[idx] = item;

        uiManager.AddInventoryUI(idx, item);
    }

    public void RemoveItem(int i)
    {
        itemList[i] = null;
        uiManager.RemoveInventoryUI();
    }

}
