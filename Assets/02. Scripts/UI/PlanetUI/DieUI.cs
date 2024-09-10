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

    // Die UI Init �޼���
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
        if (resurrectionClickCnt >= 2) // ��Ȱ�ϱ⸦ 3�� ������ ��(0, 1, 2 ...)
        {
            // �̽��Ϳ��� �߻�
            this.gameObject.SetActive(false);
            easterEggUI.gameObject.SetActive(true);
        }
        else // ��Ȱ�ϱ⸦ 3�� �̸� ������ ��
        {
            // ��Ȱ ��ư ���� Ƚ�� 1����
            resurrectionClickCnt++;
            // ��Ȱ�ϱ� ��ư �������
            buttons[0].gameObject.SetActive(false);
            // 1�� ���
            yield return new WaitForSeconds(1f);
            // ��Ȱ�ϱ� ��ư �ٽ� ��Ÿ���� �ϱ�
            buttons[0].gameObject.SetActive(true);
        }
    }

    // ��Ȱ �̽��Ϳ��� �ڷ�ƾ ���� �޼���
    private void Resurrection()
    {
        StartCoroutine(EasterEggResurrection());
    }

    // �� ���� ��ư ������ �� ����� �޼���
    private void NewGame()
    {
        Debug.Log("New Game");
    }

    // ���� ���� ��ư ������ �� ����� �޼��� 
    private void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}