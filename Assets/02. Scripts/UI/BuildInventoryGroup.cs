using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildInventoryGroup : MonoBehaviour
{
    // �ڽ� UI ��������
    [HideInInspector]
    public BuildInventory[] buildInvens = null;
    [HideInInspector]
    public SelectBuildInven selectBuildInven = null;
    [HideInInspector]
    public RectTransform rect = null;

    private void Awake()
    {
        buildInvens = GetComponentsInChildren<BuildInventory>();
        selectBuildInven = GetComponentInChildren<SelectBuildInven>();
        rect = selectBuildInven.GetComponent<RectTransform>();
    }
}