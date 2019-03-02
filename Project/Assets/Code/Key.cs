using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IClickable
{
	public enum KeyType { Plus, Minus, Square, Circle }
	public KeyType OwnKeyType;

	public void OnClick(CharController player)
	{
		if (player.CurrentlyCarriedKey == null)
		{
			player.CurrentlyCarriedKey = this;
			transform.parent = player.KeyCarryTransform;
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
		}
		else
		{
			player.CurrentlyCarriedKey = null;
			transform.parent = null;
			transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
			transform.localRotation = Quaternion.identity;
		}
	}
}
