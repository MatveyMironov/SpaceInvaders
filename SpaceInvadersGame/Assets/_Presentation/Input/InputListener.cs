using System;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    public static event Action<float> OnMovementCalled;

    private float _previousMovementInput;

    private void Update()
    {
        float movementInput = Input.GetAxis("Horizontal");

        if (movementInput != _previousMovementInput)
        {
            OnMovementCalled?.Invoke(movementInput);
            _previousMovementInput = movementInput;
        }
    }
}
