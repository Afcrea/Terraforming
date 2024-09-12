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
    BackLobbyUI backLobbyUI = null;

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

    // ���α׷��� �� ��������
    [HideInInspector]
    public PickAxeUI pickaxeUI  = null;


    PlayerState playerState = null;

    private void Awake()
    {
        // ��� UI ��������
        UIManagerInit();

        // ������ ��� UI ������� Init ���ֱ�
        AllUIInit();

        // esc, die, �༺ ���� â�� �⺻���� �����ְ� �ϱ� �߰��� pickaxeUI ���α׷��� �ٵ� ��
        OffSomeUI();
    }

    private void Update()
    {
        Esc();
        OpenPlanetState();
        ChangeBuildMode();
        VisiblePlayerStateUI();
        CostTextUI();
        PlanetStateCheck();
        BackLobbyUI();
        PlayerDieUI();
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
        backLobbyUI = GetComponentInChildren<BackLobbyUI>();
        pickaxeUI = GetComponentInChildren<PickAxeUI>();

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
        backLobbyUI.BackLobbyUIInit();
    }
    #endregion

    // Esc, Die, �༺ ���� â ���� �� ���α�  �߰��� pickaxeUI ���α׷��� �ٵ� ��
    #region Off Some UI
    private void OffSomeUI()
    {
        escUI.gameObject.SetActive(false);
        dieUI.gameObject.SetActive(false);
        dieUI.easterEggUI.gameObject.SetActive(false);
        planetStateUI.gameObject.SetActive(false);
        backLobbyUI.gameObject.SetActive(false);
        pickaxeUI.gameObject.SetActive(false);
    }
    #endregion

    // Esc �޼���
    #region ESC
    private void Esc()
    {
        // �÷��̾ ����ְ� �Ǽ� ���� �ƴҶ�
        if (buildUI.isBuild == false && playerState.PlayerAlive)
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
                // ���콺 Ŀ�� Ȱ��ȭ
                Cursor.lockState = CursorLockMode.None;
                // escâ Ȱ��ȭ
                escUI.gameObject.SetActive(true);
            }
            else // isEsc�� false��
            {
                // ���� ����
                Time.timeScale = 1.0f;
                // ���콺 Ŀ�� ��Ȱ��ȭ
                Cursor.lockState = CursorLockMode.Locked;
                // escâ ��Ȱ��ȭ
                escUI.gameObject.SetActive(false);
            }
        }
    }
    #endregion

    // �÷��̾� �׾��� �� ǥ���� Ui
    #region Player Die UI
    private void PlayerDieUI()
    {
        if (!playerState.PlayerAlive) // �÷��̾ �׾��� ��
        {
            // die ui Ȱ��ȭ
            dieUI.gameObject.SetActive(!playerState.PlayerAlive);
            // Ŀ�� lock ����
            Cursor.lockState = CursorLockMode.None;
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
        if (!buildUI.isBuild) // �Ǽ� ���°� �ƴ� ��
        {
            // �κ� ���� UI�� _index�� ��ġ�� ������
            inventoryUI.selectInven.transform.SetParent(inventoryUI.inventorys[_index].transform);
            inventoryUI.rect.position = inventoryUI.inventorys[_index].transform.position;
            // �Ǽ� �� �Ҹ� ��ȭ ǥ�� UI ����
            buildUI.buildCostUI.gameObject.SetActive(buildUI.isBuild);
        }
        else // �Ǽ� ������ ��
        {
            // ���๰ ���� UI�� _index�� ��ġ�� ������
            buildUI.buildInvenGroup.selectBuildInven.transform.SetParent(buildUI.buildInvenGroup.buildInvens[_index].transform);
            buildUI.buildInvenGroup.rect.position = buildUI.buildInvenGroup.buildInvens[_index].transform.position;
            // �Ǽ� �� �Ҹ� ��ȭ ǥ�� UI �ѱ�
            buildUI.buildCostUI.gameObject.SetActive(buildUI.isBuild);
            switch (_index) // ���õ� ���๰(_index)�� ���� �ؽ�Ʈ ����
            {
                case 0:
                    buildUI.buildCostUIText.text = buildUI.buildCostUI.WallCostText;
                    break;
                case 1:
                    buildUI.buildCostUIText.text = buildUI.buildCostUI.FloorCostText;
                    break;
                case 2:
                    buildUI.buildCostUIText.text = buildUI.buildCostUI.OxyMakerCostText;
                    break;
                case 3:
                    buildUI.buildCostUIText.text = buildUI.buildCostUI.WaterMakerCostText;
                    break;
                case 4:
                    buildUI.buildCostUIText.text = buildUI.buildCostUI.WaterSupplierCostText;
                    break;
                case 5:
                    buildUI.buildCostUIText.text = buildUI.buildCostUI.LandCostText;
                    break;
                default:
                    buildUI.buildCostUIText.text = buildUI.buildCostUI.NotBuildItem;
                    break;
            }
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
            // ���콺 Ŀ�� Ȱ��ȭ
            Cursor.lockState = CursorLockMode.None;
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
            // ���콺 Ŀ�� ��Ȱ��ȭ
            Cursor.lockState = CursorLockMode.Locked;
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

    // ���Ͽ��� �÷��̾ ã�Ƽ� �÷��̾ ��ó�� ���� ���� UI ǥ�� �޼���
    #region Planet Scene To LobbyScene UI Method
    private void BackLobbyUI()
    {
        // ���Ͽ��� �÷��̾ ã�� �޼���
        backLobbyUI.Rocket.RocketFindPlayer();
        // �ؽ�Ʈ�� ǥ������ �Ǵ��ϴ� �޼���
        backLobbyUI.OnOffBackLobbyText();
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

    // �÷��̾� �ڽ�Ʈ UI ǥ�� �޼���
    #region Vislble Cost UI
    private void CostTextUI()
    {
        costUI.costTexts[0].text = "�� : " + ItemManager.Instance.StoneCount.ToString("00") + "��";
        costUI.costTexts[1].text = "ö : " + ItemManager.Instance.IronCount.ToString("00") + "��";
        costUI.costTexts[2].text = "���� : " + ItemManager.Instance.WoodCount.ToString("00") + "��";
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
                    //Debug.Log("��Ȱ��ȭ�� ������Ʈ�� ������Ʈ�� ã�ҽ��ϴ�: " + component.gameObject.name);

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