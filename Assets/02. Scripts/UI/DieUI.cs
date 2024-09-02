using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DieUI : MonoBehaviour
{
    int resurrectionClickCnt = 0;

    Button[] buttons;
    [HideInInspector]
    public EasterEggUI easterEggUI;

    // Die UI Init 메서드
    public void DieUiInit()
    {
        buttons = GetComponentsInChildren<Button>();
        easterEggUI = GameObject.Find("Panel_EasterEgg").GetComponent<EasterEggUI>();

        buttons[0].onClick.AddListener(Resurrection);
        buttons[1].onClick.AddListener(NewGame);
        buttons[2].onClick.AddListener(QuitGame);
    }

    IEnumerator EasterEggResurrection()
    {
        if (resurrectionClickCnt >= 2) // 부활하기를 3번 눌렀을 때(0, 1, 2 ...)
        {
            // 이스터에그 발생
            this.gameObject.SetActive(false);
            easterEggUI.gameObject.SetActive(true);
        }
        else // 부활하기를 3번 미만 눌렀을 때
        {
            // 부활 버튼 누른 횟수 1증가
            resurrectionClickCnt++;
            // 부활하기 버튼 사라지기
            buttons[0].gameObject.SetActive(false);
            // 1초 대기
            yield return new WaitForSeconds(1f);
            // 부활하기 버튼 다시 나타나게 하기
            buttons[0].gameObject.SetActive(true);
        }
    }

    // 부활 이스터에그 코루틴 실행 메서드
    private void Resurrection()
    {
        StartCoroutine(EasterEggResurrection());
    }

    // 새 게임 버튼 눌렀을 때 실행될 메서드
    private void NewGame()
    {
        Debug.Log("New Game");
    }

    // 게임 종료 버튼 눌렀을 때 실행될 메서드 
    private void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}