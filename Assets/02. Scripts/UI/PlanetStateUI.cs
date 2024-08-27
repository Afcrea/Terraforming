using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetStateUI : MonoBehaviour
{
    // �༺ �µ� UI ��������
    [HideInInspector]
    public Text temperatureText = null;

    private void Awake()
    {
        temperatureText = GetComponentInChildren<Text>();
    }
}