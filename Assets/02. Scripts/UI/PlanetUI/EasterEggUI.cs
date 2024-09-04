using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasterEggUI : MonoBehaviour
{
    Button[] buttons;

    // 이스터에그 UI init 메서드
    public void EasterEggUIInit()
    {
        buttons = GetComponentsInChildren<Button>();

        buttons[0].onClick.AddListener(NewGame);
        buttons[1].onClick.AddListener(QuitGame);
    }

    // 새 게임 눌렀을 때 실행될 메서드
    private void NewGame()
    {
        Debug.Log("New Game");
    }

    // 게임 종료 버튼 눌렀을 때 실행될 메서드
    private void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}