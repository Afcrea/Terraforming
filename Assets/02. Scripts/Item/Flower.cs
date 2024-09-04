using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class Flower : MonoBehaviour, IInteractable
{
    private ItemManager itemManager;
    private PlanetManager planetManager;

    public bool isGathering = true;    //채집 가능 여부 판별 변수
    GameObject seedPrefab;              //씨앗 오브젝트
    GameObject fruitPrefab;             //열매 오브젝트

    [SerializeField]
    private float time = 0f;            //생성 후 경과 시간
    private float grownTime = 600f;     //다 성장하는 데에 걸리는 시간 = 하루

    private void Awake()
    {
        //씬에서 ItemManager 찾아오기
        itemManager = FindObjectOfType<ItemManager>();
        if (itemManager == null)
        {
            Debug.LogError("ItemManager is not found in the scene.");
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
        seedPrefab = Resources.Load<GameObject>("Prefabs/Seed");
        fruitPrefab = Resources.Load<GameObject>("Prefabs/Fruit");

        if (!isGathering)       //씨앗으로 심었을 때만 자라도록
        {
            StartCoroutine(GrowUp());
        }

        StartCoroutine(MakeOxygen());
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

    //성장 코루틴
    //단계에 따라 스케일 변경
    private IEnumerator GrowUp()
    {
        while (time <= grownTime)
        {
            yield return new WaitForSeconds(0.000001f);     //터지지 마
            time += (Time.deltaTime * planetManager.growthSpeed);
        }

        //다 컸으면 보통 크기로 키우고 채집도 가능하게 해 
        this.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        isGathering = true;

        yield return null;
    }

    //하루 지나면 0.01만큼 산소 생성
    private IEnumerator MakeOxygen()
    {
        while (this.gameObject)
        {
            yield return new WaitForSeconds(600f);
            planetManager.oxygenLevel += 0.01f;
            //Debug.Log("꽃이 산소 만드는 중");
        }
    }
}