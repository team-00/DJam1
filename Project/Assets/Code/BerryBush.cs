using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryBush : MonoBehaviour, IClickable
{
    private bool canNotBeHarvestedAnymore = false;

    [SerializeField] private GameObject[] Berries;
	[SerializeField] private float berryRegrowTime = 60f;

    public void OnClick(CharController player)
    {
        if (!canNotBeHarvestedAnymore)
        {
            GameManager.Instance.Inventory.Berries += 6;
            HarvestBerries();
        }
    }

    private void HarvestBerries()
    {
        canNotBeHarvestedAnymore = true;
        foreach (var berry in Berries)
        {
            berry.SetActive(false);
        }
		StartCoroutine(RegrowBerries());
    }

	private IEnumerator RegrowBerries()
	{
		yield return new WaitForSeconds(berryRegrowTime);
		canNotBeHarvestedAnymore = false;
		foreach (var berry in Berries)
		{
			berry.SetActive(false);
		}
	}
}
