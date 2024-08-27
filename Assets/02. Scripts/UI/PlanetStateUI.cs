using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetStateUI : MonoBehaviour
{
    // 행성 온도 UI 가져오기
    [HideInInspector]
    public Text temperatureText = null;

    private void Awake()
    {
        temperatureText = GetComponentInChildren<Text>();
    }
}