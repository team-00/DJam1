using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AlienDoor : MonoBehaviour, IClickable
{
	[SerializeField] private Image blackCoverImage;
	[SerializeField] private GameObject endScreen;
	private AudioSource audioSource;
	private List<Key> currentKeys;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		currentKeys = new List<Key>();
	}

	public void OnClick(CharController player)
	{

	}

	public void AddKey(Key keyToAdd)
	{
		currentKeys.Add(keyToAdd);
		keyToAdd.PlayKeySound();

		if (currentKeys.Count >= 4) StartCoroutine(EndGame());
	}

	private IEnumerator EndGame()
	{
		var player = GameManager.Instance.Player;
		player.transform.rotation = Quaternion.LookRotation(player.StartCampfire.position);
		player.TriggerDeath();

		while (!player.fullyDead) { yield return null; }
		yield return new WaitForSeconds(1f);

		audioSource.Play();
		StartCoroutine(Darken());
		yield return new WaitForSeconds(.5f);
		blackCoverImage.color = Color.black;
		endScreen.SetActive(true);
	}

	private IEnumerator Darken()
	{
		while(blackCoverImage.color.a < 1f)
		{
			blackCoverImage.color += new Color(0f, 0f, 0f, 1.5f * Time.deltaTime);
			yield return null;
		}
	}
}
