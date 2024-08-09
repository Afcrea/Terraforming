using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class Tree : MonoBehaviour, IInteractable
{
    private ItemManager itemManager;

    private bool isGathering = false;   //채집 가능 여부 판별 변수 

    private void Awake()
    {
        //씬에서 ItemManager 찾아오기
        itemManager = FindObjectOfType<ItemManager>();
        if (itemManager == null)
        {
            Debug.LogError("ItemManager is not found in the scene.");
        }
    }

    public void Interact()
    {
        if (isGathering)
        {
            //채집 코루틴 실행
            StartCoroutine(Gathering());
        }
    }

    //채집
    private IEnumerator Gathering()
    {
        //묘목 1개 목재 3개 획득
        itemManager.WoodCount += 3;

        //★ 묘목 아이템 드랍 구현

        //이 오브젝트 파괴
        Destroy(this.gameObject);

        yield return null;
    }

    //★ 성장
    //단계에 따라 Mesh 변경?
    //성장이 완료된 상태이면 isGathering => true로 변경
}