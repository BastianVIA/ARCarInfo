using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    [SerializeField]
    private DemandSO demands;

    [SerializeField]
    private GameObject bulletPointPrefab;

    private void OnEnable()
    {
        AddDemandBulletPoints();
    }


    private void AddDemandBulletPoints()
    {
        if (transform.childCount >= demands.points.Count) return;

        foreach (var point in demands.points)
        {
            GameObject newText = Instantiate(bulletPointPrefab, transform);
            newText.GetComponent<TextMeshProUGUI>().text = point;
        }
    }
}
