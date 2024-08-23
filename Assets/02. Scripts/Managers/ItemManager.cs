using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemManager : MonoBehaviour
{
    //아이템 개수 관리 위한 변수
    private int ironCount = 0;
    private int stoneCount = 0;
    private int woodCount = 0;
    private int seedlingCount = 0;
    private int seedCount = 0;
    private int fruitCount = 0;

    public int IronCount
    {
        get { return ironCount; }
        set { ironCount = value; }
    }
    public int StoneCount
    {
        get { return stoneCount; }
        set { stoneCount = value; }
    }
    public int WoodCount
    {
        get { return woodCount; }
        set { woodCount = value; }
    }
    public int SeedlingCount
    {
        get { return seedlingCount; }
        set { seedlingCount = value; }
    }
    public int SeedCount
    {
        get { return seedCount; }
        set { seedCount = value; }
    }
    public int FruitCount
    {
        get { return fruitCount; }
        set { fruitCount = value; }
    }

    //심기 위한 프리팹 저장 변수
    GameObject[] treePrefabs = null;
    GameObject flowerPrefab = null;

    //생성할 위치 파악하기 위한 변수
    Transform playerTr = null;

    private void Start()
    {
        treePrefabs = Resources.LoadAll<GameObject>("Prefabs/TreePrefabs");
        flowerPrefab = Resources.Load<GameObject>("Prefabs/Flower");

        //플레이어 위치 받아옴
        playerTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();
        //혹은 플레이어가 Ray Sphere 뿌려서 바닥과 맞닿은 지점 하나 추출해서 그 위치값 받아서 생성 => 비탈길에 심기 가능
    }

    //묘목으로 나무 재생성
    public void PlantTree()
    {
        SeedlingCount--;

        //배열 안에 있는 거 하나 랜덤으로 가져와서 생성
        int num = Random.Range(0, treePrefabs.Length);
        GameObject treePrefab = treePrefabs[num];

        //생성할 위치
        Vector3 plantTr = new Vector3(playerTr.position.x + Random.Range(0.1f, 0.5f),
                                      playerTr.position.y,
                                      playerTr.position.z + Random.Range(0.1f, 0.5f));

        //심으면 원래 나무의 0.1크기로 생성하고 채집 가능 여부 false로 변경
        GameObject go = Instantiate(treePrefab, plantTr, Quaternion.identity);
        go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        go.GetComponent<Tree>().isGathering = false;
    }

    //씨앗으로 꽃 재생성
    public void PlantFlower()
    {
        SeedCount--;

        //생성할 위치
        Vector3 plantTr = new Vector3(playerTr.position.x + Random.Range(0.1f, 0.5f),
                                      playerTr.position.y,
                                      playerTr.position.z + Random.Range(0.1f, 0.5f));

        //심으면 원래 나무의 0.1크기로 생성하고 채집 가능 여부 false로 변경
        GameObject go = Instantiate(flowerPrefab, plantTr, Quaternion.identity);
        go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        go.GetComponent<Flower>().isGathering = false;
    }

    //열매 먹기
    public void EatFruit()
    {
        FruitCount--;

        //★ 플레이어 포만감 +
    }
}