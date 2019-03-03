using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour, IClickable
{
    public void OnClick(CharController player)
    {
        GameManager.Instance.Inventory.Wood += 1;
        Destroy(gameObject);
    }
}
