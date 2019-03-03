using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchTrigger : MonoBehaviour
{
    internal bool Placeable => colliderCount == 0;

    private int colliderCount = 0;

	private void Update()
	{
		//Debug.Log(colliderCount);
	}

	private void OnTriggerEnter(Collider other)
    {
		Debug.Log(other.gameObject.name);
        colliderCount++;
    }

	private void OnTriggerExit(Collider other)
	{
		Debug.Log(other.gameObject.name);
		colliderCount--;
    }
}
