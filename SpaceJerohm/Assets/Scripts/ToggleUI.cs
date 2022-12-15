using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleUI : MonoBehaviour
{
    public InputActionAsset inputActions;
    private Canvas _cheesecakeUICanvas;
    private InputAction _menu;
    private void Start()
    {
        _cheesecakeUICanvas = GetComponent<Canvas>();
        _menu = inputActions.FindActionMap("XRI LeftHand").FindAction("Menu");
        _menu.Enable();
        _menu.performed += ToggleMenu;
    }

    private void OnDestroy()
    {
        _menu.performed -= ToggleMenu;
    }

    public void ToggleMenu(InputAction.CallbackContext context)
    {
        _cheesecakeUICanvas.enabled = !_cheesecakeUICanvas.enabled;
    }
}
