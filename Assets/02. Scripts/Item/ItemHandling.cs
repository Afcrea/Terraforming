using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandling : MonoBehaviour
{
    Selector selector;
    Building building;

    int axeIndex = 1;
    int pickaxeIndex = 2;

    GameObject axeObject;
    GameObject pickaxeObject;

    bool _isbuilding;

    // Start is called before the first frame update
    void Start()
    {
        selector = FindObjectOfType<Selector>();

        building = FindObjectOfType<Building>();

        Transform[] childColliders = GetComponentsInChildren<Transform>();

        print(childColliders.Length);

        axeObject = childColliders[axeIndex].gameObject;
        pickaxeObject = childColliders[pickaxeIndex].gameObject;

        ItemManager.Instance.AddItemList(ItemManager.Instance.handPrefab);
        ItemManager.Instance.AddItemList(axeObject);
        ItemManager.Instance.AddItemList(pickaxeObject);

        //axeObject.transform.position = new Vector3(0.00300361f, -0.038646f, -0.055682f);
        //axeObject.transform.rotation = Quaternion.Euler(-32.153f, 95.295f, 116.526f);
        //pickaxeObject.transform.position = new Vector3(0.102f, -0.183f, 0.283f);
        //pickaxeObject.transform.rotation = Quaternion.Euler(-32.153f, 95.295f, 116.526f);

        axeObject.SetActive(false);
        pickaxeObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(building.isBuilding)
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
