using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AutoPositionDemandContainer : MonoBehaviour
{

    private void OnValidate()
    {
        var rect = transform.GetComponent<RectTransform>();
        
    }

    public float CalculatePosition(int x) {
        return 174.5f * x + 2.5f;
    }
}
