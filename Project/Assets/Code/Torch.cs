﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Torch : MonoBehaviour
{
    [SerializeField] private BoxCollider bCollider;
    [SerializeField] private TorchTrigger trigger;
    [SerializeField] private NavMeshObstacle obstacle;
    [SerializeField] private GameObject particles, tLight;

    internal bool Placeable
    {
        get
        {
            return trigger.Placeable;
        }
    }

    internal void DisableTorchForPlacement()
    {
        bCollider.enabled = false;
        obstacle.enabled = false;
        particles.SetActive(false);
        tLight.SetActive(false);
    }

    internal void EnableTorch()
    {
        bCollider.enabled = true;
        obstacle.enabled = true;
        particles.SetActive(true);
        tLight.SetActive(true);
        Destroy(trigger.gameObject);
    }
}
