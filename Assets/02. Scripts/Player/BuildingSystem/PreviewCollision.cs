using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewCollision : MonoBehaviour
{
    int groundLayer;
    int defaultLayer;
    int buildObjLayer;

    int previewEnableLayer;
    int previewUnenableLayer;

    public bool prewviewEnable = true;

    private void Start()
    {
        groundLayer = LayerMask.NameToLayer("GROUND");
        defaultLayer = LayerMask.NameToLayer("Default");
        buildObjLayer = LayerMask.NameToLayer("BUILDOBJ");

        previewEnableLayer = 1 << groundLayer | 1 << defaultLayer;
        previewUnenableLayer = ~previewEnableLayer;
    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other == null)
    //    {
    //        prewviewEnable = true;
    //        return;
    //    }

    //    else
    //    {
    //        //Debug.Log(other);
    //    }

    //    if ((previewEnableLayer & (1 << other.gameObject.layer)) != 0)
    //    {
    //        prewviewEnable = true;
    //    }
    //    else if ((previewUnenableLayer & (1 << other.gameObject.layer)) != 0)
    //    {
    //        prewviewEnable = false;
    //    }
    //}


    private void OnTriggerExit(Collider other)
    {
        if (!other)
        {
            prewviewEnable = true;
            return;
        }

        else
        {
            //Debug.Log(other);
        }

        if ((1 << buildObjLayer & (1 << other.gameObject.layer)) != 0)
        {
            prewviewEnable = true;
        }
        else if ((1 << buildObjLayer & (1 << other.gameObject.layer)) != 0)
        {
            prewviewEnable = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other)
        {
            prewviewEnable = true;
            return;
        }

        else
        {
            //Debug.Log(other);
        }

        if ((previewEnableLayer & (1 << other.gameObject.layer)) != 0)
        {
            prewviewEnable = true;
        }
        else if ((previewUnenableLayer & (1 << other.gameObject.layer)) != 0)
        {
            prewviewEnable = false;
        }
    }
}
