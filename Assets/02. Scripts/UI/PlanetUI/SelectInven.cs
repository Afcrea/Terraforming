using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectInven : MonoBehaviour
{
    RectTransform rect = null;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    public void SetZeroRectPosion()
    {
        rect.position = Vector3.zero;
    }
}