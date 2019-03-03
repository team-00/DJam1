using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySlot : MonoBehaviour, IClickable
{
	public AlienDoor Door;
	public Transform KeyParent;
	public Key SlottedKey;

	public void OnClick(CharController player)
	{
		if (player.CurrentlyCarriedKey == null) return;

		SlottedKey = player.CurrentlyCarriedKey;
		player.CurrentlyCarriedKey = null;
		Door.AddKey(SlottedKey);
		SlottedKey.transform.parent = KeyParent;
		SlottedKey.transform.localPosition = Vector3.zero;
		SlottedKey.transform.localRotation = Quaternion.identity;

		GetComponent<BoxCollider>().enabled = false;
	}
}
