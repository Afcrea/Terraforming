using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
public class Fruit : MonoBehaviour, IItem
{
    private Transform playerTr;         //�÷��̾� ��ġ ��ƿ� ����
    private float distance = 3f;        //�ڼ� ȿ�� ������ �÷��̾�� ������Ʈ ���� �Ÿ�
    private float magnetSpeed = 1f;   //�ڼ� ȿ�� �ӵ�

    public Sprite inventoryImageSource;

    GameObject prefab;

    private void Awake()
    {
        playerTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();  //�÷��̾� �±׷� ��ġ �޾ƿ���

    }

    private void Start()
    {
        prefab = Resources.Load<GameObject>("Prefabs/Fruit");
    }

    private void Update()
    {
        if (Vector3.Distance(this.transform.position, playerTr.position) < distance)
        {
            Vector3 magnetToPlayer = playerTr.position - this.transform.position;
            transform.Translate(magnetToPlayer * magnetSpeed * Time.deltaTime , Space.Self);
        }
    }

    public void GetItem()
    {
        //Debug.Log(this.name + " ���� : " + itemManager.FruitCount);

        if (ItemManager.Instance.FruitCount == 0)
        {
            ItemManager.Instance.AddItemList(prefab);
        }

        ItemManager.Instance.FruitCount++;

        Destroy(this.gameObject);
    }

    public void UseItem(int i)
    {
        print(ItemManager.Instance.FruitCount);
        if(ItemManager.Instance == null || ItemManager.Instance.FruitCount <= 0)
        {
            return;
        }
        ItemManager.Instance.FruitCount--;

        //�� �÷��̾� ������ +

        ItemManager.Instance.playerState.PlayerCurrFull += 10;

        ItemManager.Instance.playerState.PlayerCurrFull = (ItemManager.Instance.playerState.PlayerCurrFull > ItemManager.Instance.playerState.PlayerInitFull) ? ItemManager.Instance.playerState.PlayerInitFull : ItemManager.Instance.playerState.PlayerCurrFull;

        if(ItemManager.Instance.FruitCount == 0)
        {
            ItemManager.Instance.RemoveItemList(i);
        }
    }

    public Sprite GetSprite()
    {
        return inventoryImageSource;
    }
}