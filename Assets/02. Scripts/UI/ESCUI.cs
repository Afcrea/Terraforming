using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ESCUI : MonoBehaviour
{
    // ��ư ��������
    Button[] buttons;
    Button continueGameButton = null;
    Button newGameButton = null;
    Button quitGameButton = null;

    // �����̴� ��������
    Slider volumeSlider = null;

    // UI Manager ��������
    UIManager uiManager = null;

    public void EscUIInit()
    {
        buttons = GetComponentsInChildren<Button>();
        continueGameButton = buttons[0];
        newGameButton = buttons[1];
        quitGameButton = buttons[2];

        volumeSlider = GetComponentInChildren<Slider>();

        uiManager = GetComponentInParent<UIManager>();

        // ��ư�� �̺�Ʈ ����
        continueGameButton.onClick.AddListener(ContinueGame);
        newGameButton.onClick.AddListener(NewGame);
        quitGameButton.onClick.AddListener(QuitGame);
    }

    // ���� ����ϱ�
    private void ContinueGame()
    {
        // ���� ����
        uiManager.isPaused = false;
        uiManager.playerInput.isCameraMove = true;
        Time.timeScale = 1.0f;
        // escâ ��Ȱ��ȭ
        uiManager.isEsc = false;
    }

    // �� ���� �ҷ�����
    private void NewGame()
    {
        // ������ �ʱ�ȭ

        // ���� ����
        Time.timeScale = 1.0f;
        uiManager.isPaused = false;
        uiManager.isEsc = false;
        uiManager.playerInput.isCameraMove = true;
        // �κ� ������ �̵�
        SceneManager.LoadScene(1);
    }

    // ���� ����
    private void QuitGame()
    {
        // ���� ����
        Application.Quit();
        Debug.Log("Quit Game");
    }

    // �Ҹ� ����
    private void VolumeControl()
    {
        // ���� ���� ����
    }
}