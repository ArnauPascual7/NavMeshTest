using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    public InputSystem_Actions inputActions { get; private set; }

    public Vector2 MousePosition { get; private set; }
    public bool ClickPressed { get; private set; }

    private void OnEnable()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Enable();

        inputActions.Player.SetCallbacks(this);
        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
        inputActions.Player.RemoveCallbacks(this);
    }

    private void LateUpdate()
    {
        ClickPressed = false;
    }

    public void OnMousePosition(InputAction.CallbackContext context)
    {
        MousePosition = context.ReadValue<Vector2>();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        ClickPressed = true;
    }
}
