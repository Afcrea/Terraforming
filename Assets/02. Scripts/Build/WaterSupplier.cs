using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//급수기
public class WaterSupplier : MonoBehaviour, IInteractable, IDemolish
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

    //★상호작용시 플레이어 수분 + 
    public void Interact()
    {

    }

    //건물 부수고 다시 재료 반환하는 함수 - IDemolish 인터페이스
    //급수기: 돌 20개 철 10개
    public void Demolish()
    {
        itemManager.StoneCount += 20;
        itemManager.IronCount += 10;

        Destroy(this.gameObject);
    }
}