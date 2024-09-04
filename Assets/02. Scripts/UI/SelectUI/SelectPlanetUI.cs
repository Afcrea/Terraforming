using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPlanetUI : MonoBehaviour
{
    // 버튼을 담을 변수 선언
    [HideInInspector]
    public Button[] selectPlantButtons = null;

    // Init 메서드
    public void SelectPlanetUIInit()
    {
        selectPlantButtons = GetComponentsInChildren<Button>();
    }
}