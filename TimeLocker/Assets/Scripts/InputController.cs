using System;
using JFramework;
using JFramework.Core;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : Controller<GameManager>
{
    private MyActions _myActions;


    protected override void Start()
    {
        _myActions = new MyActions();
        _myActions.Enable();

        _myActions.PlayerMove.Move.performed += Move;
        _myActions.PlayerMove.Move.canceled += Stop;
    }

    private void Stop(InputAction.CallbackContext obj)
    {
        EventManager.Invoke(MsgID.OnInputMoveCanceled, obj);
    }

    private void Move(InputAction.CallbackContext obj)
    {
        EventManager.Invoke(MsgID.OnInputMovePerformed, obj);
    }
}