using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    internal float RotationSpeed = 20f;

    void Update()
    {
        transform.Rotate(0, Time.deltaTime * RotationSpeed, 0);    
    }
}
