using UnityEngine;
using UnityEngine.InputSystem;

public class Selector : MonoBehaviour
{
    public InputActionAsset inputActions;

    public InputActionMap actionMap;

    private InputAction selectItemAction;
    private InputAction holdItemUse;



    private int _selectedIndex;

    public int selectedIndex
    {
        get { return _selectedIndex; }
    }

    UIManager uiManager = null;

    PlayerItem pitem;

    private void Awake()
    {
        uiManager = GameObject.FindGameObjectWithTag("UIMANAGER").GetComponent<UIManager>();
    }

    private void Start()
    {
        pitem = GetComponent<PlayerItem>();
    }

    void OnEnable()
    {
        // Action Map�� Action�� ��������
        actionMap = inputActions.FindActionMap("Choose");
        selectItemAction = actionMap.FindAction("SelectItem");

        // �� Ű�� ���� �ݹ� ���
        selectItemAction.performed += OnSelectItem;

        // Action Ȱ��ȭ
        selectItemAction.Enable();
    }

    void OnDisable()
    {
        // Action ��Ȱ��ȭ �� �ݹ� ����
        selectItemAction.Disable();
        selectItemAction.performed -= OnSelectItem;
    }

    void Ontestperformed(InputAction.CallbackContext context)
    {
        //print("performed" + context.time);
    }

    void OntestCancel(InputAction.CallbackContext context)
    {
        //print("cancel" + context.time);
    }

    void OntestStarted(InputAction.CallbackContext context)
    {
        print("started" + context.startTime);
        print("started" + context.time);
    }

    private void OnSelectItem(InputAction.CallbackContext context)
    {
        // �Էµ� Ű�� ���� �ε��� �� ó��
        var key = context.control.name;

        switch (key)
        {
            case "1":
                SelectItem(0);
                break;
            case "2":
                SelectItem(1);
                break;
            case "3":
                SelectItem(2);
                break;
            case "4":
                SelectItem(3);
                break;
            case "5":
                SelectItem(4);
                break;
            case "6":
                SelectItem(5);
                break;
            case "7":
                SelectItem(6);
                break;
            case "8":
                SelectItem(7);
                break;
            case "9":
                SelectItem(8);
                break;
            case "0":
                SelectItem(9);
                break;
            default:
                Debug.LogWarning("Unexpected key: " + key);
                break;
        }
    }

    private void SelectItem(int index)
    {
        // �ε����� ���� ������ ���� ó��
        _selectedIndex = index;

        pitem.idx = index;

        uiManager.SelectInventory(index);
    }
}
