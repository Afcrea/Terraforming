using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    // 버튼들 담을 변수 선언
    Button[] buttons = null;

    // 세이브 데이터가 있는지 판단할 변수 선언
    bool isSaveData = false;

    private void Awake()
    {
        CheckSaveData();

        // 버튼들 가져오기
        buttons = GetComponentsInChildren<Button>();

        // 버튼에 이벤트 매핑
        buttons[0].onClick.AddListener(ContinueGame); // Continue Game Button
        buttons[1].onClick.AddListener(NewGame);      // New Game Button
        buttons[2].onClick.AddListener(QuitGame);     // Quit Game Button

        // 마우스 커서 Lock 해제
        Cursor.lockState = CursorLockMode.None;
    }

    private void Start()
    {
        StartCoroutine(SaveDataCheckCo());
    }

    // 저장된 데이터가 있는지 확인하고 있다면 데이터 불러오는 메서드
    private void CheckSaveData()
    {
        // 저장된 데이터가 있는지 확인
        // 있다면 데이더 불러오고 isSaveData = true
        // 없다면 isSaveData = false
    }

    // 데이터 체크 및 로드할 코루틴
    IEnumerator SaveDataCheckCo()
    {
        while (true)
        {
            buttons[0].interactable = isSaveData;

            yield return null;
        }
    }

    // 
    private void ContinueGame()
    {
        // 저장된 씬으로 이동
    }

    // 새로운 게임 시작하는 메서드
    private void NewGame()
    {
        if (isSaveData) 
        {
            // 데이터 삭제 로직
            SceneManager.LoadScene("LobbyScene");
        }
        else
        {
            SceneManager.LoadScene("LobbyScene");
        }
    }

    // 게임 종료 메서드
    private void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}