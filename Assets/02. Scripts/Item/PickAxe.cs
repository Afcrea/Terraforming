using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickAxe : MonoBehaviour, IItem
{
    public Sprite inventoryImageSource;
    public Selector selector;

    GameObject prefab;

    private InputAction holdItemUse;

    int rockLayer;

    bool pickaxeing;
    bool pickaxeComplet;

    public void GetItem()
    {
        // 기본 지급
    }

    public void UseItem(int i)
    {
        pickaxeing = true;
        StartCoroutine(PickaxeUse());
    }

    public Sprite GetSprite()
    {
        return inventoryImageSource;
    }

    // Start is called before the first frame update
    void Start()
    {
        prefab = Resources.Load<GameObject>("Prefabs/Tools/PickAxe");
        rockLayer = LayerMask.NameToLayer("ROCK");
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

    void AxeStarted(InputAction.CallbackContext context)
    {
        pickaxeing = true;
        pickaxeComplet = false;
    }

    void AxePerformed(InputAction.CallbackContext context)
    {
        pickaxeing = false;
        pickaxeComplet = true;
    }

    void AxeCanceled(InputAction.CallbackContext context)
    {
        pickaxeing = false;
        pickaxeComplet = false;
    }

    IEnumerator PickaxeUse()
    {
        while (pickaxeing)
        {
            yield return null;
        }
        if (pickaxeComplet)
        {
            attack();
        }
    }

    public void attack()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitinfo, 50f, 1 << rockLayer))
        {
            print("123");
            hitinfo.collider.gameObject.GetComponent<IInteractable>()?.Interact();
        }
    }
}
