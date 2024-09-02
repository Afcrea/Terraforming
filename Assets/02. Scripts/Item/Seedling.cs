using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;
public class Seedling : MonoBehaviour, IItem
{
    private ItemManager itemManager;
    private Transform playerTr;         //플레이어 위치 담아올 변수
    private float distance = 3f;        //자석 효과 시작할 플레이어와 오브젝트 사이 거리
    private float magnetSpeed = 0.2f;   //자석 효과 속도

    public Sprite inventoryImageSource;

    GameObject prefab;

    //아이템 얻기
    public void GetItem()
    {
        if (itemManager.SeedlingCount == 0)
        {
            itemManager.itemList.Add(prefab);
        }

        itemManager.SeedlingCount++;
        //Debug.Log(this.name + " 개수 : " + itemManager.SeedlingCount);
        
        Destroy(this.gameObject);
    }

    public void ItemUse()
    {
        itemManager.SeedlingCount--;

        //배열 안에 있는 거 하나 랜덤으로 가져와서 생성
        int num = Random.Range(0, itemManager.treePrefabs.Length);
        GameObject treePrefab = itemManager.treePrefabs[num];

        //생성할 위치
        Vector3 plantTr = new Vector3(playerTr.position.x + Random.Range(0.1f, 0.5f),
                                      playerTr.position.y,
                                      playerTr.position.z + Random.Range(0.1f, 0.5f));

        //심으면 원래 나무의 0.1크기로 생성하고 채집 가능 여부 false로 변경
        GameObject go = Instantiate(treePrefab, plantTr, Quaternion.identity);
        go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        go.GetComponent<Tree>().isGathering = false;
    }

    public Sprite GetSprite()
    {
        return inventoryImageSource;
    }

    private void Awake()
    {
        //씬에서 ItemManager 찾아오기
        itemManager = FindObjectOfType<ItemManager>();
        if (itemManager == null)
        {
            Debug.LogError("ItemManager is not found in the scene.");
        }

        playerTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();  //플레이어 태그로 위치 받아오기
    }

    private void Start()
    {
        prefab = Resources.Load<GameObject>("Prefabs/Seedling");
    }
    private void Update()
    {
        if (Vector3.Distance(this.transform.position, playerTr.position) < distance)
        {
            Vector3 magnetToPlayer = playerTr.position - this.transform.position;
            transform.Translate(magnetToPlayer * magnetSpeed * Time.deltaTime, Space.Self);
        }
    }
}