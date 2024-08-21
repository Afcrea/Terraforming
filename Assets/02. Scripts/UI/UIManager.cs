using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // UI�� ��������
    PlayerStateUI playerStateUI = null;
    PlanetStateUI planetStateUI = null;
    ESCUI escUI = null;
    CostUI costUI = null;
    InventoryUI inventoryUI = null;

    // esc ��ư �������� Ȯ��
    [HideInInspector]
    public bool isEsc = false;
    // ������ �����ߴ��� Ȯ��
    [HideInInspector]
    public bool isPaused = false;

    private void Awake()
    {
        planetStateUI = GetComponentInChildren<PlanetStateUI>();
        planetStateUI = GetComponentInChildren<PlanetStateUI>();
        escUI = GetComponentInChildren<ESCUI>();
        costUI = GetComponentInChildren<CostUI>();
        inventoryUI = GetComponentInChildren<InventoryUI>();

        // esc â�� �⺻���� �����ְ� �ϱ�
        escUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Esc �޼��� ����
        Esc();
    }

    private void Esc()
    {
        // Esc ��ư�� ������ ��
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            // Esc ��ư�� ���� ������ bool�� ���� ex) �ѹ� ������ true, �ι� ������ false
            isEsc = !isEsc;
            isPaused = !isPaused;
        }

        // isEsc�� true�� 
        if (isEsc)
        {
            // ���� ����
            Time.timeScale = 0f;
            // escâ Ȱ��ȭ
            escUI.gameObject.SetActive(true);
        }
        else // isEsc�� false��
        {
            // ���� ����
            Time.timeScale = 1.0f;
            // escâ ��Ȱ��ȭ
            escUI.gameObject.SetActive(false);
        }
    }
}