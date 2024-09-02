using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    void GetItem();
    void ItemUse();

    Sprite GetSprite();
}
