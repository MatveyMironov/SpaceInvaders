using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputListener : MonoBehaviour
{
    private PlayerControls _playerControls;

    public static event Action<float> OnMovementCalled;

    private void Awake()
    {
        _playerControls = new PlayerControls();

        _playerControls.MainActionMap.Move.started += OnMove;
        _playerControls.MainActionMap.Move.performed += OnMove;
        _playerControls.MainActionMap.Move.canceled += OnMove;
    }

    private void OnMove(InputAction.CallbackContext callbackContext)
    {
        float movementInput = callbackContext.ReadValue<float>();
        OnMovementCalled?.Invoke(movementInput);
    }

    private void OnEnable()
    {
        _playerControls.MainActionMap.Enable();
    }

    private void OnDisable()
    {
        _playerControls.MainActionMap.Disable();
    }
}
