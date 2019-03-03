﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI woodAmount, flintAmount, torchAmount, berriesAmount;

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
    internal int TorchAmount
    {
        set
        {
            torchAmount.text = value.ToString();
        }
    }
    internal int BerriesAmount
    {
        set
        {
            berriesAmount.text = value.ToString();
        }
    }
}
