using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAxe : MonoBehaviour, IItem
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
        prefab = Resources.Load<GameObject>("Prefabs/Tools/PickAxe");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
