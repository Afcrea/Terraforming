using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class UIManager : MonoBehaviour
    {
        // UI�� ��������
        [HideInInspector]
        public PlanetStateUI planetStateUI = null;
        [HideInInspector]
        public PlayerStateUI playerStateUI = null;
        [HideInInspector]
        public CostUI costUI = null;
        ESCUI escUI = null;
        InventoryUI inventoryUI = null;
        BuildUI buildUI = null;

        // esc ��ư �������� Ȯ��
        [HideInInspector]
        public bool isEsc = false;
        // ������ �����ߴ��� Ȯ��
        [HideInInspector]
        public bool isPaused = false;

        // PlanetManager ��������
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

            // esc â�� �⺻���� �����ְ� �ϱ�
            escUI.gameObject.SetActive(false);
        }

        private void Update()
        {
            // UI Update �޼��� ����
            PlanetStateUIUpdate();
            // Esc �޼��� ����
            Esc();
            // SelectInven �޼��� ����
            SelectInven();
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
        #region SelectInven
        private void SelectInven()
        {
            if (!buildUI.isBuild) // �Ǽ� ���°� �ƴ� ��
            {
                if (Input.GetKeyDown(KeyCode.Alpha1)) // ���� Ű 1 �Է� ��
                {
                    inventoryUI.selectInven.transform.SetParent(inventoryUI.inventorys[0].transform);
                    inventoryUI.rect.position = inventoryUI.inventorys[0].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2)) // ���� Ű 2 �Է� ��
                {
                    inventoryUI.selectInven.transform.SetParent(inventoryUI.inventorys[1].transform);
                    inventoryUI.rect.position = inventoryUI.inventorys[1].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3)) // ���� Ű 3 �Է� ��
                {
                    inventoryUI.selectInven.transform.SetParent(inventoryUI.inventorys[2].transform);
                    inventoryUI.rect.position = inventoryUI.inventorys[2].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha4)) // ���� Ű 4 �Է� ��
                {
                    inventoryUI.selectInven.transform.SetParent(inventoryUI.inventorys[3].transform);
                    inventoryUI.rect.position = inventoryUI.inventorys[3].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha5)) // ���� Ű 5 �Է� ��
                {
                    inventoryUI.selectInven.transform.SetParent(inventoryUI.inventorys[4].transform);
                    inventoryUI.rect.position = inventoryUI.inventorys[4].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha6)) // ���� Ű 6 �Է� ��
                {
                    inventoryUI.selectInven.transform.SetParent(inventoryUI.inventorys[5].transform);
                    inventoryUI.rect.position = inventoryUI.inventorys[5].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha7)) // ���� Ű 7 �Է� ��
                {
                    inventoryUI.selectInven.transform.SetParent(inventoryUI.inventorys[6].transform);
                    inventoryUI.rect.position = inventoryUI.inventorys[6].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha8)) // ���� Ű 8 �Է� ��
                {
                    inventoryUI.selectInven.transform.SetParent(inventoryUI.inventorys[7].transform);
                    inventoryUI.rect.position = inventoryUI.inventorys[7].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha9)) // ���� Ű 9 �Է� ��
                {
                    inventoryUI.selectInven.transform.SetParent(inventoryUI.inventorys[8].transform);
                    inventoryUI.rect.position = inventoryUI.inventorys[8].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha0)) // ���� Ű 0 �Է� ��
                {
                    inventoryUI.selectInven.transform.SetParent(inventoryUI.inventorys[9].transform);
                    inventoryUI.rect.position = inventoryUI.inventorys[9].transform.position;
                }
            }
            else // �Ǽ� ���� �϶�
            {
                if (Input.GetKeyDown(KeyCode.Alpha1)) // ���� Ű 1 �Է� ��
                {
                    buildUI.buildInvenGroup.selectBuildInven.transform.SetParent(buildUI.buildInvenGroup.buildInvens[0].transform);
                    buildUI.buildInvenGroup.rect.position = buildUI.buildInvenGroup.buildInvens[0].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2)) // ���� Ű 2 �Է� ��
                {
                    buildUI.buildInvenGroup.selectBuildInven.transform.SetParent(buildUI.buildInvenGroup.buildInvens[1].transform);
                    buildUI.buildInvenGroup.rect.position = buildUI.buildInvenGroup.buildInvens[1].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3)) // ���� Ű 3 �Է� ��
                {
                    buildUI.buildInvenGroup.selectBuildInven.transform.SetParent(buildUI.buildInvenGroup.buildInvens[2].transform);
                    buildUI.buildInvenGroup.rect.position = buildUI.buildInvenGroup.buildInvens[2].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha4)) // ���� Ű 4 �Է� ��
                {
                    buildUI.buildInvenGroup.selectBuildInven.transform.SetParent(buildUI.buildInvenGroup.buildInvens[3].transform);
                    buildUI.buildInvenGroup.rect.position = buildUI.buildInvenGroup.buildInvens[3].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha5)) // ���� Ű 5 �Է� ��
                {
                    buildUI.buildInvenGroup.selectBuildInven.transform.SetParent(buildUI.buildInvenGroup.buildInvens[4].transform);
                    buildUI.buildInvenGroup.rect.position = buildUI.buildInvenGroup.buildInvens[4].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha6)) // ���� Ű 6 �Է� ��
                {
                    buildUI.buildInvenGroup.selectBuildInven.transform.SetParent(buildUI.buildInvenGroup.buildInvens[5].transform);
                    buildUI.buildInvenGroup.rect.position = buildUI.buildInvenGroup.buildInvens[5].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha7)) // ���� Ű 7 �Է� ��
                {
                    buildUI.buildInvenGroup.selectBuildInven.transform.SetParent(buildUI.buildInvenGroup.buildInvens[6].transform);
                    buildUI.buildInvenGroup.rect.position = buildUI.buildInvenGroup.buildInvens[6].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha8)) // ���� Ű 8 �Է� ��
                {
                    buildUI.buildInvenGroup.selectBuildInven.transform.SetParent(buildUI.buildInvenGroup.buildInvens[7].transform);
                    buildUI.buildInvenGroup.rect.position = buildUI.buildInvenGroup.buildInvens[7].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha9)) // ���� Ű 9 �Է� ��
                {
                    buildUI.buildInvenGroup.selectBuildInven.transform.SetParent(buildUI.buildInvenGroup.buildInvens[8].transform);
                    buildUI.buildInvenGroup.rect.position = buildUI.buildInvenGroup.buildInvens[8].transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha0)) // ���� Ű 0 �Է� ��
                {
                    buildUI.buildInvenGroup.selectBuildInven.transform.SetParent(buildUI.buildInvenGroup.buildInvens[9].transform);
                    buildUI.buildInvenGroup.rect.position = buildUI.buildInvenGroup.buildInvens[9].transform.position;
                }
            }
        }
        #endregion

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
