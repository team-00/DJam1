using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatsPanel : MonoBehaviour
{
    [SerializeField] private Slider hunger, sanity;

    internal void Awake()
    {
        GameManager.Instance.CharacterStats.ConnectPanel(this);
    }

    internal float Sanity
    {
        set
        {
            sanity.value = value / 100;
        }
    }
    internal float Hunger
    {
        set
        {
            hunger.value = value / 100;
        }
    }
}
