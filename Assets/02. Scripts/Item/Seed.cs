using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Seed : MonoBehaviour, IItem
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
        prefab = Resources.Load<GameObject>("Prefabs/Seed");
    }
    private void Update()
    {
        if (Vector3.Distance(this.transform.position, playerTr.position) < distance)
        {
            Vector3 magnetToPlayer = playerTr.position - this.transform.position;
            transform.Translate(magnetToPlayer * magnetSpeed * Time.deltaTime, Space.Self);
        }
    }


    //���
    public void GetItem()
    {
        if (ItemManager.Instance.SeedCount == 0)
        {
            ItemManager.Instance.AddItemList(prefab);
        }

        ItemManager.Instance.SeedCount++;
        //Debug.Log(this.name + " ���� : " + itemManager.SeedCount);

        Destroy(this.gameObject);
    }
    public void UseItem(int i)
    {
        ItemManager.Instance.SeedCount--;

        Transform playerTransform = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();

        //������ ��ġ
        Vector3 plantTr = playerTransform.forward * 5f;
        

        //������ ���� ������ 0.1ũ��� �����ϰ� ä�� ���� ���� false�� ����
        GameObject go = Instantiate(ItemManager.Instance.flowerPrefab, plantTr, Quaternion.identity);
        go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        go.GetComponent<Flower>().isGathering = false;

        if (ItemManager.Instance.SeedCount == 0)
        {
            ItemManager.Instance.RemoveItem(i);
        }
    }
}