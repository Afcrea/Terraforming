using UnityEngine;
using UnityEngine.InputSystem;

public class Selector : MonoBehaviour
{
    public InputActionAsset inputActions;

    private InputAction selectItemAction;

    private int _selectedIndex;

    public int selectedIndex
    {
        get { return _selectedIndex; }
    }

    UIManager uiManager = null;

    private void Awake()
    {
        uiManager = GameObject.FindGameObjectWithTag("UIMANAGER").GetComponent<UIManager>();
    }

    void OnEnable()
    {
        // Action Map과 Action을 가져오기
        var actionMap = inputActions.FindActionMap("Choose");
        selectItemAction = actionMap.FindAction("SelectItem");

        // 각 키에 대해 콜백 등록
        selectItemAction.performed += OnSelectItem;

        // Action 활성화
        selectItemAction.Enable();
    }

    void OnDisable()
    {
        // Action 비활성화 및 콜백 해제
        selectItemAction.Disable();
        selectItemAction.performed -= OnSelectItem;
    }

    private void OnSelectItem(InputAction.CallbackContext context)
    {
        // 입력된 키에 따른 인덱스 값 처리
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
        // 인덱스에 따라 아이템 선택 처리
        _selectedIndex = index;

        uiManager.SelectInventory(index);
    }
}
