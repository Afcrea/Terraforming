using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ESCUI : MonoBehaviour
{
    // 버튼 가져오기
    Button[] buttons;
    Button continueGameButton = null;
    Button newGameButton = null;
    Button quitGameButton = null;

    // 슬라이더 가져오기
    Slider volumeSlider = null;

    // UI Manager 가져오기
    UIManager uiManager = null;

    private void Awake()
    {
        buttons = GetComponentsInChildren<Button>();
        continueGameButton = buttons[0];
        newGameButton = buttons[1];
        quitGameButton = buttons[2];

        volumeSlider = GetComponentInChildren<Slider>();

        uiManager = GetComponentInParent<UIManager>();
    }

    private void Start()
    {
        // 버튼에 이벤트 매핑
        continueGameButton.onClick.AddListener(ContinueGame);
        newGameButton.onClick.AddListener(NewGame);
        quitGameButton.onClick.AddListener(QuitGame);
    }

    // 게임 계속하기
    private void ContinueGame()
    {
        // 게임 실행
        uiManager.isPaused = false;
        Time.timeScale = 1.0f;
        // esc창 비활성화
        uiManager.isEsc = false;
    }

    // 새 게임 불러오기
    private void NewGame()
    {
        // 데이터 초기화

        // 게임 실행
        Time.timeScale = 1.0f;
        uiManager.isPaused = false;
        uiManager.isEsc = false;
        // 로비 씬으로 이동
        SceneManager.LoadScene(0);
    }

    // 게임 종료
    private void QuitGame()
    {
        // 게임 종료
        Application.Quit();
        Debug.Log("Quit Game");
    }

    // 소리 조절
    private void VolumeControl()
    {
        // 음량 조절 로직
    }
}