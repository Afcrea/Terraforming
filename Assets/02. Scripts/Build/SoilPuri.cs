using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//토양정화기
public class SoilPuri : MonoBehaviour, IBuild
{
    private PlanetManager planetManager = null;

    private void Awake()
    {
        //씬에서 PlanetManager 찾아오기
        planetManager = FindObjectOfType<PlanetManager>();
        if (planetManager == null)
        {
            Debug.LogError("PlanetManager is not found in the scene.");
        }
    }

    private void Start()
    {
        //건물 생길 때마다 레벨 올리기
        planetManager.LandLevel++;
    }

    //건물 부수고 다시 재료 반환하는 함수 - IDemolish 인터페이스
    public void Demolish()
    {
        //토양정화기: 돌 20개 철 20개
        ItemManager.Instance.StoneCount += 20;
        ItemManager.Instance.IronCount += 20;

        //건물 부수기
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        //레벨 낮추기
        planetManager.LandLevel--;
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