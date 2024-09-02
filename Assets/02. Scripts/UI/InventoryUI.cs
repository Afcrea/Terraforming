using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    // �ڽ� UI ��������
    [HideInInspector]
    public Inventory[] inventorys;
    [HideInInspector]
    public SelectInven selectInven = null;
    [HideInInspector]
    public RectTransform rect = null;

    private ItemManager itemManager;

    public void InventoryUIInit()
    {
        inventorys = GetComponentsInChildren<Inventory>();
        selectInven = GetComponentInChildren<SelectInven>();
        rect = selectInven.GetComponent<RectTransform>();

        itemManager = FindObjectOfType<ItemManager>();
        if (itemManager == null)
        {
            Debug.LogError("ItemManager is not found in the scene.");
        }
    }

    public void inventoryUIUpdate()
    {
        if (ItemManager.Instance.itemList.Count > 0)
        {
            int idx = 0;
            foreach (GameObject itemList in ItemManager.Instance.itemList)
            {
                if (inventorys[idx].transform.Find("ItemIconImage") != null)
                {
                    if (itemList == null)
                    {
                        Destroy(inventorys[idx].transform.Find("ItemIconImage").gameObject);
                    }
                    idx++;
                    continue;
                }

                GameObject imageObject = new GameObject("ItemIconImage");

                RectTransform rectTransform = imageObject.AddComponent<RectTransform>();

                rectTransform.SetParent(inventorys[idx].GetComponent<RectTransform>());

                rectTransform.localScale = Vector3.one;
                rectTransform.anchoredPosition = Vector3.zero;



                rectTransform.AddComponent<CanvasRenderer>();
                rectTransform.AddComponent<Image>();

                rectTransform.GetComponent<Image>().sprite = itemList.GetComponent<IItem>().GetSprite();
                idx++;
            }
        }
    }

    public void AddInventoryUIImage(int idx, GameObject item)
    {
        GameObject imageObject = new GameObject("ItemIconImage");

        RectTransform rectTransform = imageObject.AddComponent<RectTransform>();

        rectTransform.SetParent(inventorys[idx].GetComponent<RectTransform>());

        rectTransform.localScale = Vector3.one;
        rectTransform.anchoredPosition = Vector3.zero;



        rectTransform.AddComponent<CanvasRenderer>();
        rectTransform.AddComponent<Image>();

        rectTransform.GetComponent<Image>().sprite = item.GetComponent<IItem>().GetSprite();
    }

    public void RemoveInventoryUIImage()
    {
        int idx = 0;
        foreach(GameObject itemList in ItemManager.Instance.itemList)
        {
            if(itemList == null)
            {
                Destroy(inventorys[idx].transform.Find("ItemIconImage")?.gameObject);
            }
            idx++;
        }
    }
}