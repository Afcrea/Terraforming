using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandling : MonoBehaviour
{
    Selector selector;
    Buliding buliding;

    int axeIndex = 1;
    int pickaxeIndex = 2;

    GameObject axeObject;
    GameObject pickaxeObject;

    bool _isbuilding;

    // Start is called before the first frame update
    void Start()
    {
        selector = FindObjectOfType<Selector>();

        buliding = FindObjectOfType<Buliding>();

        ItemManager.Instance.AddItemList(ItemManager.Instance.handPrefab);
        ItemManager.Instance.AddItemList(FindObjectOfType<Axe>().gameObject);
        ItemManager.Instance.AddItemList(ItemManager.Instance.pickaxePrefab);

        Transform[] childColliders = GetComponentsInChildren<Transform>();

        print(childColliders.Length);

        axeObject = childColliders[axeIndex].gameObject;
        pickaxeObject = childColliders[pickaxeIndex].gameObject;

        axeObject.SetActive(false);
        pickaxeObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(buliding.isBuilding)
        {
            axeObject.SetActive(false);
            pickaxeObject.SetActive(false);
            return;
        }

        if (selector.selectedIndex == axeIndex)
        {
            axeObject.SetActive(true);
        }
        else
        {
            axeObject.SetActive(false);
        }

        if (selector.selectedIndex == pickaxeIndex)
        {
            pickaxeObject.SetActive(true);
        }
        else
        {
            pickaxeObject.SetActive(false);
        }
    }
}
