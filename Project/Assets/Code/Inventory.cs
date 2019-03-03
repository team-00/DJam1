using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private int wood, flint, berries, torches;

    internal int Wood
    {
        get { return wood; }
        set
        {
            wood = value;
            panel.WoodAmount = value;
        }
    }
    internal int Flint
    {
        get { return flint; }
        set
        {
            flint = value;
            panel.FlintAmount = value;
        }
    }
    internal int Torches
    {
        get { return torches; }
        set
        {
            torches = value;
            panel.TorchAmount = value;
        }
    }
    internal int Berries
    {
        get { return berries; }
        set
        {
            berries = value;
            panel.BerriesAmount = value;
        }
    }

    private InventoryPanel panel;

    internal Inventory()
    {
        wood = 0;
        flint = 0;
        torches = 0;
        berries = 0;
    }

    internal void ConnectPanel(InventoryPanel panel)
    {
        this.panel = panel;
    }

    internal bool Craft()
    {
        bool canCraft = wood > 0 && flint > 0;
        if (canCraft)
        {
            Wood -= 1;
            Flint -= 1;
            Torches += 1;
        }
        return canCraft;
    }

    internal bool Consume()
    {
        bool canConsume = berries > 0;
        if (canConsume)
            Berries -= 1;
        return canConsume;
    }
}
