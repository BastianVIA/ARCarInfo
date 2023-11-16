using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.ARFoundation;

public class CarModelSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject objectPrefab;
    
    [SerializeField]
    TextMeshProUGUI spawnText;
    
    [SerializeField]
    ARTrackedImageManager trackedImageManager;

    [SerializeField] private Vector3 scaleFactor = new Vector3(0.06f, 0.06f, 0.06f);
    
    private GameObject spawnedObject;
    
    private bool lockModel = false;

    void OnEnable() => trackedImageManager.trackedImagesChanged += OnChanged;

    void OnDisable() => trackedImageManager.trackedImagesChanged -= OnChanged;

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            UpdateTrackingText("Yes");
            SpawnObject(newImage.transform.position);
        }

        foreach (var updatedImage in eventArgs.updated)
        {
            if (lockModel)
            {
                return;
            }
            UpdateSpawnedObject(updatedImage.transform);
        }

        foreach (var removedImage in eventArgs.removed)
        {
            
        }
    }
    
    void SpawnObject(Vector3 position)
    {
        spawnedObject = Instantiate(objectPrefab, position, Quaternion.identity);
        spawnedObject.SetActive(true);
    }

    void UpdateTrackingText(string newText)
    {
        if (spawnText != null)
        {
            spawnText.text = newText;
        }
    }

    void UpdateSpawnedObject(Transform imageTransform)
    {
        if (spawnedObject != null)
        {
            var newRotation = spawnedObject.transform.rotation;
            newRotation.y = imageTransform.rotation.y;
            spawnedObject.transform.position = imageTransform.position;
            spawnedObject.transform.rotation = newRotation;
            spawnedObject.transform.localScale = scaleFactor;
        }
    }

    public void LockModel()
    {
        if (spawnedObject.GetComponent<ARAnchor>() == null)
        {
            spawnedObject.AddComponent<ARAnchor>();
        }
        lockModel = true;
        UpdateTrackingText("Locked");
    }
}