using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAxeUI : MonoBehaviour
{
    public BarOn barOn;
    // Start is called before the first frame update
    private void OnEnable()
    {
        barOn = GetComponentInChildren<BarOn>();
        barOn.barProgress = 0;
    }
}
