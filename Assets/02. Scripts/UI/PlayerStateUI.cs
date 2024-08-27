using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateUI : MonoBehaviour
{
    // �̹��� ��������
    HpBar hpBar = null;
    FullBar fullBar = null;
    WaterBar waterBar = null;
    OxygenBar oxygenBar = null;

    [HideInInspector]
    public Image hpBarImage = null;
    [HideInInspector]
    public Image fullBarImage = null;
    [HideInInspector]
    public Image waterBarImage = null;
    [HideInInspector]
    public Image oxygenBarImage = null;

    private void Awake()
    {
        hpBar = GetComponentInChildren<HpBar>();
        fullBar = GetComponentInChildren<FullBar>();
        waterBar = GetComponentInChildren<WaterBar>();
        oxygenBar = GetComponentInChildren<OxygenBar>();

        hpBarImage = hpBar.GetComponent<Image>();
        fullBarImage = fullBar.GetComponent<Image>();
        waterBarImage = waterBar.GetComponent<Image>();
        oxygenBarImage = oxygenBar.GetComponent<Image>();
    }
}