using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
public class Fruit : MonoBehaviour, IItem
{
    private ItemManager itemManager;
    private Transform playerTr;         //플레이어 위치 담아올 변수
    private float distance = 3f;        //자석 효과 시작할 플레이어와 오브젝트 사이 거리
    private float magnetSpeed = 0.2f;   //자석 효과 속도

    public Sprite inventoryImageSource;

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

    private void Update()
    {
        if (Vector3.Distance(this.transform.position, playerTr.position) < distance)
        {
            Vector3 magnetToPlayer = playerTr.position - this.transform.position;
            transform.Translate(magnetToPlayer * magnetSpeed * Time.deltaTime, Space.Self);
        }
    }

    public void GetItem()
    {
        itemManager.FruitCount++;
        //Debug.Log(this.name + " 개수 : " + itemManager.FruitCount);
        itemManager.itemList.Add(this.gameObject);
        Destroy(this.gameObject);
    }

    public void ItemUse()
    {
        itemManager.FruitCount--;

        //★ 플레이어 포만감 +

        itemManager.playerState.PlayerCurrFull += 10;

        itemManager.playerState.PlayerCurrFull = (itemManager.playerState.PlayerCurrFull > itemManager.playerState.PlayerInitFull) ? itemManager.playerState.PlayerInitFull : itemManager.playerState.PlayerCurrFull;
    }

    public Sprite GetSprite()
    {
        return inventoryImageSource;
    }
}