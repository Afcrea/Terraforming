using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //건물 생성 위한 Prefab 저장 변수
    GameObject oxyMaker = null;         //산소 생성기
    GameObject soilPuri = null;         //토질 정화 장치
    GameObject waterMaker = null;       //물 생성기
    GameObject waterSupplier = null;    //급수기

    private ItemManager itemManager = null;

    Vector3 pos = Vector3.zero;

    private void Awake()
    {
        //씬에서 ItemManager 찾아오기
        itemManager = FindObjectOfType<ItemManager>();
        if (itemManager == null)
        {
            Debug.LogError("ItemManager is not found in the scene.");
        }

        //생성할 건물 오브젝트 프리팹
        oxyMaker = Resources.Load<GameObject>("Prefabs/OxyMaker");
        soilPuri = Resources.Load<GameObject>("Prefabs/SoilPuri");
        waterMaker = Resources.Load<GameObject>("Prefabs/WaterMaker");
        waterSupplier = Resources.Load<GameObject>("Prefabs/WaterSupplier");

        //포지션 위치 설정
        //pos = 마우스 위치? 플레이어가 선택한 위치?
    }

    public void BuildOxyMaker()
    {
        //산소생성기: 목재 20개 철 20개 돌 20개
        if (itemManager.WoodCount >= 20 && itemManager.IronCount >= 20 && itemManager.StoneCount >= 20)
        {
            itemManager.WoodCount -= 20;
            itemManager.IronCount -= 20;
            itemManager.StoneCount -= 20;

            GameObject go = Instantiate(oxyMaker, pos, Quaternion.identity, this.transform);
        }
        else
        {
            Debug.Log("설치에 필요한 재료가 부족합니다.");
        }
    }

    public void BuildSoilPuri()
    {
        //토양정화기: 돌 20개 철 20개
        if (itemManager.StoneCount >= 20 && itemManager.IronCount >= 20)
        {
            itemManager.StoneCount -= 20;
            itemManager.IronCount -= 20;

            GameObject go = Instantiate(soilPuri, pos, Quaternion.identity, this.transform);
        }
        else
        {
            Debug.Log("설치에 필요한 재료가 부족합니다.");
        }
    }

    public void BuildWaterMaker()
    {
        //물 생성기: 돌 20개 철 20개
        if (itemManager.StoneCount >= 20 && itemManager.IronCount >= 20)
        {
            itemManager.StoneCount -= 20;
            itemManager.IronCount -= 20;

            GameObject go = Instantiate(waterMaker, pos, Quaternion.identity, this.transform);
        }
        else
        {
            Debug.Log("설치에 필요한 재료가 부족합니다.");
        }
    }

    public void BuildWaterSupplier()
    {
        //급수기: 돌 20개 철 10개
        if (itemManager.StoneCount >= 20 && itemManager.IronCount >= 10)
        {
            itemManager.StoneCount -= 20;
            itemManager.IronCount -= 10;

            GameObject go = Instantiate(waterSupplier, pos, Quaternion.identity, this.transform);
        }
        else
        {
            Debug.Log("설치에 필요한 재료가 부족합니다.");
        }
    }
}