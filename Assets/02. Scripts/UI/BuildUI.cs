using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildUI : MonoBehaviour
{
    // �ڽ� UI ��������
    [HideInInspector]
    public Text[] texts;
    [HideInInspector]
    public Button[] buttons;

    [HideInInspector]
    public bool isBuild = false;

    [HideInInspector]
    public BuildInventoryGroup buildInvenGroup = null;

    public void BuildUIInit()
    {
        texts = GetComponentsInChildren<Text>();
        texts[3].gameObject.SetActive(false);
        buttons = GetComponentsInChildren<Button>();
        buttons[1].gameObject.SetActive(false);

        buildInvenGroup = GetComponentInChildren<BuildInventoryGroup>();
        buildInvenGroup.BuildInventoryGroupInit();
        buildInvenGroup.gameObject.SetActive(false);
    }
}