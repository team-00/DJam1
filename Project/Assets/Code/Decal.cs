using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Decal : MonoBehaviour
{
	[SerializeField] private float despawnTime;
	[SerializeField] private AudioClip[] spawnAudioClips;

    IEnumerator Start()
    {
		GetComponent<AudioSource>().PlayOneShot(spawnAudioClips[Random.Range(0, spawnAudioClips.Length)]);
		yield return new WaitForSeconds(despawnTime);
		Destroy(gameObject);
    }
}
