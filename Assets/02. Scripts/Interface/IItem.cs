using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    void GetItem();
    void UseItem(int i);

    Sprite GetSprite();
}
