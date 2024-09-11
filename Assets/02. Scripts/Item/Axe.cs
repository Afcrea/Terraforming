using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Axe : MonoBehaviour, IItem
{
    public Sprite inventoryImageSource;
    public Selector selector;

    GameObject prefab;

    private InputAction holdItemUse;

    int plantLayer;

    bool AxeStart;
    bool AxeDone;

    float holdStartTime = 0f;
    float holdDuration = 2.0f;

    UIManager uiManager = null;

    public void GetItem()
    {
        // 기본 지급
    }

    public void UseItem(int i)
    {
        //Debug.Log("Left Mouse Clicked");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitinfo, 10f, 1 << plantLayer))
        {
            AxeStart = true;
            StartCoroutine(AxeUse());
        }
    }

    public Sprite GetSprite()
    {
        return inventoryImageSource;
    }

    void Start()
    {
        prefab = Resources.Load<GameObject>("Prefabs/Tools/Axe");
        plantLayer = LayerMask.NameToLayer("PLANT");
    }
    private void OnEnable()
    {
        uiManager = FindObjectOfType<UIManager>();

        selector = FindObjectOfType<Selector>();
        holdItemUse = selector.inputActions.FindActionMap("ItemUse").FindAction("HoldingTime");

        // 각 키에 대해 콜백 등록
        holdItemUse.performed += AxePerformed;
        holdItemUse.canceled += AxeCanceled;
        holdItemUse.started += AxeStarted;

        holdItemUse.Enable();
    }

    void OnDisable()
    {
        holdItemUse.Disable();

        // Action 비활성화 및 콜백 해제
        holdItemUse.performed -= AxePerformed;
        holdItemUse.canceled -= AxeCanceled;
        holdItemUse.started -= AxeStarted;
    }

    void AxeStarted(InputAction.CallbackContext context)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitinfo, 10f, 1 << plantLayer))
        {
            holdStartTime = Time.time;
            AxeStart = true;
            AxeDone = false;
        }
        
    }

    void AxePerformed(InputAction.CallbackContext context)
    {
        uiManager.pickaxeUI.gameObject.SetActive(false);
        AxeStart = false;
        AxeDone = true;
    }

    void AxeCanceled(InputAction.CallbackContext context)
    {
        uiManager.pickaxeUI.gameObject.SetActive(false);
        AxeStart = false;
        AxeDone = false;
    }

    IEnumerator AxeUse()
    {
        while(AxeStart)
        {
            uiManager.pickaxeUI.gameObject.SetActive(true);

            float holdTime = Time.time - holdStartTime;

            print(holdTime);

            uiManager.pickaxeUI.barOn.barProgress = Mathf.Clamp(holdTime / holdDuration, 0, 1);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out RaycastHit hitinfo, 10f, 1 << plantLayer))
            {
                uiManager.pickaxeUI.gameObject.SetActive(false);
                yield break;
            }
            yield return null;
        }
        if (AxeDone)
        {
            AxeUseConfirm();
        }
    }

    void AxeUseConfirm()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitinfo, 10f, 1 << plantLayer))
        {
            hitinfo.collider.gameObject.GetComponent<IInteractable>()?.Interact();
        }
    }
}
