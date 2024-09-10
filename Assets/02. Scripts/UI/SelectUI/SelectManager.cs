using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    // 선택한 행성 번호 담을 변수 선언 및 초기화
    int selectPlanetNum = 0;

    // UI Panel 담을 변수
    SelectPlanetUI selectPlanetUI;
    PlanetDetailsUI planetDetailsUI;

    // RotatePlanet으로 planet 가져오기
    RotatePlanet[] planets;

    private void Awake()
    {
        SelectManagerUIInit();

        OffUI();

        // 마우스 커서 Lock 해제
        Cursor.lockState = CursorLockMode.None;
    }

    private void SelectManagerUIInit()
    {
        // UI 가져오기
        selectPlanetUI = GetComponentInChildren<SelectPlanetUI>();
        planetDetailsUI = GetComponentInChildren<PlanetDetailsUI>();
        // Init 해주기
        selectPlanetUI.SelectPlanetUIInit();
        planetDetailsUI.PlanetDetailsUIInit();

        // 버튼에 이벤트 매핑
        // 행성 선택 후 행성 상세 정보 창 여는 메서드 매핑
        selectPlanetUI.selectPlantButtons[0].onClick.AddListener(() => SelectPlanet(0));
        selectPlanetUI.selectPlantButtons[1].onClick.AddListener(() => SelectPlanet(1));
        selectPlanetUI.selectPlantButtons[2].onClick.AddListener(() => SelectPlanet(2));
        // 행성 선택 창에서 로비 씬으로 돌아가는 메서드 매핑
        selectPlanetUI.selectPlantButtons[3].onClick.AddListener(BackLobbySceneButton);

        // 각각의 행성 정보 창을 가져와서
        for (int i = 0; i < planetDetailsUI.planetDetails.Length; i++) 
        {
            // 행성으로 이동 버튼 매핑
            planetDetailsUI.planetDetails[i].DetailsButtons[0].onClick.AddListener(StartPlanetButton);
            // 행성 정보창 없애는 버튼 매핑
            planetDetailsUI.planetDetails[i].DetailsButtons[1].onClick.AddListener(BackDetailsButton);
        }

        // 행성 가져오기
        planets = GetComponentsInChildren<RotatePlanet>();
    }

    // 처음에 보여주면 안되는 UI 끄기
    private void OffUI()
    {
        // 행성 정보창 꺼두기
        planetDetailsUI.gameObject.SetActive(false);

        // 행성 오브젝트 모두 꺼두기
        foreach (var planet in planets) 
        {
            planet.gameObject.SetActive(false);
        }
    }

    // 행성을 선택했을 때 행성 정보를 보여주는 메서드(선택 번호를 인자로 사용)
    private int SelectPlanet(int _selectNumber)
    {
        // 행성 선택하는 화면 꺼두기
        selectPlanetUI.gameObject.SetActive(false);
        // 행성 정보 창 켜두기
        planetDetailsUI.gameObject.SetActive(true);
        // 우선 행성 정보 창 모두 꺼두기
        foreach (var planetDetails in planetDetailsUI.planetDetails)
        {
            planetDetails.gameObject.SetActive(false);
        }
        // 선택한 행성의 오브젝트만 켜기
        planets[_selectNumber].gameObject.SetActive(true);
        // 선택한 행성의 정보 창만 켜기
        planetDetailsUI.planetDetails[_selectNumber].gameObject.SetActive(true);

        // 선택한 행성의 번호를 리턴
        return selectPlanetNum = _selectNumber;
    }

    // 행성으로 이동하는 버튼 메서드
    private void StartPlanetButton()
    {
        SceneManager.LoadScene("PlanetScene" + (selectPlanetNum + 1));
    }

    // 행성 정보 창에서 행선 선택 부분으로 돌아가는 메서드
    private void BackDetailsButton()
    {
        // 행성 오브젝트 끄기
        planets[selectPlanetNum].gameObject.SetActive(false);

        // 행성 정보 창 끄기
        planetDetailsUI.gameObject.SetActive(false);
        // 행성 선택하는 화면 켜기
        selectPlanetUI.gameObject.SetActive(true);
    }   
    
    // 행성 선택창에서 로비 씬으로 돌아가는 메서드
    private void BackLobbySceneButton()
    {
        // 로비씬으로 돌아가기
        SceneManager.LoadScene("LobbyScene");

        // 플레이어 위치 정해주기 - 미구현
    }
}