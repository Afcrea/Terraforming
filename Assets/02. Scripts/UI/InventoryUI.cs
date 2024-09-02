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

    void Awake()
    {
        inventorys = GetComponentsInChildren<Inventory>();
        selectInven = GetComponentInChildren<SelectInven>();
        rect = selectInven.GetComponent<RectTransform>();
    }

    private void Start()
    {
        //������ ItemManager ã�ƿ���
        itemManager = FindObjectOfType<ItemManager>();
        if (itemManager == null)
        {
            Debug.LogError("ItemManager is not found in the scene.");
        }
    }

    private void Update()
    {
        if (itemManager.itemList.Count > 0) 
        {
            int idx = 0;
            foreach (GameObject itemList in itemManager.itemList) 
            {
                
                if(inventorys[idx].transform.Find("ItemIconImage") != null) 
                {
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
                print(idx);
            }
        }
    }
}