using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject uiObject;

    public void EnableUI()
    {
        uiObject.SetActive(true);   
    }

    public void DisableUI()
    { 
        uiObject.SetActive(false);
    }
}
