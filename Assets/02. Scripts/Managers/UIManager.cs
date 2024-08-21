using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // �÷��̾� ���� ��������

    // UI ��������
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