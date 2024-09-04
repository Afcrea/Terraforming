using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//산소생성기
public class OxyMaker : MonoBehaviour, IInteractable, IDemolish, IBuildable
{
    private PlayerState playerState = null;
    private PlanetManager planetManager = null;

    private void Awake()
    {

        //씬에서 PlayerState 찾기
        playerState = FindObjectOfType<PlayerState>();
        if (playerState == null)
        {
            Debug.LogError("PlayerState is not found in the scene.");
        }

        //씬에서 PlanetManager 찾아오기
        planetManager = FindObjectOfType<PlanetManager>();
        if (planetManager == null)
        {
            Debug.LogError("PlanetManager is not found in the scene.");
        }
    }

    private void Start()
    {
        StartCoroutine(MakeOxygen());
    }

    //플레이어와 상호작용으로 플레이어 산소량 풀충전
    public void Interact()
    {
        playerState.PlayerCurrOxygen = playerState.PlayerInitOxygen;
    }

    //건물 부수고 다시 재료 반환하는 함수 - IDemolish 인터페이스
    public void Demolish()
    {
        //산소생성기: 목재 20개 철 20개 돌 20개
        ItemManager.Instance.WoodCount += 20;
        ItemManager.Instance.IronCount += 20;
        ItemManager.Instance.StoneCount += 20;

        Destroy(this.gameObject);
    }

    //산소 정화
    private IEnumerator MakeOxygen()
    {
        while (this.gameObject)
        {
            //산소 생성기 => 15초 마다 산소 + 1
            yield return new WaitForSeconds(15f);
            planetManager.oxygenLevel += 1f;
            //Debug.Log("산소생성기가 만드는 중");
        }
    }

    public bool BuildEnable()
    {
        if (ItemManager.Instance.StoneCount >= 20 && ItemManager.Instance.IronCount >= 20 && ItemManager.Instance.WoodCount >= 20)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}