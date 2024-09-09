using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenUI : MonoBehaviour
{
    // 버튼을 담을 변수 생성
    Button screenButton = null;
    // 텍스트 담을 변수 생성
    Text selectPlanetText = null;
    // 플레이어를 찾을 범위
    float findRange = 5f;
    // 플레이어 레이어 마스크
    int playerLayerMask = 1 << 6;
    // 플레이어를 찾았는지 판단할 bool 변수
    bool isFind = false;

    private void Awake()
    {
        // 버튼 가져오기
        screenButton = GetComponentInChildren<Button>();
        // 텍스트 가져오기
        selectPlanetText = GetComponentInChildren<Text>();
        selectPlanetText.gameObject.SetActive(false);

        // 버튼에 행성 선택 씬으로 이동하는 메서드 매핑
        screenButton.onClick.AddListener(GoSelectPlanetScene);
    }

    private void Update()
    {
        FindPlayerToScreen();
    }

    // 플레이어가 스크린 근처인지 찾는 메서드
    private void FindPlayerToScreen()
    {
        Collider[] _colliders = Physics.OverlapSphere(this.transform.position, findRange, playerLayerMask);

        if (_colliders.Length >= 1) 
        {
            isFind = true;
            GoSelectPlanetScene();
        }
        else
        {
            isFind = false;
        }

        selectPlanetText.gameObject.SetActive(isFind);
    }

    // E를 눌렀을 때 행성 선택 씬으로 이동하는 메서드
    private void GoSelectPlanetScene()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            SceneManager.LoadScene("PlanetSelectScene");
        }
    }
}