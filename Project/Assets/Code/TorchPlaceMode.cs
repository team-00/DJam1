using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchPlaceMode : MonoBehaviour
{
    private bool placeModeActivated = false;

    [SerializeField] private Transform spawnParent;
    [SerializeField] private GameObject inventoryUI, characterStatsUI, torchPrefab;
    [SerializeField] private LayerMask GroundLayer;

    private GameObject torch;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (placeModeActivated && torch != null)
        {
            Physics.Raycast(GameManager.Instance.CurrentCam.ScreenPointToRay(Input.mousePosition), out var hitInfo,20,GroundLayer);
            torch.transform.position = hitInfo.point;
            if (Input.GetMouseButtonDown(0) && torch.GetComponent<Torch>().Placeable)
                Deactivate(true);
            else if (Input.GetButtonDown("Cancel"))
                Deactivate(false);
        }
    }

    public void Activate() //returns true if torch was sucessfully placed
    {
        placeModeActivated = true;
        torch = Instantiate(torchPrefab, spawnParent);
        torch.GetComponent<Torch>().DisableTorchForPlacement();
        HandleUIVisibility();
    }

    private void Deactivate(bool success)
    {
        placeModeActivated = false;
        HandleUIVisibility();
        if (success)
        {
            Debug.Log("PlaceTorchSound");
            torch.GetComponent<Torch>().EnableTorch();
            torch = null;
        }
        else
        {
            Destroy(torch);
            torch = null;
            GameManager.Instance.Inventory.UndoCraft();
        }
    }

    private void HandleUIVisibility()
    {
        gameObject.SetActive(placeModeActivated);
        inventoryUI.SetActive(!placeModeActivated);
        characterStatsUI.SetActive(!placeModeActivated);
    }
}
