using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputListener : MonoBehaviour
{
    private PlayerControls _playerControls;

    public static event Action<float> OnMovementCalled;
    public static event Action OnShootCalled;

    private void Awake()
    {
        _playerControls = new PlayerControls();

        _playerControls.MainActionMap.Move.started += OnMove;
        _playerControls.MainActionMap.Move.performed += OnMove;
        _playerControls.MainActionMap.Move.canceled += OnMove;

        _playerControls.MainActionMap.Shoot.performed += OnShoot;
    }

    private void OnMove(InputAction.CallbackContext callbackContext)
    {
        float movementInput = callbackContext.ReadValue<float>();
        OnMovementCalled?.Invoke(movementInput);
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        OnShootCalled?.Invoke();
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
