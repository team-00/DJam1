using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour, IClickable
{
    public void OnClick(CharController player)
    {
        GameManager.Instance.Inventory.Flint += 1;
        Destroy(gameObject);
    }
}
