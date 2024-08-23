using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;
using static UnityEditor.Progress;

public class Flower : MonoBehaviour, IInteractable
{
    private ItemManager itemManager;
    public bool isGathering = true;    //채집 가능 여부 판별 변수
    GameObject seedPrefab;              //씨앗 오브젝트
    GameObject fruitPrefab;             //열매 오브젝트

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
        seedPrefab = Resources.Load<GameObject>("Prefabs/Seed");
        fruitPrefab = Resources.Load<GameObject>("Prefabs/Fruit");
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
        //씨앗 아이템 1개 드랍 구현
        Instantiate(seedPrefab, this.transform.position, this.transform.rotation);
        //열매 아이템 3개 드랍 구현
        for (int i = 0; i < 3; i++)
        {
            Vector3 RandomPos = new Vector3(Random.Range(-0.3f, 0.3f), 0, Random.Range(-0.3f, 0.3f));
            Instantiate(fruitPrefab, this.transform.position + RandomPos, this.transform.rotation);
        }

        //이 오브젝트 파괴
        Destroy(this.gameObject);

        yield return null;
    }

    //★ 성장
    //단계에 따라 Mesh 변경? / 스케일 변경
    //성장이 미완료된 상태일 때는 isGathering => false로 변경
}