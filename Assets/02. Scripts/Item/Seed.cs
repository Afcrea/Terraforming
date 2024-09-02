using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Seed : MonoBehaviour, IItem
{
    private Transform playerTr;         //플레이어 위치 담아올 변수
    private float distance = 3f;        //자석 효과 시작할 플레이어와 오브젝트 사이 거리
    private float magnetSpeed = 0.2f;   //자석 효과 속도

    public Sprite inventoryImageSource;

    GameObject prefab;

    public Sprite GetSprite()
    {
        return inventoryImageSource;
    }

    private void Awake()
    {

        playerTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();  //플레이어 태그로 위치 받아오기
    }

    private void Start()
    {
        prefab = Resources.Load<GameObject>("Prefabs/Seed");
    }
    private void Update()
    {
        if (Vector3.Distance(this.transform.position, playerTr.position) < distance)
        {
            Vector3 magnetToPlayer = playerTr.position - this.transform.position;
            transform.Translate(magnetToPlayer * magnetSpeed * Time.deltaTime, Space.Self);
        }
    }


    //취득
    public void GetItem()
    {
        if (ItemManager.Instance.SeedCount == 0)
        {
            ItemManager.Instance.AddItemList(prefab);
        }

        ItemManager.Instance.SeedCount++;
        //Debug.Log(this.name + " 개수 : " + itemManager.SeedCount);

        Destroy(this.gameObject);
    }
    public void UseItem(int i)
    {
        ItemManager.Instance.SeedCount--;

        Transform playerTransform = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();

        //생성할 위치
        Vector3 plantTr = playerTransform.forward * 5f;
        

        //심으면 원래 나무의 0.1크기로 생성하고 채집 가능 여부 false로 변경
        GameObject go = Instantiate(ItemManager.Instance.flowerPrefab, plantTr, Quaternion.identity);
        go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        go.GetComponent<Flower>().isGathering = false;

        if (ItemManager.Instance.SeedCount == 0)
        {
            ItemManager.Instance.RemoveItem(i);
        }
    }
}