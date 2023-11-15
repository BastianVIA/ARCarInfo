using UnityEngine;

public class ObjectInteractor : MonoBehaviour
{
    
    [SerializeField]
    private LayerMask layerMask;


    [SerializeField]
    private GameObject currentSelection;

    private void Awake()
    {
        InputController.OnClick += HandleClick;
    }

    private void HandleClick(Vector3 position) {
        
        
        HitObjectAtPosition(position);    
    }

    private void HitObjectAtPosition(Vector3 clickPosition) {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(clickPosition);
        if (Physics.Raycast(ray, out hit, 100f, layerMask)) {
            hit.collider.GetComponent<IInteractable>().Interact();
        }
    }
}
