using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenUI : MonoBehaviour
{
    // ��ư�� ���� ���� ����
    Button screenButton = null;
    // �ؽ�Ʈ ���� ���� ����
    Text selectPlanetText = null;
    // �÷��̾ ã�� ����
    float findRange = 5f;
    // �÷��̾� ���̾� ����ũ
    int playerLayerMask = 1 << 6;
    // �÷��̾ ã�Ҵ��� �Ǵ��� bool ����
    bool isFind = false;

    private void Awake()
    {
        // ��ư ��������
        screenButton = GetComponentInChildren<Button>();
        // �ؽ�Ʈ ��������
        selectPlanetText = GetComponentInChildren<Text>();
        selectPlanetText.gameObject.SetActive(false);

        // ��ư�� �༺ ���� ������ �̵��ϴ� �޼��� ����
        screenButton.onClick.AddListener(GoSelectPlanetScene);
    }

    private void Update()
    {
        FindPlayerToScreen();
    }

    // �÷��̾ ��ũ�� ��ó���� ã�� �޼���
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

    // E�� ������ �� �༺ ���� ������ �̵��ϴ� �޼���
    private void GoSelectPlanetScene()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            SceneManager.LoadScene("PlanetSelectScene");
        }
    }
}