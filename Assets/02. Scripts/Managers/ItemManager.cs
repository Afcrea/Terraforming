using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemManager : MonoBehaviour
{
    //������ ���� ���� ���� ����
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

    //�ɱ� ���� ������ ���� ����
    GameObject[] treePrefabs = null;
    GameObject flowerPrefab = null;

    //������ ��ġ �ľ��ϱ� ���� ����
    Transform playerTr = null;

    private void Start()
    {
        treePrefabs = Resources.LoadAll<GameObject>("Prefabs/TreePrefabs");
        flowerPrefab = Resources.Load<GameObject>("Prefabs/Flower");

        //�÷��̾� ��ġ �޾ƿ�
        playerTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();
        //Ȥ�� �÷��̾ Ray Sphere �ѷ��� �ٴڰ� �´��� ���� �ϳ� �����ؼ� �� ��ġ�� �޾Ƽ� ���� => ��Ż�濡 �ɱ� ����
    }

    //�������� ���� �����
    public void PlantTree()
    {
        SeedlingCount--;

        //�迭 �ȿ� �ִ� �� �ϳ� �������� �����ͼ� ����
        int num = Random.Range(0, treePrefabs.Length);
        GameObject treePrefab = treePrefabs[num];

        //������ ��ġ
        Vector3 plantTr = new Vector3(playerTr.position.x + Random.Range(0.1f, 0.5f),
                                      playerTr.position.y,
                                      playerTr.position.z + Random.Range(0.1f, 0.5f));

        //������ ���� ������ 0.1ũ��� �����ϰ� ä�� ���� ���� false�� ����
        GameObject go = Instantiate(treePrefab, plantTr, Quaternion.identity);
        go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        go.GetComponent<Tree>().isGathering = false;
    }

    //�������� �� �����
    public void PlantFlower()
    {
        SeedCount--;

        //������ ��ġ
        Vector3 plantTr = new Vector3(playerTr.position.x + Random.Range(0.1f, 0.5f),
                                      playerTr.position.y,
                                      playerTr.position.z + Random.Range(0.1f, 0.5f));

        //������ ���� ������ 0.1ũ��� �����ϰ� ä�� ���� ���� false�� ����
        GameObject go = Instantiate(flowerPrefab, plantTr, Quaternion.identity);
        go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        go.GetComponent<Flower>().isGathering = false;
    }

    //���� �Ա�
    public void EatFruit()
    {
        FruitCount--;

        //�� �÷��̾� ������ +
    }
}