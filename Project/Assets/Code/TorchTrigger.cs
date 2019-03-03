using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchTrigger : MonoBehaviour
{
    internal bool Placeable => colliderCount == 0;

    private int colliderCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        colliderCount++;
    }

    private void OnTriggerExit(Collider other)
    {
        colliderCount--;
    }
}
