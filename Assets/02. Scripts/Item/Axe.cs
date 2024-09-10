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

    void Start()
    {
        prefab = Resources.Load<GameObject>("Prefabs/Tools/Axe");
        plantLayer = LayerMask.NameToLayer("PLANT");

    }


    private void OnEnable()
    {
        selector = FindObjectOfType<Selector>();
        holdItemUse = selector.inputActions.FindActionMap("ItemUse").FindAction("HoldingTime");

        // �� Ű�� ���� �ݹ� ���
        holdItemUse.performed += AxePerformed;
        holdItemUse.canceled += AxeCanceled;
        holdItemUse.started += AxeStarted;

        holdItemUse.Enable();
    }

    void OnDisable()
    {
        holdItemUse.Disable();

        // Action ��Ȱ��ȭ �� �ݹ� ����
        holdItemUse.performed -= AxePerformed;
        holdItemUse.canceled -= AxeCanceled;
        holdItemUse.started -= AxeStarted;
    }

    public void GetItem()
    {
        // �⺻ ����
    }

    public void UseItem(int i)
    {
        //Debug.Log("Left Mouse Clicked");
        AxeStart = true;
        StartCoroutine(AxeUse());
    }

    void AxeStarted(InputAction.CallbackContext context)
    {
        AxeStart = true;
        AxeDone = false;
    }

    void AxePerformed(InputAction.CallbackContext context)
    {
        AxeStart = false;
        AxeDone = true;
    }

    void AxeCanceled(InputAction.CallbackContext context)
    {
        AxeStart = false;
        AxeDone = false;
    }

    IEnumerator AxeUse()
    {
        while(AxeStart)
        {
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
        if (Physics.Raycast(ray, out RaycastHit hitinfo, 50f, 1 << plantLayer))
        {
            hitinfo.collider.gameObject.GetComponent<IInteractable>()?.Interact();
        }
    }

    public Sprite GetSprite()
    {
        return inventoryImageSource;
    }
}
