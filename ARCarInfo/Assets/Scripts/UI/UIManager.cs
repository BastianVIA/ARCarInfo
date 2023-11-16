using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public bool UIIsOpen { get; set; } = false;

    private void Awake()
    {
        _instance = this;
    }
}
