using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class Tree : MonoBehaviour, IInteractable
{
    private ItemManager itemManager;

    private bool isGathering = true;   //채집 가능 여부 판별 변수

    GameObject seedlingPrefab;  //묘목 오브젝트

    private void Awake()
    {
        //씬에서 ItemManager 찾아오기
        itemManager = FindObjectOfType<ItemManager>();
        if (itemManager == null)
        {
            Debug.LogError("ItemManager is not found in the scene.");
        }
    }

    private void Start()
    {
        seedlingPrefab = Resources.Load<GameObject>("Prefabs/Seedling");
    }

    public void Interact()
    {
        Debug.Log("인터렉트 실행");
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

        //묘목 아이템 드랍 구현
        Instantiate(seedlingPrefab, this.transform.position, this.transform.rotation);

        //이 오브젝트 파괴
        Destroy(this.gameObject);

        yield return null;
    }

    //★ 성장
    //단계에 따라 Mesh 변경? / 스케일 변경
    //성장이 미완료된 상태일 때는 isGathering => false로 변경
}