using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour, IItem
{
    public Sprite inventoryImageSource;

    GameObject prefab;

    public void GetItem()
    {
        // �⺻ ����
    }

    public Sprite GetSprite()
    {
        return inventoryImageSource;
    }

    public void UseItem(int i)
    {
        // ������
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
