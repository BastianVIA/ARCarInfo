using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFront : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject ui;

    private SwipeUIController _uiController;

    private void Awake()
    {
        _uiController = GetComponentInChildren<SwipeUIController>();
    }

    public void Interact()
    {
        _uiController.EnableUI();

    }
}
