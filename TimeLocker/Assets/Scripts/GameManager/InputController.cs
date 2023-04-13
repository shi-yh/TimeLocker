using JFramework;
using JFramework.Core;
using UnityEngine.InputSystem;

namespace GameManager
{
    public class InputController : Controller<GameManager>
    {
        private MyActions _myActions;


        protected override void Start()
        {
            _myActions = new MyActions();
            _myActions.Enable();
            _myActions.PlayerMove.Disable();
            _myActions.UI.Disable();


            _myActions.PlayerMove.Move.performed += Move;
            _myActions.PlayerMove.Move.canceled += Stop;
        }

        public void SetInputType(GameState state)
        {
            if (state == GameState.GameState_Run)
            {
                _myActions.PlayerMove.Enable();
                _myActions.UI.Disable();
            }
            else
            {
                _myActions.PlayerMove.Disable();
                _myActions.UI.Enable();
            }
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
}