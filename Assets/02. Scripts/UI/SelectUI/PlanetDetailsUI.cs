using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDetailsUI : MonoBehaviour
{
    // 행성 정보 담을 변수 선언
    [HideInInspector]
    public PlanetDetails[] planetDetails = null;

    // planetdrtailsUI Init 메서드
    public void PlanetDetailsUIInit()
    {
        planetDetails = GetComponentsInChildren<PlanetDetails>();
        for (int i = 0; i < planetDetails.Length; i++)
        {
            planetDetails[i].DetailsButtonInit();
        }
    }
}