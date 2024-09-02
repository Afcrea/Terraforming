using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
public class Fruit : MonoBehaviour, IItem
{
    private ItemManager itemManager;
    private Transform playerTr;         //�÷��̾� ��ġ ��ƿ� ����
    private float distance = 3f;        //�ڼ� ȿ�� ������ �÷��̾�� ������Ʈ ���� �Ÿ�
    private float magnetSpeed = 0.2f;   //�ڼ� ȿ�� �ӵ�

    public Sprite inventoryImageSource;

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

    public void GetItem()
    {
        itemManager.FruitCount++;
        //Debug.Log(this.name + " ���� : " + itemManager.FruitCount);
        itemManager.itemList.Add(this.gameObject);
        Destroy(this.gameObject);
    }

    public void ItemUse()
    {
        itemManager.FruitCount--;

        //�� �÷��̾� ������ +

        itemManager.playerState.PlayerCurrFull += 10;

        itemManager.playerState.PlayerCurrFull = (itemManager.playerState.PlayerCurrFull > itemManager.playerState.PlayerInitFull) ? itemManager.playerState.PlayerInitFull : itemManager.playerState.PlayerCurrFull;
    }

    public Sprite GetSprite()
    {
        return inventoryImageSource;
    }
}