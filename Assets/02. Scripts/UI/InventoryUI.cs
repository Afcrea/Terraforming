using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // �ڽ� UI ��������
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