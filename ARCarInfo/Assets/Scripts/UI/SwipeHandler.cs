using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector2 _dragEnd, _dragBegin;
    
    private UIController _uiController;
    private PanelViewController _panelViewController;

    private void Awake()
    {
        _uiController = GetComponentInParent<UIController>();
        _panelViewController = GetComponent<PanelViewController>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _dragBegin = eventData.pressPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _dragEnd = eventData.position;
        Debug.Log("Drag beingnge");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var swipe = GetSwipe();
        switch (swipe)
        {
            case SwipeAction.Right:
                PreviousPage();
                break;
            case SwipeAction.Left:
                NextPage();
                break;
            case SwipeAction.Down:
                Close();
                break;
            default:
                Debug.Log("Swipe action not handled");
                break;
        }
    }

    private SwipeAction GetSwipe() { 
        var direction = _dragEnd - _dragBegin;

        if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y) && direction.y < 0) return SwipeAction.Down;
        if (direction.x < 0) return SwipeAction.Left;
        if (direction.x > 0) return SwipeAction.Right;
        return SwipeAction.None;
    }

    private void NextPage() { 
        _panelViewController.NextPage();
    }

    private void PreviousPage() { 
        _panelViewController.PrevPage();
    }

    private void Close() {
        _uiController.DisableUI();
    }    
}

public enum SwipeAction { 
    Right,
    Left,
    Down,
    None
}
