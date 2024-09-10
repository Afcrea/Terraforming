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

    bool pickaxeStart;
    bool pickaxeDone;

    public void GetItem()
    {
        // �⺻ ����
    }

    public void UseItem(int i)
    {
        pickaxeStart = true;
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
        holdItemUse = selector.inputActions.FindActionMap("ItemUse").FindAction("HoldingTime");

        

        // �� Ű�� ���� �ݹ� ���
        holdItemUse.performed += PickAxePerformed;
        holdItemUse.canceled += PickAxeCanceled;
        holdItemUse.started += PickAxeStarted;

        holdItemUse.Enable();
    }


    void OnDisable()
    {
        holdItemUse.Disable();

        // Action ��Ȱ��ȭ �� �ݹ� ����
        holdItemUse.performed -= PickAxePerformed;
        holdItemUse.canceled -= PickAxeCanceled;
        holdItemUse.started -= PickAxeStarted;
    }

    void PickAxeStarted(InputAction.CallbackContext context)
    {
        pickaxeStart = true;
        pickaxeDone = false;
    }

    void PickAxePerformed(InputAction.CallbackContext context)
    {
        pickaxeStart = false;
        pickaxeDone = true;
    }

    void PickAxeCanceled(InputAction.CallbackContext context)
    {
        pickaxeStart = false;
        pickaxeDone = false;
    }

    IEnumerator PickaxeUse()
    {
        while (pickaxeStart)
        {
            yield return null;
        }
        if (pickaxeDone)
        {
            PickaxeUseConfirm();
        }
    }

    void PickaxeUseConfirm()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitinfo, 50f, 1 << rockLayer))
        {
            hitinfo.collider.gameObject.GetComponent<IInteractable>()?.Interact();
        }
    }
}
