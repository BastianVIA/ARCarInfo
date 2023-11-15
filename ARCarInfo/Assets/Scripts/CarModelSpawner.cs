using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CarModelSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject objectPrefab;
    
    [SerializeField]
    TextMeshProUGUI spawnText;
    
    [SerializeField]
    ARTrackedImageManager trackedImageManager;
   

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
            
        }

        foreach (var removedImage in eventArgs.removed)
        {
            
        }
    }
    
    void SpawnObject(Vector3 position)
    {
        GameObject spawnedObject = Instantiate(objectPrefab, position, Quaternion.identity);
        spawnedObject.SetActive(true);
    }

    void UpdateTrackingText(string newText)
    {
        if (spawnText != null)
        {
            spawnText.text = newText;
        }
    }
}