using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienDoor : MonoBehaviour, IClickable
{
	public void OnClick(CharController player)
	{
		Debug.Log("Clicked Alien Door");
	}

	public void AddKey(Key keyToAdd)
	{

	}
}
