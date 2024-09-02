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

    PlayerState playerState = null;

    private void Awake()
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

        // esc, die 창은 기본으로 꺼져있게 하기
        escUI.gameObject.SetActive(false);
        dieUI.gameObject.SetActive(false);
        dieUI.easterEggUI.gameObject.SetActive(false);
        planetStateUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        Esc();
        OpenPlanetState();
        ChangeBuildMode();
        VisiblePlayerStateUI();
        PlanetStateCheck();

        if (Input.GetKeyDown(KeyCode.I)) 
        {
            print(escUI.gameObject.name);
            print(dieUI.gameObject.name);
            print(dieUI.easterEggUI.gameObject.name);

        }
    }

    // Esc 메서드
    #region ESC
    private void Esc()
    {
        // Esc 버튼이 눌렸을 때
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
            // esc창 활성화
            escUI.gameObject.SetActive(true);
        }
        else // isEsc가 false면
        {
            // 게임 실행
            Time.timeScale = 1.0f;
            // esc창 비활성화
            escUI.gameObject.SetActive(false);
        }
    }
    #endregion

    // 오픈 행성 정보창 메서드
    #region OpenPlanetState
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
    #region SelectInventory
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

    // 인벤 <-> 건설 창 변경 메서드
    #region ChangeBuildMode
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
        }
    }
    #endregion

    // 행성 상태 체크 메서드
    #region PlanetStateCheck
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
        planetStateUI.planetStateTexts[4].text = "토지 정화도 : " + planetManager.landLevel + "단계(MAX 5 단계)";
    }
    #endregion

    // 플레이어 상태 UI 표시 메서드
    #region VisiblePlayerStateUI
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
}