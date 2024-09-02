using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    private ItemManager itemManager;

    GameObject seedPrefabs = null;
    GameObject seedlingPrefabs = null;

    List<Tuple<GameObject, int>> hasItem;



    private void Awake()
    {
        itemManager = FindObjectOfType<ItemManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        seedPrefabs = Resources.Load<GameObject>("Prefabs/Seed");
        seedlingPrefabs = Resources.Load<GameObject>("Prefabs/Seedling");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Checkitem1()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
        }
    }

    void OnUseItem()
    {
        Debug.Log("Left button clicked");


    }

    public void currItem()
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        IItem item = other.GetComponent<IItem>();

        if (item != null)
        {
            item.GetItem();
        }
    }
}

