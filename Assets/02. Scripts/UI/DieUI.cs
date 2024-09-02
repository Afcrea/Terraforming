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

    private void Awake()
    {
        buttons = GetComponentsInChildren<Button>();
        easterEggUI = GameObject.Find("Panel_EasterEgg").GetComponent<EasterEggUI>();

        buttons[0].onClick.AddListener(Resurrection);
        buttons[1].onClick.AddListener(NewGame);
        buttons[2].onClick.AddListener(QuitGame);
    }

    IEnumerator EasterEggResurrection()
    {
        if (resurrectionClickCnt >= 2)
        {
            // 이스터에그 발생
            this.gameObject.SetActive(false);
            easterEggUI.gameObject.SetActive(true);
        }
        else
        {
            resurrectionClickCnt++;
            buttons[0].gameObject.SetActive(false);

            yield return new WaitForSeconds(1f);

            buttons[0].gameObject.SetActive(true);
        }
    }

    private void Resurrection()
    {
        StartCoroutine(EasterEggResurrection());
    }

    private void NewGame()
    {
        Debug.Log("New Game");
    }

    private void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}