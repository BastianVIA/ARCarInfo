using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTracker : MonoBehaviour
{
    [SerializeField]
    private Texture2D img;
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;

    private GameObject spawned;
    private ARTrackedImageManager _imageManager;
    private void Awake()
    {
        _imageManager = GetComponent<ARTrackedImageManager>();
        //AddImage();
        Debug.Log("image: " + _imageManager.referenceLibrary.count);
        textMeshProUGUI.text = "Awaken";
    }


   


    private void OnEnable()
    {
        _imageManager.trackedImagesChanged += OnChanged;
    }

    private void OnDisable()
    {
        _imageManager.trackedImagesChanged -= OnChanged;
    }


    void OnChanged(ARTrackedImagesChangedEventArgs evt)
    {
        foreach (var newImage in evt.added)
        {
            //spawned = Instantiate(prefab, newImage.transform);
            textMeshProUGUI.text = "Shit mand billed læst";
        }

        foreach (var updatedImage in evt.updated)
        {
            //spawned.transform.position = updatedImage.transform.position;
            textMeshProUGUI.text = "Billed updateret";
        }

        foreach (var removedImage in evt.removed)
        {
            textMeshProUGUI.text = "Billed gone";
        }

    }
}
