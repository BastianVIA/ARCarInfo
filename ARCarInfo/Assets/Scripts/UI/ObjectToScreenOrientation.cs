using UnityEngine;

public class ObjectToScreenOrientation : MonoBehaviour
{
    private Transform _transform;
    private Transform _cameraTransform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        Rotate();
    }

    void Rotate() {

        Vector3 direction = (_transform.position - _cameraTransform.position);
        Quaternion lookDirection = Quaternion.LookRotation(direction.normalized);

        _transform.rotation = lookDirection;
    }
}
