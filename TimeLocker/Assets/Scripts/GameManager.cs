using UnityEngine;
using Cinemachine;
using JFramework.Core;

public enum GameState
{
    GameState_UI,

    GameState_Run
}

public class GameManager : MonoSingleton<GameManager>
{
    public Role role;

    public UIController ui;

    public CinemachineVirtualCamera[] cameras;

    public Vector3 startPos;

    private GameState _state;


    // Start is called before the first frame update
    void Start()
    {
        role.onDeath += Role_onDeath;

        RestartGame();
    }

    private void Role_onDeath(bool obj)
    {
        if (obj)
        {
            SetGameState(GameState.GameState_UI);
        }
    }


    public void RestartGame()
    {
        SetGameState(GameState.GameState_Run);
    }


    private void SetGameState(GameState state)
    {
        if (_state == state)
        {
            return;
        }

        _state = state;

        switch (_state)
        {
            case GameState.GameState_UI:
            {
                Time.timeScale = 1;

                role.SetCanControl(false);


                cameras[0].enabled = false;
                cameras[1].enabled = true;

                ui.ShowEndView();
            }
                break;
            case GameState.GameState_Run:
            {
                ui.HideEndView();

                role.Revive(startPos);

                cameras[1].enabled = false;
                cameras[0].enabled = true;

                role.SetCanControl(true);
            }
                break;
        }

        EventManager.Invoke(MsgID.OnGameStateChange, _state);
    }

    private void Update()
    {
        // MsgManager.Instance.OnUpdate();
    }
}