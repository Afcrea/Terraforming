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

    private void Awake()
    {
        texts = GetComponentsInChildren<Text>();
        texts[3].gameObject.SetActive(false);
        buttons = GetComponentsInChildren<Button>();
        buttons[1].gameObject.SetActive(false);

        buildInvenGroup = GetComponentInChildren<BuildInventoryGroup>();
        buildInvenGroup.gameObject.SetActive(false);
    }
}