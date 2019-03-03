using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCam : MonoBehaviour
{
	private AudioSource audioSource;
	[SerializeField] private AudioClip[] musicAmbiences;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void OnEnable()
	{
		//audioSource.PlayOneShot();
		audioSource.clip = musicAmbiences[Random.Range(0, musicAmbiences.Length)];
		audioSource.Play();
	}
}
