using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wheel : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject ui;    

    private ObjectUIController _uiController;

    private void Awake()
    {
        _uiController = GetComponentInChildren<ObjectUIController>();
    }

    public void Interact()
    {
        _uiController.EnableUI();
        
    } 
}
