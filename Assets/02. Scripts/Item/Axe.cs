using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour, IItem
{
    public Sprite inventoryImageSource;

    GameObject prefab;

    public void GetItem()
    {
        // �⺻ ����
    }

    public void UseItem(int i)
    {
        return;
    }

    public Sprite GetSprite()
    {
        return inventoryImageSource;
    }

    // Start is called before the first frame update
    void Start()
    {
        prefab = Resources.Load<GameObject>("Prefabs/Tools/Axe");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
