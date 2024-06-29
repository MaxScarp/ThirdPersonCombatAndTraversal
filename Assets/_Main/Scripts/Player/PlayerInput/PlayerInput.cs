using System;
using UnityEngine.InputSystem;

public static class PlayerInput
{
    public static event Action OnJump;
    public static event Action OnDodge;

    private static PlayerInputActions playerInputActions;

    private static PlayerInputActions.PlayerActions playerActionMap;

    static PlayerInput()
    {
        playerInputActions = new PlayerInputActions();
        playerActionMap = playerInputActions.Player;
    }

    public static void EnablePlayerActionMap()
    {
        playerActionMap.Enable();

        playerActionMap.Jump.performed += PlayerActionMap_jump_performed;
        playerActionMap.Dodge.performed += PlayerActionMap_dodge_performed;
    }

    private static void PlayerActionMap_dodge_performed(InputAction.CallbackContext obj)
    {
        OnDodge?.Invoke();
    }

    private static void PlayerActionMap_jump_performed(InputAction.CallbackContext obj)
    {
        OnJump?.Invoke();
    }

    public static void DisablePlayerActionMap()
    {
        playerActionMap.Disable();

        playerActionMap.Jump.performed -= PlayerActionMap_jump_performed;
        playerActionMap.Dodge.performed -= PlayerActionMap_dodge_performed;
    }
}
