using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DemandsController : MonoBehaviour
{
    [SerializeField]
    private GameObject body, textBulletPointPrefab;

    [SerializeField]
    private TextMeshProUGUI title;

    [SerializeField]
    private DemandSO demands;

    private void OnEnable()
    {
        SetDemands();
    }


    private void SetTitle(string title) { 
        this.title.text = title;
    }

    private void CreateBulletPoints(List<string> points) {
        if (body.transform.childCount >= points.Count) return;

        foreach (var point in points)
        {
            GameObject newText = Instantiate(textBulletPointPrefab, body.transform);
            newText.GetComponentInChildren<TextMeshProUGUI>().text = point;
        }
    }

    private void SetDemands() {
        SetTitle(demands.Title);
        CreateBulletPoints(demands.points);
    }
}
