using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition;
    private GameObject spawnedObject;
    private List<ARRaycastHit> hits = new List<ARRaycastHit> ();
    
    void Start()
    {
        _arRaycastManager = GetComponent<ARRaycastManager> ();
    }
    
    void Update()
    {
        PlaceObject();
    }

    void PlaceObject() {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                touchPosition = touch.position;

            if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;

                if (spawnedObject == null)
                    spawnedObject = Instantiate(prefab, hitPose.position, hitPose.rotation);
                else
                    spawnedObject.transform.position = hitPose.position;
            }
        }
    }
}
