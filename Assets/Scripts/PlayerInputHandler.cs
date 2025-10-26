using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public static Action<Vector2> MoveInput;
    public static Action<Vector2> LookInput;
    public static Action InteractInput;
    public static Action JumpInput;

    public void OnLook(InputAction.CallbackContext context)
    {
        LookInput?.Invoke(context.ReadValue<Vector2>());
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        InteractInput?.Invoke();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        JumpInput?.Invoke();
    }
}
