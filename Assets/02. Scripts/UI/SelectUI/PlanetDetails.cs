using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetDetails : MonoBehaviour
{
    // ��ư�� ���� ���� ����
    [HideInInspector]
    public Button[] DetailsButtons = null;

    public void DetailsButtonInit()
    {
        DetailsButtons = GetComponentsInChildren<Button>();
    }
}