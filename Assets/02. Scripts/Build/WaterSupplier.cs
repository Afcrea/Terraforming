using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//급수기
public class WaterSupplier : MonoBehaviour, IInteractable, IBuild
{
    private PlayerState playerState = null;

    private void Awake()
    {
        //씬에서 PlayerState 찾기
        playerState = FindObjectOfType<PlayerState>();
        if (playerState == null)
        {
            Debug.LogError("PlayerState is not found in the scene.");
        }
    }

    //상호작용시 플레이어 체내 수분량 최대치로
    public void Interact()
    {
        playerState.PlayerCurrWater = playerState.PlayerInitWater;
    }

    //건물 부수고 다시 재료 반환하는 함수 - IDemolish 인터페이스
    //급수기: 돌 20개 철 10개
    public void Demolish()
    {
        ItemManager.Instance.StoneCount += 20;
        ItemManager.Instance.IronCount += 10;

        Destroy(this.gameObject);
    }

    public bool BuildEnable()
    {
        if (ItemManager.Instance.StoneCount >= 20 && ItemManager.Instance.IronCount >= 10)
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
        ItemManager.Instance.IronCount -= 10;
    }
}