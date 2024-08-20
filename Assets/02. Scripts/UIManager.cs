using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // 플레이어 스탯 가져오기

    // UI 가져오기
    PlayerStateUI playerStateUI = null;
    PlanetStateUI planetStateUI = null;
    ESCUI escUI = null;
    CostUI costUI = null;
    InventoryUI inventoryUI = null;

    private void Awake()
    {
        planetStateUI = GetComponentInChildren<PlanetStateUI>();
        planetStateUI = GetComponentInChildren<PlanetStateUI>();
        escUI = GetComponentInChildren<ESCUI>();
        costUI = GetComponentInChildren<CostUI>();
        inventoryUI = GetComponentInChildren<InventoryUI>();
    }
}