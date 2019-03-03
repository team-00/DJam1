using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepPlayer : MonoBehaviour
{
	[SerializeField] private GameObject footstepPrefab;
	[SerializeField] private Transform[] footPositions;

	private AudioSource audioSource;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void TriggerFootstep(int footID)
	{
		Instantiate(footstepPrefab, footPositions[footID].position, Quaternion.identity);
	}
}
