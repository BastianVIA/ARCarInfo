using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CarController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> modelParts;

    private Transform carTransform;

    private Vector3 scaleFactor = new Vector3(0.06f, 0.08f, 0.08f);

    private bool isLocked = false;

    void Start()
    {
        carTransform = GetComponent<Transform>();
        AddDescendantsWithTag(gameObject.transform, "ModelPart");
    }

    private void AddDescendantsWithTag(Transform parent, string tag)
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.CompareTag(tag))
            {
                modelParts.Add(child.gameObject);
            }
            AddDescendantsWithTag(child, tag);
        }
    }

    public void ShowModelParts()
    {
        foreach (var model in modelParts)
        {
            model.SetActive(true);
        }
    }

    public void HideModelParts()
    {
        foreach (var model in modelParts)
        {
            model.SetActive(false);
        }
    }

    public void LockModel()
    {
        if (gameObject.GetComponent<ARAnchor>() == null)
        {
            gameObject.AddComponent<ARAnchor>();
        }
        isLocked = true;
    }

    public void UnlockModel()
    {
        Destroy(gameObject.GetComponent<ARAnchor>());
        isLocked = false;
    }
    
    public void UpdateSpawnedObject(Transform imageTransform)
    {
        if (isLocked) return;
        
        var newRotation = carTransform.rotation;
        newRotation.y = imageTransform.rotation.y;
        carTransform.position = imageTransform.position;
        carTransform.rotation = newRotation;
        carTransform.localScale = scaleFactor;
    }
}
