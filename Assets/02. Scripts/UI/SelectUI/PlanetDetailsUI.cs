using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDetailsUI : MonoBehaviour
{
    // �༺ ���� ���� ���� ����
    [HideInInspector]
    public PlanetDetails[] planetDetails = null;

    // planetdrtailsUI Init �޼���
    public void PlanetDetailsUIInit()
    {
        planetDetails = GetComponentsInChildren<PlanetDetails>();
        for (int i = 0; i < planetDetails.Length; i++)
        {
            planetDetails[i].DetailsButtonInit();
        }
    }
}