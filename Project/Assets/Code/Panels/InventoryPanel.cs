using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI woodAmount, flintAmount, berriesAmount;
    [SerializeField] private TorchPlaceMode torchPlaceMode;

    internal void Awake()
    {
        GameManager.Instance.Inventory.ConnectPanel(this);
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
            Debug.Log("CraftSound");
            torchPlaceMode.Activate();
        }
        else
            Debug.Log("ErrorSound");
    }

    public void Eat()
    {
        if (GameManager.Instance.Inventory.Consume())
        {
            Debug.Log("EatSound");
            GameManager.Instance.CharacterStats.Satiate();
        }
        else
            Debug.Log("ErrorSound");
    }
}
