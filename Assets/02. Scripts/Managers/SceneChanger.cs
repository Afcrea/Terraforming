using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{

    string lobbySceneName = "LobbyScene";
    string selectPlanetSceneName = "PlanetSelectScene";

    GameObject selectPanel = null;
    GameObject[] detailPanel = null;
    GameObject[] planets = null;

    public bool isBackLobby = false;

    // vec = new Vector3(-28f, 0.183f, 0);

    private void Awake()
    {
        selectPanel = GameObject.FindGameObjectWithTag("SELECTPANEL");
        detailPanel = GameObject.FindGameObjectsWithTag("DETAILPANEL");
        planets = GameObject.FindGameObjectsWithTag("PLANET");
    }

    private void Start()
    {
        if (selectPanel != null)
        {
            selectPanel.SetActive(true);
            detailPanel[0].SetActive(false);
            foreach (GameObject go in planets) 
            {
                go.SetActive(false);
            }
            foreach (GameObject go in detailPanel)
            {
                go.SetActive(false);
            }
        }
    }

    // 행성 선택 씬으로 이동
    public void ChangeSelectPlanetScene()
    {
        // 행성 선택 씬 이동
        SceneManager.LoadScene(selectPlanetSceneName);
    }

    // 행성 설명 UI 켜기
    public void OnPlanetDetails(int _index)
    {
        selectPanel.SetActive(false);
        detailPanel[0].SetActive(true);
        detailPanel[1].SetActive(false);
        detailPanel[2].SetActive(false);
        detailPanel[3].SetActive(false);

        detailPanel[_index].SetActive(true);

        planets[0].SetActive(true);
        planets[1].SetActive(false);
        planets[2].SetActive(false);
        planets[3].SetActive(false);

        planets[_index].SetActive(true);
    }

    // 이전 씬으로 이동
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackLobbyScene()
    {
        SceneManager.LoadScene(lobbySceneName);
        isBackLobby = true;
    }

    // 행성(메인) 씬으로 이동
    public void StartPlanetScene(int _index)
    {
        SceneManager.LoadScene("PlanetScene" + _index);
    }

    // 로비 씬으로 돌아가기
    public void GoToLobbyScene()
    {
        SceneManager.LoadScene(lobbySceneName);
    }
}