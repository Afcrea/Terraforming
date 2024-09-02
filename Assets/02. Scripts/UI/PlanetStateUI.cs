using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetStateUI : MonoBehaviour
{
    // �༺ ���� UI ��������
    [HideInInspector]
    public Text[] planetStateTexts = null;

    private void Awake()
    {
        planetStateTexts = GetComponentsInChildren<Text>();
    }
}