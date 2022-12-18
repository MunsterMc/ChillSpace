using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleUI : MonoBehaviour
{
    [SerializeField] private Transform player;
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

    private void Update()
    {
        _cheesecakeUICanvas.transform.LookAt(new Vector3(player.position.x, _cheesecakeUICanvas.transform.position.y, player.position.z));
        _cheesecakeUICanvas.transform.forward *= -1;
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
