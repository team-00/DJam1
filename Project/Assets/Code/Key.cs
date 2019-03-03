using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IClickable
{
	public enum KeyType { Plus, Minus, Square, Circle }
	public KeyType OwnKeyType;

	[SerializeField] private AudioClip[] keySounds;

	private AudioSource audioSource;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void OnClick(CharController player)
	{
		if (player.CurrentlyCarriedKey == null)
		{
			PlayKeySound();
			player.CurrentlyCarriedKey = this;
			transform.parent = player.KeyCarryTransform;
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
		}
		else if(player.CurrentlyCarriedKey == this)
		{
			PlayKeySound();
			player.CurrentlyCarriedKey = null;
			transform.parent = null;
			transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
			transform.localRotation = Quaternion.identity;
		}
	}

	public void PlayKeySound()
	{
		audioSource.PlayOneShot(keySounds[Random.Range(0, keySounds.Length)]);
	}
}
