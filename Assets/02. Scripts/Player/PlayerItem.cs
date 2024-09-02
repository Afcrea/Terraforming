using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    private ItemManager itemManager;

    GameObject seedPrefabs = null;
    GameObject seedlingPrefabs = null;

    public int idx;

    private void Awake()
    {
        itemManager = FindObjectOfType<ItemManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        seedPrefabs = Resources.Load<GameObject>("Prefabs/Seed");
        seedlingPrefabs = Resources.Load<GameObject>("Prefabs/Seedling");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Checkitem1()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
        }
    }

    void OnUseItem()
    {

        // ������ ����Ʈ�� ũ�⸦ �����ؼ� �ε����� ���õ� ���
        if(ItemManager.Instance.itemList.Count < idx+1)
        {
            return; 
        }

        // idx �� ��� �ٲ����� �ش� �ε����� ������ ����Ʈ�� ��� ���� �� �ִ�
        if (ItemManager.Instance.itemList[idx] == null)
        {
            return;
        }

        itemManager.itemList[idx].GetComponent<IItem>().UseItem(idx);
    }

    public void currItem()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        IItem item = other.GetComponent<IItem>();

        if (item != null)
        {
            item.GetItem();
        }
    }
}

