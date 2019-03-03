using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI woodAmount, flintAmount, berriesAmount;
    [SerializeField] private TorchPlaceMode torchPlaceMode;
	[SerializeField] private AudioClip[] craftSounds, eatSounds;

	private AudioSource audioSource;

    internal void Awake()
    {
        GameManager.Instance.Inventory.ConnectPanel(this);
		audioSource = GameManager.Instance.Player.UniversalAudioSource;
    }

    internal int WoodAmount
    {
        set
        {
            woodAmount.text = value.ToString();
        }
    }
    internal int FlintAmount
    {
        set
        {
            flintAmount.text = value.ToString();
        }
    }
    internal int BerriesAmount
    {
        set
        {
            berriesAmount.text = value.ToString();
        }
    }

    public void Craft()
    {
        if (GameManager.Instance.Inventory.Craft())
        {
			audioSource.PlayOneShot(craftSounds[Random.Range(0, craftSounds.Length)]);
            torchPlaceMode.Activate();
        }
        else
            Debug.Log("ErrorSound");
    }

    public void Eat()
    {
        if (GameManager.Instance.Inventory.Consume())
		{
			audioSource.PlayOneShot(eatSounds[Random.Range(0, eatSounds.Length)]);
			GameManager.Instance.CharacterStats.Satiate();
        }
        else
            Debug.Log("ErrorSound");
    }
}
