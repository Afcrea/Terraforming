using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetDetails : MonoBehaviour
{
    // 버튼을 담을 변수 선언
    [HideInInspector]
    public Button[] DetailsButtons = null;

    public void DetailsButtonInit()
    {
        DetailsButtons = GetComponentsInChildren<Button>();
    }
}