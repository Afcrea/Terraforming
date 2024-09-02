using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateUI : MonoBehaviour
{
    // 플레이어 스탯 스크립트 가져오기
    HpBar hpBar = null;
    FullBar fullBar = null;
    WaterBar waterBar = null;
    OxygenBar oxygenBar = null;

    // hpBar Image 가져오기
    [HideInInspector]
    public Image hpBarImage = null;
    // fullBar Image 가져오기
    [HideInInspector]
    public Image fullBarImage = null;
    // waterBar Image 가져오기
    [HideInInspector]
    public Image waterBarImage = null;
    // oxygenBar Image 가져오기
    [HideInInspector]
    public Image oxygenBarImage = null;

    // 플레이어 full 텍스트 가져오기
    private FullText fullTextObj = null;
    [HideInInspector]
    public Text fullText = null;
    // 플레이어 water 텍스트 가져오기
    private WaterText waterTextObj = null;
    [HideInInspector]
    public Text waterText = null;
    // 플레이어 oxygen 텍스트 가져오기
    private OxygenText oxygenTextObj = null;
    [HideInInspector]
    public Text oxygenText = null;

    public void PlanyerStateUIInit()
    {
        hpBar = GetComponentInChildren<HpBar>();
        fullBar = GetComponentInChildren<FullBar>();
        waterBar = GetComponentInChildren<WaterBar>();
        oxygenBar = GetComponentInChildren<OxygenBar>();

        hpBarImage = hpBar.GetComponent<Image>();
        fullBarImage = fullBar.GetComponent<Image>();
        waterBarImage = waterBar.GetComponent<Image>();
        oxygenBarImage = oxygenBar.GetComponent<Image>();

        fullTextObj = GetComponentInChildren<FullText>();
        waterTextObj = GetComponentInChildren<WaterText>();
        oxygenTextObj = GetComponentInChildren<OxygenText>();

        fullText = fullTextObj.GetComponent<Text>();
        waterText = waterTextObj.GetComponent<Text>();
        oxygenText = oxygenTextObj.GetComponent<Text>();
    }
}