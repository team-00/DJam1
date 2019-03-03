using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject UserInterface, MenuInterface, Controls;

	private void Start()
    {
        UserInterface.SetActive(false);
        Controls.SetActive(false);
    }

    public void GameStart()
    {
		CharController player = GameManager.Instance.Player;
        player.PlayInventorySound();
		player.enabled = true;
		player.ToggleSitting(player.StartCampfire.position);
        UserInterface.SetActive(true);
        MenuInterface.SetActive(false);
    }

    public void DisplayControls()
    {
        GameManager.Instance.Player.PlayInventorySound();
        Controls.SetActive(!Controls.activeInHierarchy);
    }

    public void DisplayCredits()
    {
        GameManager.Instance.Player.PlayInventorySound();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        GameManager.Instance.Player.PlayInventorySound();
        Application.Quit();
    }
}
