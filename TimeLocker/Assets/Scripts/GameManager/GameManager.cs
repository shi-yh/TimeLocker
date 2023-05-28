using JFramework;
using UnityEngine;

namespace GameManager
{
    public enum GameState
    {
        GameState_Initial,

        GameState_Pause,

        GameState_Run,

        GameState_End,
    }

    public class GameManager : EntitySpecial
    {
        private GameManagerMachine _machie;

        public Role role;

        public UIController ui;


        public Vector3 startPos;

        private GameState _state;

        internal InputController InputCtrl { get; private set; }
        internal CameraControl CameraCtrl { get; private set; }


        protected override void OnEnable()
        {
            base.OnEnable();
            _machie = Get<GameManagerMachine>();
            InputCtrl = Get<InputController>();
            CameraCtrl = Get<CameraControl>();


            RestartGame();
        }


        public void RestartGame()
        {
            _machie.ChangeState<GameStateRun>();
        }


        protected override void OnUpdate()
        {
            _machie.OnUpdate();
        }
    }
}