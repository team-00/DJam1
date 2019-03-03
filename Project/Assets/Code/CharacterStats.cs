using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats
{
    private float sanity, hunger; // 0 = INSANE & 100 = HEALTHY

    internal float Sanity
    {
        get => sanity;
        set
        {
            sanity = value;
            panel.Sanity = value;
        }
    }
    internal float Hunger
    {
        get => hunger;
        set
        {
            hunger = value;
            panel.Hunger = value;
        }
    }

    private CharacterStatsPanel panel;

    internal CharacterStats()
    {
        hunger = 100;
        sanity = 100;
    }

    internal void ConnectPanel(CharacterStatsPanel panel)
    {
        this.panel = panel;
    }
}
