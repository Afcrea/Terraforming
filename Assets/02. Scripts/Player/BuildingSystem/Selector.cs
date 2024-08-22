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


    void OnEnable()
    {
        // Action Map�� Action�� ��������
        var actionMap = inputActions.FindActionMap("Choose");
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
            case "10":
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
        //Debug.Log("Selected item at index: " + index);

        _selectedIndex = index;
    }
}
