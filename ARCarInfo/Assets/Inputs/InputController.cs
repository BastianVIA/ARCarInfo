using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private UserActionsGen _actions;
    private Vector2 _dragBegin, _dragEnd;

    public delegate void ClickAction(Vector3 position);
    public static event ClickAction OnClick;

    private void OnEnable()
    {
        _actions = new UserActionsGen();
        _actions.Enable();

        _actions.Touch.Enable();
        _actions.Touch.Position.performed += Click;
        _actions.Touch.Swipe.performed += OnBeginDrag;
        _actions.Touch.Swipe.canceled += OnEndDrag;
    }

    private void OnDisable()
    {
        _actions.Touch.Position.performed -= Click;
        _actions.Touch.Swipe.performed -= OnBeginDrag;
        _actions.Touch.Swipe.canceled -= OnEndDrag;
        _actions.Disable();
    }

    private void Click(InputAction.CallbackContext callbackContext)
    {
        var touch = callbackContext.ReadValue<Vector2>();
        OnClick?.Invoke(touch);
    }

    public void OnBeginDrag(InputAction.CallbackContext callbackContext)
    {
        _dragBegin = callbackContext.ReadValue<Vector2>();
        //Debug.Log("drag begin: " + _dragBegin);

    }

    public void OnEndDrag(InputAction.CallbackContext callbackContext)
    {
        var dragEnd = callbackContext.ReadValue<Vector2>();
        //Debug.Log("drag end: " + dragEnd);

        var direction = dragEnd - _dragBegin;
        //Debug.Log("Direction vector: " + direction);

    }

   
}
