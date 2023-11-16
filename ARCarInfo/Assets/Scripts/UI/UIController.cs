using UI;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject uiObject;
    
    private UIManager uiManager;

    private void Start()
    {
        uiManager = FindFirstObjectByType<UIManager>();
    }
    public void EnableUI()
    {
        if (uiManager.UIIsOpen) return;
        uiObject.SetActive(true);
        uiManager.UIIsOpen = true;
    }

    public void DisableUI()
    { 
        uiObject.SetActive(false);
        uiManager.UIIsOpen = false;
    }
}
