using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    float rotateSpeed = 30f;

    private void Update()
    {
        transform.Rotate(new Vector3(0f, rotateSpeed, 0f) * Time.deltaTime);
    }
}