using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildUI : MonoBehaviour
{
    // 자식 UI 가져오기
    [HideInInspector]
    public Text[] texts;
    [HideInInspector]
    public Button[] buttons;

    [HideInInspector]
    public bool isBuild = false;

    [HideInInspector]
    public BuildInventoryGroup buildInvenGroup = null;

    [HideInInspector]
    public BuildCostUI buildCostUI = null;
    [HideInInspector]
    public Text buildCostUIText = null;

    public void BuildUIInit()
    {
        texts = GetComponentsInChildren<Text>();
        texts[3].gameObject.SetActive(false);
        texts[5].gameObject.SetActive(false);
        buttons = GetComponentsInChildren<Button>();
        buttons[1].gameObject.SetActive(false);
        buttons[2].gameObject.SetActive(false);

        buildCostUI = GetComponentInChildren<BuildCostUI>();
        buildCostUIText = buildCostUI.GetComponent<Text>();
        buildCostUI.gameObject.SetActive(false);

        buildInvenGroup = GetComponentInChildren<BuildInventoryGroup>();
        buildInvenGroup.BuildInventoryGroupInit();
        buildInvenGroup.gameObject.SetActive(false);
    }
}