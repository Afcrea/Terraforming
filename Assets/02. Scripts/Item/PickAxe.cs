using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAxe : MonoBehaviour, IItem
{
    public Sprite inventoryImageSource;

    GameObject prefab;

    public void GetItem()
    {
        // 기본 지급
    }

    public void ItemUse()
    {
        throw new System.NotImplementedException();
    }

    public Sprite GetSprite()
    {
        return inventoryImageSource;
    }

    // Start is called before the first frame update
    void Start()
    {
        prefab = Resources.Load<GameObject>("Prefabs/Tools/PickAxe");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
