using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    // UI들 가져오기
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

    // esc 버튼 눌렀는지 확인
    [HideInInspector]
    public bool isEsc = false;
    // Tap키 눌렸는지 확인
    bool isTab = false;
    // 게임을 정지했는지 확인
    [HideInInspector]
    public bool isPaused = false;

    // PlanetManager 가져오기
    PlanetManager planetManager = null;

    // 플레이어 인풋 가져오기
    [HideInInspector]
    public StarterAssetsInputs playerInput = null;

    // 프로그레스 바 가져오기
    [HideInInspector]
    public PickAxeUI pickaxeUI  = null;


    PlayerState playerState = null;

    private void Awake()
    {
        // 모든 UI 가져오기
        UIManagerInit();

        // 가져온 모든 UI 순서대로 Init 해주기
        AllUIInit();

        // esc, die, 행성 스탯 창은 기본으로 꺼져있게 하기 추가로 pickaxeUI 프로그레스 바도 끔
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

    // UIManager Init 메서드
    // UiManager 하위 오브젝트들 모두 가져오기
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

    // LazyInit으로 하위 오브젝트 init해주는 메서드
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

    // Esc, Die, 행성 스탯 창 시작 시 꺼두기  추가로 pickaxeUI 프로그레스 바도 끔
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

    // Esc 메서드
    #region ESC
    private void Esc()
    {
        // 플레이어가 살아있고 건설 중이 아닐때
        if (buildUI.isBuild == false && playerState.PlayerAlive)
        {
            // Esc 버튼을 눌렀을 때
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Esc 버튼이 눌릴 때마다 bool값 변경 ex) 한번 누르면 true, 두번 누르면 false
                isEsc = !isEsc;
                isPaused = !isPaused;
                playerInput.isCameraMove = !playerInput.isCameraMove;
            }

            // isEsc가 true면 
            if (isEsc)
            {
                // 게임 정지
                Time.timeScale = 0f;
                // 마우스 커서 활성화
                Cursor.lockState = CursorLockMode.None;
                // esc창 활성화
                escUI.gameObject.SetActive(true);
            }
            else // isEsc가 false면
            {
                // 게임 실행
                Time.timeScale = 1.0f;
                // 마우스 커서 비활성화
                Cursor.lockState = CursorLockMode.Locked;
                // esc창 비활성화
                escUI.gameObject.SetActive(false);
            }
        }
    }
    #endregion

    // 플레이어 죽었을 때 표시할 Ui
    #region Player Die UI
    private void PlayerDieUI()
    {
        if (!playerState.PlayerAlive) // 플레이어가 죽었을 때
        {
            // die ui 활성화
            dieUI.gameObject.SetActive(!playerState.PlayerAlive);
            // 커서 lock 해제
            Cursor.lockState = CursorLockMode.None;
        }
    }
    #endregion

    // 오픈 행성 정보창 메서드
    #region Open Planet State
    private void OpenPlanetState()
    {
        // Tab키가 눌렸을 때
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // isTab 바꿔주기
            isTab = !isTab;
        }
        // isTab이 true일 때 planetStateUI 열기
        planetStateUI.gameObject.SetActive(isTab);
    }
    #endregion

    // 인벤토리 선택 메서드
    #region Select Inventory
    public void SelectInventory(int _index)
    {
        if (!buildUI.isBuild) // 건설 상태가 아닐 때
        {
            // 인벤 선택 UI를 _index의 위치로 보내기
            inventoryUI.selectInven.transform.SetParent(inventoryUI.inventorys[_index].transform);
            inventoryUI.rect.position = inventoryUI.inventorys[_index].transform.position;
            // 건설 시 소모 재화 표시 UI 끄기
            buildUI.buildCostUI.gameObject.SetActive(buildUI.isBuild);
        }
        else // 건설 상태일 때
        {
            // 건축물 선택 UI를 _index의 위치로 보내기
            buildUI.buildInvenGroup.selectBuildInven.transform.SetParent(buildUI.buildInvenGroup.buildInvens[_index].transform);
            buildUI.buildInvenGroup.rect.position = buildUI.buildInvenGroup.buildInvens[_index].transform.position;
            // 건설 시 소모 재화 표시 UI 켜기
            buildUI.buildCostUI.gameObject.SetActive(buildUI.isBuild);
            switch (_index) // 선택된 건축물(_index)에 따라 텍스트 매핑
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

    // 인벤 <-> 건설 창 변경 메서드
    #region Change Build Mode
    private void ChangeBuildMode()
    {
        if (Input.GetKeyDown(KeyCode.B) && buildUI.isBuild == false)
        {
            // 건설 상태로 전환
            buildUI.isBuild = true;
            inventoryUI.gameObject.SetActive(false);
            buildUI.buildInvenGroup.gameObject.SetActive(true);
            buildUI.texts[1].text = "인벤토리";
            buildUI.texts[3].gameObject.SetActive(true);
            buildUI.buttons[1].gameObject.SetActive(true);
            // 마우스 커서 활성화
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyDown(KeyCode.B) && buildUI.isBuild == true)
        {
            // 인벤토리로 전환
            buildUI.isBuild = false;
            buildUI.buildInvenGroup.gameObject.SetActive(false);
            inventoryUI.gameObject.SetActive(true);
            buildUI.texts[1].text = "건설";
            buildUI.texts[3].gameObject.SetActive(false);
            buildUI.buttons[1].gameObject.SetActive(false);
            // 마우스 커서 비활성화
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    #endregion

    // 행성 상태 체크 메서드
    #region Planet State Check
    private void PlanetStateCheck()
    {
        planetStateUI.planetStateTexts[1].text = "기온 : " + planetManager.temperature + "ºC";
        planetStateUI.planetStateTexts[2].text = "행성 내 산소량 : " + planetManager.oxygenLevel + "%";
        if (planetManager.isWater)
        {
            planetStateUI.planetStateTexts[3].text = "행성 내 사용 가능한 물 존재 : O";
        }
        else
        {
            planetStateUI.planetStateTexts[3].text = "행성 내 사용 가능한 물 존재 : X";
        }
        planetStateUI.planetStateTexts[4].text = "토지 정화도 : " + planetManager.LandLevel + "단계(MAX 5 단계)";
    }
    #endregion

    // 로켓에서 플레이어를 찾아서 플레이어가 근처에 있을 때만 UI 표시 메서드
    #region Planet Scene To LobbyScene UI Method
    private void BackLobbyUI()
    {
        // 로켓에서 플레이어를 찾는 메서드
        backLobbyUI.Rocket.RocketFindPlayer();
        // 텍스트를 표시할지 판단하는 메서드
        backLobbyUI.OnOffBackLobbyText();
    }
    #endregion

    // 플레이어 상태 UI 표시 메서드
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

    // 플레이어 코스트 UI 표시 메서드
    #region Vislble Cost UI
    private void CostTextUI()
    {
        costUI.costTexts[0].text = "돌 : " + ItemManager.Instance.StoneCount.ToString("00") + "개";
        costUI.costTexts[1].text = "철 : " + ItemManager.Instance.IronCount.ToString("00") + "개";
        costUI.costTexts[2].text = "목재 : " + ItemManager.Instance.WoodCount.ToString("00") + "개";
    }
    #endregion

    // 인벤토리 UI 새로고침 아이템매니저에서 호출
    #region Inventory Update Method
    public void AddInventoryUI(int idx, GameObject item)
    {
        InventoryUI inventoryUI = GetComponentInChildren<InventoryUI>();

        // 건설 모드시엔 inventoryUI 비활성화 상태임 그래서 모든 오브젝트에서 검색하는 로직 추가
        if (inventoryUI == null)
        {
            InventoryUI[] allComponents = Resources.FindObjectsOfTypeAll<InventoryUI>();

            foreach (InventoryUI component in allComponents)
            {
                // 오브젝트가 비활성화된 상태인지 확인합니다.
                if (!component.gameObject.activeInHierarchy)
                {
                    //Debug.Log("비활성화된 오브젝트의 컴포넌트를 찾았습니다: " + component.gameObject.name);

                    // 컴포넌트에서 함수를 호출합니다.
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