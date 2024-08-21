using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory[] inventorys;

    SelectInven selectInven = null;
    RectTransform rect = null;

    void Awake()
    {
        inventorys = GetComponentsInChildren<Inventory>();
        selectInven = GetComponentInChildren<SelectInven>();
        rect = selectInven.GetComponent<RectTransform>();
    }

    void Update()
    {
        SelectInven();
    }

    private void SelectInven()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            selectInven.transform.SetParent(inventorys[0].transform);
            rect.position = inventorys[0].transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectInven.transform.SetParent(inventorys[1].transform);
            rect.position = inventorys[1].transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectInven.transform.SetParent(inventorys[2].transform);
            rect.position = inventorys[2].transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectInven.transform.SetParent(inventorys[3].transform);
            rect.position = inventorys[3].transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectInven.transform.SetParent(inventorys[4].transform);
            rect.position = inventorys[4].transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            selectInven.transform.SetParent(inventorys[5].transform);
            rect.position = inventorys[5].transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            selectInven.transform.SetParent(inventorys[6].transform);
            rect.position = inventorys[6].transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            selectInven.transform.SetParent(inventorys[7].transform);
            rect.position = inventorys[7].transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            selectInven.transform.SetParent(inventorys[8].transform);
            rect.position = inventorys[8].transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            selectInven.transform.SetParent(inventorys[9].transform);
            rect.position = inventorys[9].transform.position;
        }
    }
}