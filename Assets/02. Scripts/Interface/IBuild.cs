using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuild
{
    public void Demolish();
    public void BuildCost();
    bool BuildEnable();
}
