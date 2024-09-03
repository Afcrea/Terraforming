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

    bool Axeing;
    bool AxeComplet;

    void Start()
    {
        prefab = Resources.Load<GameObject>("Prefabs/Tools/Axe");
        plantLayer = LayerMask.NameToLayer("PLANT");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Axeing + " // " + AxeComplet);
    }

    private void OnEnable()
    {
        selector = FindObjectOfType<Selector>();
        holdItemUse = selector.inputActions.FindActionMap("Choose").FindAction("test");

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

    public void GetItem()
    {
        // 기본 지급
    }

    public void UseItem(int i)
    {
        //Debug.Log("Left Mouse Clicked");
        Axeing = true;
        StartCoroutine(AxeUse());
        //attack();
    }

    void AxeStarted(InputAction.CallbackContext context)
    {
        Axeing = true;
        AxeComplet = false;
    }

    void AxePerformed(InputAction.CallbackContext context)
    {
        Axeing = false;
        AxeComplet = true;
    }

    void AxeCanceled(InputAction.CallbackContext context)
    {
        Axeing = false;
        AxeComplet = false;
    }

    IEnumerator AxeUse()
    {
        while(Axeing)
        {
            yield return null;
        }
        if (AxeComplet)
        {
            attack();
        }
    }

    public void attack()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitinfo, 50f, 1 << plantLayer))
        {
            print("123");
            hitinfo.collider.gameObject.GetComponent<IInteractable>()?.Interact();
        }
    }

    public Sprite GetSprite()
    {
        return inventoryImageSource;
    }
}
