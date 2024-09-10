using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//물 생성기
public class WaterMaker : MonoBehaviour, IBuild
{
    private void Awake()
    {
    }

    //★ 맵에 물 생성 => ?
    //★ 지형이 낮은 곳에 생성 가능하게 => ? 

    //건물 부수고 다시 재료 반환하는 함수 - IDemolish 인터페이스
    public void Demolish()
    {
        //물 생성기: 돌 20개 철 20개
        ItemManager.Instance.StoneCount += 20;
        ItemManager.Instance.IronCount += 20;

        Destroy(this.gameObject);
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