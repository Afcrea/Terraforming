using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostUI : MonoBehaviour
{
    [HideInInspector]
    public Text[] costTexts = null;

    public void CostUIInit()
    {
        // 코스트 텍스트 UI Init
        costTexts = GetComponentsInChildren<Text>();
        // costTexts[0] = stoneText
        // costTexts[1] = ironText
        // costTexts[2] = woodText
    }
}