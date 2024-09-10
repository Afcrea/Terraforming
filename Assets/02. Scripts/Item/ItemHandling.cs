using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemHandling : MonoBehaviour
{
    Selector selector;
    Building building;

    int axeIndex = 1;
    int pickaxeIndex = 2;

    GameObject axeObject;
    GameObject pickaxeObject;

    bool _isbuilding;

    // Start is called before the first frame update
    void Start()
    {
        selector = FindObjectOfType<Selector>();

        building = FindObjectOfType<Building>();

        Transform[] childColliders = GetComponentsInChildren<Transform>();

        axeObject = childColliders[axeIndex].gameObject;
        pickaxeObject = childColliders[pickaxeIndex].gameObject;

        if(ItemManager.Instance)
        {
            if (ItemManager.Instance && !ItemManager.Instance.itemList[0])
            {
                ItemManager.Instance.itemList[0] = ItemManager.Instance.handPrefab;
            }
            if (ItemManager.Instance && !ItemManager.Instance.itemList[1])
            {
                ItemManager.Instance.itemList[1] = axeObject;
            }
            if (!ItemManager.Instance.itemList[2])
            {
                ItemManager.Instance.itemList[2] = pickaxeObject;
            }

            
            UIManager uiManager = FindObjectOfType<UIManager>();

            if (uiManager != null)
            {
                int idx = 0;
                foreach (GameObject item in ItemManager.Instance.itemList) 
                {
                    if (item == null)
                    {
                        continue;
                    }
                    uiManager.AddInventoryUI(idx, item);
                    idx++;
                }
            }
        }

        axeObject.SetActive(false);
        pickaxeObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(building.isBuilding)
        {
            axeObject.SetActive(false);
            pickaxeObject.SetActive(false);
            return;
        }

        if (selector.selectedIndex == axeIndex)
        {
            axeObject.SetActive(true);
        }
        else
        {
            axeObject.SetActive(false);
        }

        if (selector.selectedIndex == pickaxeIndex)
        {
            pickaxeObject.SetActive(true);
        }
        else
        {
            pickaxeObject.SetActive(false);
        }
    }
}
