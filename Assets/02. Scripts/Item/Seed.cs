using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Seed : MonoBehaviour, IItem
{
    private ItemManager itemManager;
    private Transform playerTr;         //�÷��̾� ��ġ ��ƿ� ����
    private float distance = 3f;        //�ڼ� ȿ�� ������ �÷��̾�� ������Ʈ ���� �Ÿ�
    private float magnetSpeed = 0.2f;   //�ڼ� ȿ�� �ӵ�

    public Sprite inventoryImageSource;

    //���
    public void GetItem()
    {
        itemManager.SeedCount++;
        //Debug.Log(this.name + " ���� : " + itemManager.SeedCount);
        itemManager.itemList.Add(this.gameObject);
        Destroy(this.gameObject);
    }
    public void ItemUse()
    {
        itemManager.SeedCount--;

        //������ ��ġ
        Vector3 plantTr = new Vector3(playerTr.position.x + Random.Range(0.1f, 0.5f),
                                      playerTr.position.y,
                                      playerTr.position.z + Random.Range(0.1f, 0.5f));

        //������ ���� ������ 0.1ũ��� �����ϰ� ä�� ���� ���� false�� ����
        GameObject go = Instantiate(itemManager.flowerPrefab, plantTr, Quaternion.identity);
        go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        go.GetComponent<Flower>().isGathering = false;
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

    private void Update()
    {
        if (Vector3.Distance(this.transform.position, playerTr.position) < distance)
        {
            Vector3 magnetToPlayer = playerTr.position - this.transform.position;
            transform.Translate(magnetToPlayer * magnetSpeed * Time.deltaTime, Space.Self);
        }
    }
}