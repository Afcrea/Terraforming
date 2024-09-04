using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasterEggUI : MonoBehaviour
{
    Button[] buttons;

    // �̽��Ϳ��� UI init �޼���
    public void EasterEggUIInit()
    {
        buttons = GetComponentsInChildren<Button>();

        buttons[0].onClick.AddListener(NewGame);
        buttons[1].onClick.AddListener(QuitGame);
    }

    // �� ���� ������ �� ����� �޼���
    private void NewGame()
    {
        Debug.Log("New Game");
    }

    // ���� ���� ��ư ������ �� ����� �޼���
    private void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}