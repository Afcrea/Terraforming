using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // 자식 UI 가져오기
    [HideInInspector]
    public Inventory[] inventorys;
    [HideInInspector]
    public SelectInven selectInven = null;
    [HideInInspector]
    public RectTransform rect = null;

    void Awake()
    {
        inventorys = GetComponentsInChildren<Inventory>();
        selectInven = GetComponentInChildren<SelectInven>();
        rect = selectInven.GetComponent<RectTransform>();
    }
}