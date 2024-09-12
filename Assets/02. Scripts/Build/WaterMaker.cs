using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//물 생성기
public class WaterMaker : MonoBehaviour, IBuild
{
    private void Start()
    {
        ItemManager.Instance.waterMakerCnt++;       //현재 이 맵에 있는 WaterMaker 개수 파악
    }

    //건물 부수고 다시 재료 반환하는 함수 - IDemolish 인터페이스
    public void Demolish()
    {
        //물 생성기: 돌 20개 철 20개
        ItemManager.Instance.StoneCount += 20;
        ItemManager.Instance.IronCount += 20;

        Destroy(this.gameObject);
    }

    private void OnDisable()
    {
        ItemManager.Instance.waterMakerCnt--;
    }

    public bool BuildEnable()
    {
        if (ItemManager.Instance.StoneCount >= 20 && ItemManager.Instance.IronCount >= 20)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void BuildCost()
    {
        ItemManager.Instance.StoneCount -= 20;
        ItemManager.Instance.IronCount -= 20;
    }
}