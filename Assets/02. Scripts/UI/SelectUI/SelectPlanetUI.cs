using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPlanetUI : MonoBehaviour
{
    // ��ư�� ���� ���� ����
    [HideInInspector]
    public Button[] selectPlantButtons = null;

    // Init �޼���
    public void SelectPlanetUIInit()
    {
        selectPlantButtons = GetComponentsInChildren<Button>();
    }
}