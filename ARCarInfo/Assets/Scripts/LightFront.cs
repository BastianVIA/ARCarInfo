using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFront : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject ui;

    private PanelViewController _uiController;

    private void Awake()
    {
        _uiController = GetComponentInChildren<PanelViewController>();
    }

    public void Interact()
    {
        

    }
}
