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
        // 아이템 리스트의 크기를 오버해서 인덱스가 선택된 경우
        if(ItemManager.Instance.itemList.Count < idx+1)
        {
            return; 
        }

        // idx 는 계속 바뀌지만 해당 인덱스의 아이템 리스트가 비어 있을 수 있다
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

