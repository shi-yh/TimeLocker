using JFramework;

namespace GameManager
{
    public class GameManagerMachine : StateMachine<GameManager>
    {
        protected override void Spawn()
        {
            AddState<GameStateRun>();
            AddState<GameStateEnd>();
        }
    }
}