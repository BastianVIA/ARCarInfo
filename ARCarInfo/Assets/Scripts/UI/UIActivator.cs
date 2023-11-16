using UnityEngine;

public class UIActivator : MonoBehaviour, IInteractable
{
    private UIController _uiController;

    private void Awake()
    {
        _uiController = GetComponentInChildren<UIController>();
    }

    public void Interact()
    {
        _uiController.EnableUI();
    } 
}
