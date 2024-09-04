using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateUI : MonoBehaviour
{
    // �÷��̾� ���� ��ũ��Ʈ ��������
    HpBar hpBar = null;
    FullBar fullBar = null;
    WaterBar waterBar = null;
    OxygenBar oxygenBar = null;

    // hpBar Image ��������
    [HideInInspector]
    public Image hpBarImage = null;
    // fullBar Image ��������
    [HideInInspector]
    public Image fullBarImage = null;
    // waterBar Image ��������
    [HideInInspector]
    public Image waterBarImage = null;
    // oxygenBar Image ��������
    [HideInInspector]
    public Image oxygenBarImage = null;

    // �÷��̾� full �ؽ�Ʈ ��������
    private FullText fullTextObj = null;
    [HideInInspector]
    public Text fullText = null;
    // �÷��̾� water �ؽ�Ʈ ��������
    private WaterText waterTextObj = null;
    [HideInInspector]
    public Text waterText = null;
    // �÷��̾� oxygen �ؽ�Ʈ ��������
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