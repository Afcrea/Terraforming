using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // UI들 가져오기
    PlayerStateUI playerStateUI = null;
    PlanetStateUI planetStateUI = null;
    ESCUI escUI = null;
    CostUI costUI = null;
    InventoryUI inventoryUI = null;

    // esc 버튼 눌렀는지 확인
    [HideInInspector]
    public bool isEsc = false;
    // 게임을 정지했는지 확인
    [HideInInspector]
    public bool isPaused = false;

    private void Awake()
    {
        planetStateUI = GetComponentInChildren<PlanetStateUI>();
        planetStateUI = GetComponentInChildren<PlanetStateUI>();
        escUI = GetComponentInChildren<ESCUI>();
        costUI = GetComponentInChildren<CostUI>();
        inventoryUI = GetComponentInChildren<InventoryUI>();

        // esc 창은 기본으로 꺼져있게 하기
        escUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Esc 메서드 실행
        Esc();
    }

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
}