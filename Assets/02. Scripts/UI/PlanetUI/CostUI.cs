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
        // �ڽ�Ʈ �ؽ�Ʈ UI Init
        costTexts = GetComponentsInChildren<Text>();
        // costTexts[0] = stoneText
        // costTexts[1] = ironText
        // costTexts[2] = woodText
    }
}