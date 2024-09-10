using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class Seedling : MonoBehaviour, IItem
{
    private Transform playerTr;         //�÷��̾� ��ġ ��ƿ� ����
    private float distance = 3f;        //�ڼ� ȿ�� ������ �÷��̾�� ������Ʈ ���� �Ÿ�
    private float magnetSpeed = 0.2f;   //�ڼ� ȿ�� �ӵ�

    public Sprite inventoryImageSource;

    GameObject prefab;

    public Sprite GetSprite()
    {
        return inventoryImageSource;
    }

    private void Awake()
    {
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

    //������ ���
    public void GetItem()
    {
        if (ItemManager.Instance.SeedlingCount == 0)
        {
            ItemManager.Instance.AddItemList(prefab);
        }

        ItemManager.Instance.SeedlingCount++;
        //Debug.Log(this.name + " ���� : " + itemManager.SeedlingCount);

        Destroy(this.gameObject);
    }

    public void UseItem(int i)
    {
        ItemManager.Instance.SeedlingCount--;

        //�迭 �ȿ� �ִ� �� �ϳ� �������� �����ͼ� ����
        int num = Random.Range(0, ItemManager.Instance.treePrefabs.Length);
        GameObject treePrefab = ItemManager.Instance.treePrefabs[num];

        Transform playerPos = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();

        //������ ��ġ
        Vector3 plantTr = new Vector3(playerPos.position.x + 2f,
                                      playerPos.position.y,
                                      playerPos.position.z + 2f);

        //������ ���� ������ 0.1ũ��� �����ϰ� ä�� ���� ���� false�� ����
        GameObject go = Instantiate(treePrefab, plantTr, Quaternion.identity);
        go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        go.GetComponent<Tree>().isGathering = false;

        if (ItemManager.Instance.SeedlingCount == 0)
        {
            ItemManager.Instance.RemoveItemList(i);
        }
    }
}