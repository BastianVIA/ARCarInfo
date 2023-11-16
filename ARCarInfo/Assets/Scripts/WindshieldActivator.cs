using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindshieldActivator : MonoBehaviour
{
    [SerializeField]
    private GameObject windShieldObject;


    private void OnEnable()
    {
        windShieldObject.SetActive(true);
    }

    private void OnDisable()
    {
        windShieldObject.SetActive(false);
    }
}
