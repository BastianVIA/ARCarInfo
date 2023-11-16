using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CarModelSpawner : MonoBehaviour
{
    [SerializeField] private GameObject carPrefab;

    [SerializeField] private ARTrackedImageManager trackedImageManager;
    
    private CarController carController;
    
    private GameObject carObject;

    void OnEnable() => trackedImageManager.trackedImagesChanged += OnChanged;

    void OnDisable() => trackedImageManager.trackedImagesChanged -= OnChanged;

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            SpawnObject(newImage.transform.position);
        }

        foreach (var updatedImage in eventArgs.updated)
        {
            carController.UpdateSpawnedObject(updatedImage.transform);
        }

        foreach (var removedImage in eventArgs.removed) {}
    }
    
    void SpawnObject(Vector3 position)
    {
        carObject = Instantiate(carPrefab, position, Quaternion.identity);
        carObject.SetActive(true);
        carController = carObject.GetComponent<CarController>();
    }
}