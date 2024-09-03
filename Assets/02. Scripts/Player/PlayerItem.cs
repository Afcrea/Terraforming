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

        ItemManager.Instance.itemList[idx].GetComponent<IItem>().UseItem(idx);
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

