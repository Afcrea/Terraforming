using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//물 생성기
public class WaterMaker : MonoBehaviour, IDemolish
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

    //★ 맵에 물 생성 => ?
    //★ 지형이 낮은 곳에 생성 가능하게 => ? 

    //건물 부수고 다시 재료 반환하는 함수 - IDemolish 인터페이스
    public void Demolish()
    {
        //물 생성기: 돌 20개 철 20개
        itemManager.StoneCount += 20;
        itemManager.IronCount += 20;

        Destroy(this.gameObject);
    }
}