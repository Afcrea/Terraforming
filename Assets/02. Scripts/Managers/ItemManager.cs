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
            // 인스턴스가 아직 생성되지 않았다면
            if (_instance == null)
            {
                // 스레드 안전성을 위해 lock 사용
                lock (_lock)
                {
                    // 다시 한 번 확인하여 여러 스레드에서 동시에 인스턴스를 생성하지 않도록 함
                    if (_instance == null)
                    {
                        _instance = new ItemManager();
                    }
                }
            }
            return _instance;
        }
    }

    //아이템 개수 관리 위한 변수
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

    //심기 위한 프리팹 저장 변수
    public GameObject[] treePrefabs = null;
    public GameObject flowerPrefab = null;
    public GameObject axePrefab = null;
    public GameObject pickaxePrefab = null;


    //생성할 위치 파악하기 위한 변수
    Transform playerTr = null;

    public PlayerState playerState = null;

    UIManager uiManager = null;


    // 먹은 아이템 관리하기 위한 리스트
    public List<GameObject> itemList = null;
    public List<GameObject> iItemList = null;
    int iItemCount = 10;

    private void Awake()
    {
        //씬에서 PlayerState 찾기
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
            // 인스턴스를 설정하고 이 객체를 파괴되지 않게 설정
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

        //플레이어 위치 받아옴
        playerTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();
        //혹은 플레이어가 Ray Sphere 뿌려서 바닥과 맞닿은 지점 하나 추출해서 그 위치값 받아서 생성 => 비탈길에 심기 가능

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
