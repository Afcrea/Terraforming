using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetStateUI : MonoBehaviour
{
    // 행성 스탯 UI 가져오기
    [HideInInspector]
    public Text[] planetStateTexts = null;

    public void PlanetStateUIInit()
    {
        planetStateTexts = GetComponentsInChildren<Text>();
    }
}