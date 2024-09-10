using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    // ��ư�� ���� ���� ����
    Button[] buttons = null;

    // ���̺� �����Ͱ� �ִ��� �Ǵ��� ���� ����
    bool isSaveData = false;

    private void Awake()
    {
        CheckSaveData();

        // ��ư�� ��������
        buttons = GetComponentsInChildren<Button>();

        // ��ư�� �̺�Ʈ ����
        buttons[0].onClick.AddListener(ContinueGame); // Continue Game Button
        buttons[1].onClick.AddListener(NewGame);      // New Game Button
        buttons[2].onClick.AddListener(QuitGame);     // Quit Game Button

        // ���콺 Ŀ�� Lock ����
        Cursor.lockState = CursorLockMode.None;
    }

    private void Start()
    {
        StartCoroutine(SaveDataCheckCo());
    }

    // ����� �����Ͱ� �ִ��� Ȯ���ϰ� �ִٸ� ������ �ҷ����� �޼���
    private void CheckSaveData()
    {
        // ����� �����Ͱ� �ִ��� Ȯ��
        // �ִٸ� ���̴� �ҷ����� isSaveData = true
        // ���ٸ� isSaveData = false
    }

    // ������ üũ �� �ε��� �ڷ�ƾ
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
        // ����� ������ �̵�
    }

    // ���ο� ���� �����ϴ� �޼���
    private void NewGame()
    {
        if (isSaveData) 
        {
            // ������ ���� ����
            SceneManager.LoadScene("LobbyScene");
        }
        else
        {
            SceneManager.LoadScene("LobbyScene");
        }
    }

    // ���� ���� �޼���
    private void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}