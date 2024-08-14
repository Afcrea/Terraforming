using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUIManager : MonoBehaviour
{
    GameObject startPanel;
    GameObject totalDetailPanel;
    GameObject detailPanel1;
    GameObject detailPanel2;
    GameObject detailPanel3;

    private void Awake()
    {
        startPanel = GameObject.Find("Panel_Planet");
        totalDetailPanel = GameObject.Find("Panel_PlanetDetails");
        detailPanel1 = GameObject.Find("PlanetDetails1");
        detailPanel2 = GameObject.Find("PlanetDetails2");
        detailPanel3 = GameObject.Find("PlanetDetails3");
    }

    

    private void Start()
    {
        startPanel.SetActive(true);
        totalDetailPanel.SetActive(false);
        detailPanel1.SetActive(false);
        detailPanel2.SetActive(false);
        detailPanel3.SetActive(false);
    }

    public void SelectPlanet1()
    {
        startPanel.SetActive(false);
        totalDetailPanel.SetActive(true);
        detailPanel1.SetActive(true);        
    }

    public void SelectPlanet2()
    {
        startPanel.SetActive(false);
        totalDetailPanel.SetActive(true);
        detailPanel2.SetActive(true);
    }

    public void SelectPlanet3()
    {
        startPanel.SetActive(false);
        totalDetailPanel.SetActive(true);
        detailPanel3.SetActive(true);
    }

    public void OnStartButton()
    {
        print("∏ﬁ¿Œ æ¿ ¿Ãµø");
    }

    public void OnBackButton()
    {
        totalDetailPanel.SetActive(false);
        detailPanel1.SetActive(false);
        detailPanel2.SetActive(false);
        detailPanel3.SetActive(false);
        startPanel.SetActive(true);
    }
}