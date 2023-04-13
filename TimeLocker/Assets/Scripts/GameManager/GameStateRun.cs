using JFramework;
using JFramework.Core;

namespace GameManager
{
    public class GameStateRun : State<GameManager>
    {
        private readonly GameState _state = GameState.GameState_Run;

        protected override void OnEnter()
        {
            owner.CameraCtrl.SetCameraType(_state);
            owner.InputCtrl.SetInputType(_state);
            EventManager.Invoke(MsgID.OnGameStateChange, _state);
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnExit()
        {
        }
    }
}