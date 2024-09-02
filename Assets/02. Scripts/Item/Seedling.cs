using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;
public class Seedling : MonoBehaviour, IItem
{
    private ItemManager itemManager;
    private Transform playerTr;         //�÷��̾� ��ġ ��ƿ� ����
    private float distance = 3f;        //�ڼ� ȿ�� ������ �÷��̾�� ������Ʈ ���� �Ÿ�
    private float magnetSpeed = 0.2f;   //�ڼ� ȿ�� �ӵ�

    public Sprite inventoryImageSource;

    GameObject prefab;

    //������ ���
    public void GetItem()
    {
        if (itemManager.SeedlingCount == 0)
        {
            itemManager.itemList.Add(prefab);
        }

        itemManager.SeedlingCount++;
        //Debug.Log(this.name + " ���� : " + itemManager.SeedlingCount);
        
        Destroy(this.gameObject);
    }

    public void ItemUse()
    {
        itemManager.SeedlingCount--;

        //�迭 �ȿ� �ִ� �� �ϳ� �������� �����ͼ� ����
        int num = Random.Range(0, itemManager.treePrefabs.Length);
        GameObject treePrefab = itemManager.treePrefabs[num];

        //������ ��ġ
        Vector3 plantTr = new Vector3(playerTr.position.x + Random.Range(0.1f, 0.5f),
                                      playerTr.position.y,
                                      playerTr.position.z + Random.Range(0.1f, 0.5f));

        //������ ���� ������ 0.1ũ��� �����ϰ� ä�� ���� ���� false�� ����
        GameObject go = Instantiate(treePrefab, plantTr, Quaternion.identity);
        go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        go.GetComponent<Tree>().isGathering = false;
    }

    public Sprite GetSprite()
    {
        return inventoryImageSource;
    }

    private void Awake()
    {
        //������ ItemManager ã�ƿ���
        itemManager = FindObjectOfType<ItemManager>();
        if (itemManager == null)
        {
            Debug.LogError("ItemManager is not found in the scene.");
        }

        playerTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();  //�÷��̾� �±׷� ��ġ �޾ƿ���
    }

    private void Start()
    {
        prefab = Resources.Load<GameObject>("Prefabs/Seedling");
    }
    private void Update()
    {
        if (Vector3.Distance(this.transform.position, playerTr.position) < distance)
        {
            Vector3 magnetToPlayer = playerTr.position - this.transform.position;
            transform.Translate(magnetToPlayer * magnetSpeed * Time.deltaTime, Space.Self);
        }
    }
}