using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//토양정화기
public class SoilPuri : MonoBehaviour, IDemolish
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

    //★1개당 땅의 오염도를 1씩 낮춰줌 => 맵 환경에서 오염도 가져와서 낮추기

    //건물 부수고 다시 재료 반환하는 함수 - IDemolish 인터페이스
    public void Demolish()
    {
        //토양정화기: 돌 20개 철 20개
        itemManager.StoneCount += 20;
        itemManager.IronCount += 20;

        Destroy(this.gameObject);
    }
}