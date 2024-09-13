using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour, IItem
{
    public Sprite inventoryImageSource;

    int buildObjLayer;

    GameObject prefab;

    public void GetItem()
    {
        // 기본 지급
    }

    public Sprite GetSprite()
    {
        return inventoryImageSource;
    }

    public void UseItem(int i)
    {
        buildObjLayer = LayerMask.NameToLayer("BUILDOBJ");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitinfo, 10f, 1 << buildObjLayer))
        {
            hitinfo.transform.gameObject.GetComponent<IInteractable>()?.Interact();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        prefab = Resources.Load<GameObject>("Prefabs/Tools/Hand");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
