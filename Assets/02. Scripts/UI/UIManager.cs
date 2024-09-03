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
    DieUI dieUI = null;
    InventoryUI inventoryUI = null;

    // esc ��ư �������� Ȯ��
    [HideInInspector]
    public bool isEsc = false;
    // TapŰ ���ȴ��� Ȯ��
    bool isTab = false;
    // ������ �����ߴ��� Ȯ��
    [HideInInspector]
    public bool isPaused = false;

    // PlanetManager ��������
    PlanetManager planetManager = null;

    // �÷��̾� ��ǲ ��������
    [HideInInspector]
    public StarterAssetsInputs playerInput = null;

    PlayerState playerState = null;

    private void Awake()
    {
        // ��� UI ��������
        UIManagerInit();

        // ������ ��� UI ������� Init ���ֱ�
        AllUIInit();

        // esc, die, �༺ ���� â�� �⺻���� �����ְ� �ϱ�
        OffSomeUI();
    }

    private void Update()
    {
        Esc();
        OpenPlanetState();
        ChangeBuildMode();
        VisiblePlayerStateUI();
        PlanetStateCheck();
    }

    // UIManager Init �޼���
    // UiManager ���� ������Ʈ�� ��� ��������
    #region UIManager Init
    private void UIManagerInit()
    {
        planetStateUI = GetComponentInChildren<PlanetStateUI>();
        playerStateUI = GetComponentInChildren<PlayerStateUI>();
        escUI = GetComponentInChildren<ESCUI>();
        dieUI = GetComponentInChildren<DieUI>();
        costUI = GetComponentInChildren<CostUI>();
        inventoryUI = GetComponentInChildren<InventoryUI>();
        buildUI = GetComponentInChildren<BuildUI>();

        planetManager = GameObject.FindGameObjectWithTag("PLANETMANAGER").GetComponent<PlanetManager>();
        playerInput = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<StarterAssetsInputs>();
        playerState = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<PlayerState>();
    }
    #endregion

    // LazyInit���� ���� ������Ʈ init���ִ� �޼���
    #region All UI Init
    private void AllUIInit()
    {
        playerStateUI.PlanyerStateUIInit();
        inventoryUI.InventoryUIInit();
        buildUI.BuildUIInit();
        planetStateUI.PlanetStateUIInit();
        costUI.CostUIInit();
        escUI.EscUIInit();
        dieUI.DieUiInit();
        dieUI.easterEggUI.EasterEggUIInit();
    }
    #endregion

    // Esc, Die, �༺ ���� â ���� �� ���α�
    #region Off Some UI
    private void OffSomeUI()
    {
        escUI.gameObject.SetActive(false);
        dieUI.gameObject.SetActive(false);
        dieUI.easterEggUI.gameObject.SetActive(false);
        planetStateUI.gameObject.SetActive(false);
    }
    #endregion

    // Esc �޼���
    #region ESC
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
    #endregion

    // ���� �༺ ����â �޼���
    #region Open Planet State
    private void OpenPlanetState()
    {
        // TabŰ�� ������ ��
        if (Input.GetKeyDown(KeyCode.Tab)) 
        {
            // isTab �ٲ��ֱ�
            isTab = !isTab;
        }
        // isTab�� true�� �� planetStateUI ����
        planetStateUI.gameObject.SetActive(isTab);
    }
    #endregion

    // �κ��丮 ���� �޼���
    #region Select Inventory
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
    #endregion

    // �κ� <-> �Ǽ� â ���� �޼���
    #region Change Build Mode
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
    #endregion

    // �༺ ���� üũ �޼���
    #region Planet State Check
    private void PlanetStateCheck()
    {
        planetStateUI.planetStateTexts[1].text = "��� : " + planetManager.temperature + "��C";
        planetStateUI.planetStateTexts[2].text = "�༺ �� ��ҷ� : " + planetManager.oxygenLevel + "%";
        if (planetManager.isWater)
        {
            planetStateUI.planetStateTexts[3].text = "�༺ �� ��� ������ �� ���� : O";
        }
        else
        {
            planetStateUI.planetStateTexts[3].text = "�༺ �� ��� ������ �� ���� : X";
        }
        planetStateUI.planetStateTexts[4].text = "���� ��ȭ�� : " + planetManager.LandLevel + "�ܰ�(MAX 5 �ܰ�)";
    }
    #endregion

    // �÷��̾� ���� UI ǥ�� �޼���
    #region Visible Player State UI
    private void VisiblePlayerStateUI()
    {
        playerStateUI.hpBarImage.fillAmount = playerState.playerHpUI;
        playerStateUI.fullBarImage.fillAmount = playerState.playerFullUI;
        playerStateUI.waterBarImage.fillAmount = playerState.playerWaterUI;
        playerStateUI.oxygenBarImage.fillAmount = playerState.playerOxygenUI;

        playerStateUI.fullText.text = playerState.playerFullUI * 100 + "%";
        playerStateUI.waterText.text = playerState.playerWaterUI * 100 + "%";
        playerStateUI.oxygenText.text = playerState.playerOxygenUI * 100 + "%";
    }
    #endregion

    // �κ��丮 UI ���ΰ�ħ �����۸Ŵ������� ȣ��
    #region Inventory Update Method
    public void AddInventoryUI(int idx, GameObject item)
    {
        InventoryUI inventoryUI = GetComponentInChildren<InventoryUI>();

        // �Ǽ� ���ÿ� inventoryUI ��Ȱ��ȭ ������ �׷��� ��� ������Ʈ���� �˻��ϴ� ���� �߰�
        if (inventoryUI == null)
        {
            InventoryUI[] allComponents = Resources.FindObjectsOfTypeAll<InventoryUI>();

            foreach (InventoryUI component in allComponents)
            {
                // ������Ʈ�� ��Ȱ��ȭ�� �������� Ȯ���մϴ�.
                if (!component.gameObject.activeInHierarchy)
                {
                    Debug.Log("��Ȱ��ȭ�� ������Ʈ�� ������Ʈ�� ã�ҽ��ϴ�: " + component.gameObject.name);

                    // ������Ʈ���� �Լ��� ȣ���մϴ�.
                    inventoryUI = component;
                }
            }
        }

        inventoryUI?.AddInventoryUIImage(idx, item);
    }

    public void RemoveInventoryUI()
    {
        GetComponentInChildren<InventoryUI>()?.RemoveInventoryUIImage();
    }
    #endregion
}