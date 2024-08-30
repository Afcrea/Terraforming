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
    InventoryUI inventoryUI = null;

    // esc 버튼 눌렀는지 확인
    [HideInInspector]
    public bool isEsc = false;
    // 게임을 정지했는지 확인
    [HideInInspector]
    public bool isPaused = false;

    // PlanetManager 가져오기
    PlanetManager planetManager = null;

    // 플레이어 인풋 가져오기
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

        // esc 창은 기본으로 꺼져있게 하기
        escUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        // UI Update 메서드 실행
        PlanetStateUIUpdate();
        // Esc 메서드 실행
        Esc();
        // 인벤, 건설 창 전환 메서드 실행
        ChangeBuildMode();
    }

    // 행성 상태 UI Update 메서드
    private void PlanetStateUIUpdate()
    {
        planetStateUI.temperatureText.text = "기온 " + planetManager.temperature.ToString("F1") + " ºC";
    }

    // Esc 메서드
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

    // 인벤토리 선택 메서드
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

    // 인벤 <-> 건설 창 변경 메서드
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
}