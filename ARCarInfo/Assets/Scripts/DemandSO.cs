using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Demand")]
public class DemandSO : ScriptableObject
{
    public string Title;
    public List<string> points = new List<string>();
}
