using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarOn : MonoBehaviour
{
    public float barProgress = 0;

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<Image>().fillAmount = barProgress;
    }
}
