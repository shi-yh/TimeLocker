using JFramework;

namespace GameManager
{
    public class GameManagerMachine : Machine<GameManager>
    {
        protected override void Start()
        {
            base.Start();

            AddState<GameStateRun>();
            AddState<GameStateEnd>();
        }
    
    }
}