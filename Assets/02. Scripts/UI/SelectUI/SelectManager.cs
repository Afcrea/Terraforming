using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    // ������ �༺ ��ȣ ���� ���� ���� �� �ʱ�ȭ
    int selectPlanetNum = 0;

    // UI Panel ���� ����
    SelectPlanetUI selectPlanetUI;
    PlanetDetailsUI planetDetailsUI;

    // RotatePlanet���� planet ��������
    RotatePlanet[] planets;

    private void Awake()
    {
        SelectManagerUIInit();

        OffUI();

        // ���콺 Ŀ�� Lock ����
        Cursor.lockState = CursorLockMode.None;
    }

    private void SelectManagerUIInit()
    {
        // UI ��������
        selectPlanetUI = GetComponentInChildren<SelectPlanetUI>();
        planetDetailsUI = GetComponentInChildren<PlanetDetailsUI>();
        // Init ���ֱ�
        selectPlanetUI.SelectPlanetUIInit();
        planetDetailsUI.PlanetDetailsUIInit();

        // ��ư�� �̺�Ʈ ����
        // �༺ ���� �� �༺ �� ���� â ���� �޼��� ����
        selectPlanetUI.selectPlantButtons[0].onClick.AddListener(() => SelectPlanet(0));
        selectPlanetUI.selectPlantButtons[1].onClick.AddListener(() => SelectPlanet(1));
        selectPlanetUI.selectPlantButtons[2].onClick.AddListener(() => SelectPlanet(2));
        // �༺ ���� â���� �κ� ������ ���ư��� �޼��� ����
        selectPlanetUI.selectPlantButtons[3].onClick.AddListener(BackLobbySceneButton);

        // ������ �༺ ���� â�� �����ͼ�
        for (int i = 0; i < planetDetailsUI.planetDetails.Length; i++) 
        {
            // �༺���� �̵� ��ư ����
            planetDetailsUI.planetDetails[i].DetailsButtons[0].onClick.AddListener(StartPlanetButton);
            // �༺ ����â ���ִ� ��ư ����
            planetDetailsUI.planetDetails[i].DetailsButtons[1].onClick.AddListener(BackDetailsButton);
        }

        // �༺ ��������
        planets = GetComponentsInChildren<RotatePlanet>();
    }

    // ó���� �����ָ� �ȵǴ� UI ����
    private void OffUI()
    {
        // �༺ ����â ���α�
        planetDetailsUI.gameObject.SetActive(false);

        // �༺ ������Ʈ ��� ���α�
        foreach (var planet in planets) 
        {
            planet.gameObject.SetActive(false);
        }
    }

    // �༺�� �������� �� �༺ ������ �����ִ� �޼���(���� ��ȣ�� ���ڷ� ���)
    private int SelectPlanet(int _selectNumber)
    {
        // �༺ �����ϴ� ȭ�� ���α�
        selectPlanetUI.gameObject.SetActive(false);
        // �༺ ���� â �ѵα�
        planetDetailsUI.gameObject.SetActive(true);
        // �켱 �༺ ���� â ��� ���α�
        foreach (var planetDetails in planetDetailsUI.planetDetails)
        {
            planetDetails.gameObject.SetActive(false);
        }
        // ������ �༺�� ������Ʈ�� �ѱ�
        planets[_selectNumber].gameObject.SetActive(true);
        // ������ �༺�� ���� â�� �ѱ�
        planetDetailsUI.planetDetails[_selectNumber].gameObject.SetActive(true);

        // ������ �༺�� ��ȣ�� ����
        return selectPlanetNum = _selectNumber;
    }

    // �༺���� �̵��ϴ� ��ư �޼���
    private void StartPlanetButton()
    {
        SceneManager.LoadScene("PlanetScene" + (selectPlanetNum + 1));
    }

    // �༺ ���� â���� �༱ ���� �κ����� ���ư��� �޼���
    private void BackDetailsButton()
    {
        // �༺ ������Ʈ ����
        planets[selectPlanetNum].gameObject.SetActive(false);

        // �༺ ���� â ����
        planetDetailsUI.gameObject.SetActive(false);
        // �༺ �����ϴ� ȭ�� �ѱ�
        selectPlanetUI.gameObject.SetActive(true);
    }   
    
    // �༺ ����â���� �κ� ������ ���ư��� �޼���
    private void BackLobbySceneButton()
    {
        // �κ������ ���ư���
        SceneManager.LoadScene("LobbyScene");

        // �÷��̾� ��ġ �����ֱ� - �̱���
    }
}