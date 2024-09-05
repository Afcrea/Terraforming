using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IBuild
{
    public struct cost{

    }

    public bool BuildEnable()
    {
        if (ItemManager.Instance.StoneCount >= 10 && ItemManager.Instance.IronCount >= 10)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Demolish()
    {
        ItemManager.Instance.StoneCount += 10;
        ItemManager.Instance.IronCount += 10;

        Destroy(this.gameObject);
    }

    public void BuildCost()
    {
        ItemManager.Instance.StoneCount -= 10;
        ItemManager.Instance.IronCount -= 10;
    }
}
