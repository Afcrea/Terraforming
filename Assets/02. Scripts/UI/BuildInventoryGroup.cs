using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildInventoryGroup : MonoBehaviour
{
    // 자식 UI 가져오기
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