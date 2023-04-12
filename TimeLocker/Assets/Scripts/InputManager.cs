using JFramework;
using JFramework.Core;
using UnityEngine.InputSystem;

public class InputManager
{
    private MyActions _myActions;

    public InputManager()
    {
        _myActions = new MyActions();
        _myActions.Enable();

        _myActions.PlayerMove.Move.performed += Move;
        _myActions.PlayerMove.Move.canceled += Stop;
    }

    private void Move(InputAction.CallbackContext context)
    {
        EventManager.Invoke(MsgID.OnInputMovePerformed, context);
    }

    private void Stop(InputAction.CallbackContext context)
    {
        EventManager.Invoke(MsgID.OnInputMoveCanceled, context);
    }
}