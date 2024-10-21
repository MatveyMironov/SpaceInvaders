using UnityEngine;
using UnityEngine.InputSystem;

public class InputListener : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    private PlayerControls _playerControls;

    private void Awake()
    {
        _playerControls = new();

        _playerControls.MainActionMap.Move.started += OnMove;
        _playerControls.MainActionMap.Move.performed += OnMove;
        _playerControls.MainActionMap.Move.canceled += OnMove;

        _playerControls.MainActionMap.Fire.performed += OnFire;
    }

    private void OnEnable()
    {
        _playerControls.MainActionMap.Enable();
    }

    private void OnDisable()
    {
        _playerControls.MainActionMap.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        float moveInput = context.ReadValue<float>();
        inputManager.InvokeMovement(moveInput);
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        inputManager.InvokeShoot();
    }
}
