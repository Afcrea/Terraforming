using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class UIManager : MonoBehaviour
    {
        // UI들 가져오기
        [HideInInspector]
        public PlanetStateUI planetStateUI = null;
        [HideInInspector]
        public PlayerStateUI playerStateUI = null;
        [HideInInspector]
        public CostUI costUI = null;
        ESCUI escUI = null;
        InventoryUI inventoryUI = null;
        BuildUI buildUI = null;

        // esc 버튼 눌렀는지 확인
        [HideInInspector]
        public bool isEsc = false;
        // 게임을 정지했는지 확인
        [HideInInspector]
        public bool isPaused = false;

        // PlanetManager 가져오기
        PlanetManager planetManager = null;

        private void Awake()
        {
            planetStateUI = GetComponentInChildren<PlanetStateUI>();
            playerStateUI = GetComponentInChildren<PlayerStateUI>();
            escUI = GetComponentInChildren<ESCUI>();
            costUI = GetComponentInChildren<CostUI>();
            inventoryUI = GetComponentInChildren<InventoryUI>();
            buildUI = GetComponentInChildren<BuildUI>();

            planetManager = GameObject.Find("PlanetManager").GetComponent<PlanetManager>();

            // esc 창은 기본으로 꺼져있게 하기
            escUI.gameObject.SetActive(false);
        }

        private void Update()
        {
            // UI Update 메서드 실행
            PlanetStateUIUpdate();
            // Esc 메서드 실행
            Esc();
            // SelectInven 메서드 실행
            SelectInven();
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
        #region SelectInven
        private void SelectInven()
        {
            if (!buildUI.isBuild) // 건설 상태가 아닐 때
            {
                if (Input.GetKeyDown(KeyCode.Alpha1)) // 숫자 키 1 입력 시
                {
                    inventoryUI.selectInven.transform.SetParent(inventoryUI.inventorys[0].transform);
                    inventoryUI.rect.position = inventoryUI.inventorys[0].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2)) // 숫자 키 2 입력 시
                {
                    inventoryUI.selectInven.transform.SetParent(inventoryUI.inventorys[1].transform);
                    inventoryUI.rect.position = inventoryUI.inventorys[1].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3)) // 숫자 키 3 입력 시
                {
                    inventoryUI.selectInven.transform.SetParent(inventoryUI.inventorys[2].transform);
                    inventoryUI.rect.position = inventoryUI.inventorys[2].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha4)) // 숫자 키 4 입력 시
                {
                    inventoryUI.selectInven.transform.SetParent(inventoryUI.inventorys[3].transform);
                    inventoryUI.rect.position = inventoryUI.inventorys[3].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha5)) // 숫자 키 5 입력 시
                {
                    inventoryUI.selectInven.transform.SetParent(inventoryUI.inventorys[4].transform);
                    inventoryUI.rect.position = inventoryUI.inventorys[4].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha6)) // 숫자 키 6 입력 시
                {
                    inventoryUI.selectInven.transform.SetParent(inventoryUI.inventorys[5].transform);
                    inventoryUI.rect.position = inventoryUI.inventorys[5].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha7)) // 숫자 키 7 입력 시
                {
                    inventoryUI.selectInven.transform.SetParent(inventoryUI.inventorys[6].transform);
                    inventoryUI.rect.position = inventoryUI.inventorys[6].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha8)) // 숫자 키 8 입력 시
                {
                    inventoryUI.selectInven.transform.SetParent(inventoryUI.inventorys[7].transform);
                    inventoryUI.rect.position = inventoryUI.inventorys[7].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha9)) // 숫자 키 9 입력 시
                {
                    inventoryUI.selectInven.transform.SetParent(inventoryUI.inventorys[8].transform);
                    inventoryUI.rect.position = inventoryUI.inventorys[8].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha0)) // 숫자 키 0 입력 시
                {
                    inventoryUI.selectInven.transform.SetParent(inventoryUI.inventorys[9].transform);
                    inventoryUI.rect.position = inventoryUI.inventorys[9].transform.position;
                }
            }
            else // 건설 상태 일때
            {
                if (Input.GetKeyDown(KeyCode.Alpha1)) // 숫자 키 1 입력 시
                {
                    buildUI.buildInvenGroup.selectBuildInven.transform.SetParent(buildUI.buildInvenGroup.buildInvens[0].transform);
                    buildUI.buildInvenGroup.rect.position = buildUI.buildInvenGroup.buildInvens[0].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2)) // 숫자 키 2 입력 시
                {
                    buildUI.buildInvenGroup.selectBuildInven.transform.SetParent(buildUI.buildInvenGroup.buildInvens[1].transform);
                    buildUI.buildInvenGroup.rect.position = buildUI.buildInvenGroup.buildInvens[1].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3)) // 숫자 키 3 입력 시
                {
                    buildUI.buildInvenGroup.selectBuildInven.transform.SetParent(buildUI.buildInvenGroup.buildInvens[2].transform);
                    buildUI.buildInvenGroup.rect.position = buildUI.buildInvenGroup.buildInvens[2].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha4)) // 숫자 키 4 입력 시
                {
                    buildUI.buildInvenGroup.selectBuildInven.transform.SetParent(buildUI.buildInvenGroup.buildInvens[3].transform);
                    buildUI.buildInvenGroup.rect.position = buildUI.buildInvenGroup.buildInvens[3].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha5)) // 숫자 키 5 입력 시
                {
                    buildUI.buildInvenGroup.selectBuildInven.transform.SetParent(buildUI.buildInvenGroup.buildInvens[4].transform);
                    buildUI.buildInvenGroup.rect.position = buildUI.buildInvenGroup.buildInvens[4].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha6)) // 숫자 키 6 입력 시
                {
                    buildUI.buildInvenGroup.selectBuildInven.transform.SetParent(buildUI.buildInvenGroup.buildInvens[5].transform);
                    buildUI.buildInvenGroup.rect.position = buildUI.buildInvenGroup.buildInvens[5].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha7)) // 숫자 키 7 입력 시
                {
                    buildUI.buildInvenGroup.selectBuildInven.transform.SetParent(buildUI.buildInvenGroup.buildInvens[6].transform);
                    buildUI.buildInvenGroup.rect.position = buildUI.buildInvenGroup.buildInvens[6].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha8)) // 숫자 키 8 입력 시
                {
                    buildUI.buildInvenGroup.selectBuildInven.transform.SetParent(buildUI.buildInvenGroup.buildInvens[7].transform);
                    buildUI.buildInvenGroup.rect.position = buildUI.buildInvenGroup.buildInvens[7].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha9)) // 숫자 키 9 입력 시
                {
                    buildUI.buildInvenGroup.selectBuildInven.transform.SetParent(buildUI.buildInvenGroup.buildInvens[8].transform);
                    buildUI.buildInvenGroup.rect.position = buildUI.buildInvenGroup.buildInvens[8].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha0)) // 숫자 키 0 입력 시
                {
                    buildUI.buildInvenGroup.selectBuildInven.transform.SetParent(buildUI.buildInvenGroup.buildInvens[9].transform);
                    buildUI.buildInvenGroup.rect.position = buildUI.buildInvenGroup.buildInvens[9].transform.position;
                }
            }
        }
        #endregion

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
