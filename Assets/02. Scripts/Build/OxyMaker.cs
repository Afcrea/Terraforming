using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//산소생성기
public class OxyMaker : MonoBehaviour, IInteractable, IDemolish
{
    private ItemManager itemManager = null;

    private void Awake()
    {
        //씬에서 ItemManager 찾아오기
        itemManager = FindObjectOfType<ItemManager>();
        if (itemManager == null)
        {
            Debug.LogError("ItemManager is not found in the scene.");
        }
    }

    //★상호작용으로 플레이어 산소량 +
    public void Interact()
    {

    }

    //건물 부수고 다시 재료 반환하는 함수 - IDemolish 인터페이스
    public void Demolish()
    {
        //산소생성기: 목재 20개 철 20개 돌 20개
        itemManager.WoodCount += 20;
        itemManager.IronCount += 20;
        itemManager.StoneCount += 20;

        Destroy(this.gameObject);
    }
}