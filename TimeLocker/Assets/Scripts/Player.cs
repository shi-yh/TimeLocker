using JFramework.Core;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Role
{
    protected override void OnEnable()
    {
        base.OnEnable();
        
        EventManager.Listen(MsgID.OnInputMovePerformed, OnInputMovePerformed);
        EventManager.Listen(MsgID.OnInputMoveCanceled, OnInputMoveCanceled);
    }


    private void OnInputMoveCanceled(object[] args)
    {
        InputAction.CallbackContext context = (InputAction.CallbackContext)args[0];

        MoveCtrl.Stop();
    }

    private void OnInputMovePerformed(object[] args)
    {
        InputAction.CallbackContext context = (InputAction.CallbackContext)args[0];
        MoveCtrl.Move(context.ReadValue<Vector3>().normalized);
    }


    protected override void OnDisable()
    {
        base.OnDisable();

        EventManager.Remove(MsgID.OnInputMovePerformed, OnInputMovePerformed);
        EventManager.Remove(MsgID.OnInputMoveCanceled, OnInputMoveCanceled);
    }
}