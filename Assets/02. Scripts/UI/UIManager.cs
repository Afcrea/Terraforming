using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    // UI�� ��������
    [HideInInspector]
    public PlanetStateUI planetStateUI = null;
    [HideInInspector]
    public PlayerStateUI playerStateUI = null;
    [HideInInspector]
    public CostUI costUI = null;
    [HideInInspector]
    public BuildUI buildUI = null;
    ESCUI escUI = null;
    InventoryUI inventoryUI = null;

    // esc ��ư �������� Ȯ��
    [HideInInspector]
    public bool isEsc = false;
    // ������ �����ߴ��� Ȯ��
    [HideInInspector]
    public bool isPaused = false;

    // PlanetManager ��������
    PlanetManager planetManager = null;

    // �÷��̾� ��ǲ ��������
    [HideInInspector]
    public StarterAssetsInputs playerInput = null;

    private void Awake()
    {
        planetStateUI = GetComponentInChildren<PlanetStateUI>();
        playerStateUI = GetComponentInChildren<PlayerStateUI>();
        escUI = GetComponentInChildren<ESCUI>();
        costUI = GetComponentInChildren<CostUI>();
        inventoryUI = GetComponentInChildren<InventoryUI>();
        buildUI = GetComponentInChildren<BuildUI>();

        planetManager = GameObject.Find("PlanetManager").GetComponent<PlanetManager>();
        playerInput = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<StarterAssetsInputs>();

        // esc â�� �⺻���� �����ְ� �ϱ�
        escUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        // UI Update �޼��� ����
        PlanetStateUIUpdate();
        // Esc �޼��� ����
        Esc();
        // �κ�, �Ǽ� â ��ȯ �޼��� ����
        ChangeBuildMode();
    }

    // �༺ ���� UI Update �޼���
    private void PlanetStateUIUpdate()
    {
        planetStateUI.temperatureText.text = "��� " + planetManager.temperature.ToString("F1") + " ��C";
    }

    // Esc �޼���
    private void Esc()
    {
        // Esc ��ư�� ������ ��
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Esc ��ư�� ���� ������ bool�� ���� ex) �ѹ� ������ true, �ι� ������ false
            isEsc = !isEsc;
            isPaused = !isPaused;
            playerInput.isCameraMove = !playerInput.isCameraMove;
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

    // �κ��丮 ���� �޼���
    public void SelectInventory(int _index)
    {
        if (!buildUI.isBuild)
        {
            inventoryUI.selectInven.transform.SetParent(inventoryUI.inventorys[_index].transform);
            inventoryUI.rect.position = inventoryUI.inventorys[_index].transform.position;
        }
        else
        {
            buildUI.buildInvenGroup.selectBuildInven.transform.SetParent(buildUI.buildInvenGroup.buildInvens[_index].transform);
            buildUI.buildInvenGroup.rect.position = buildUI.buildInvenGroup.buildInvens[_index].transform.position;
        }
    }

    // �κ� <-> �Ǽ� â ���� �޼���
    private void ChangeBuildMode()
    {
        if (Input.GetKeyDown(KeyCode.B) && buildUI.isBuild == false)
        {
            // �Ǽ� ���·� ��ȯ
            buildUI.isBuild = true;
            inventoryUI.gameObject.SetActive(false);
            buildUI.buildInvenGroup.gameObject.SetActive(true);
            buildUI.texts[1].text = "�κ��丮";
            buildUI.texts[3].gameObject.SetActive(true);
            buildUI.buttons[1].gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.B) && buildUI.isBuild == true)
        {
            // �κ��丮�� ��ȯ
            buildUI.isBuild = false;
            buildUI.buildInvenGroup.gameObject.SetActive(false);
            inventoryUI.gameObject.SetActive(true);
            buildUI.texts[1].text = "�Ǽ�";
            buildUI.texts[3].gameObject.SetActive(false);
            buildUI.buttons[1].gameObject.SetActive(false);
        }
    }
}