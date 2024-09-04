using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour, IBuildable
{
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
}
