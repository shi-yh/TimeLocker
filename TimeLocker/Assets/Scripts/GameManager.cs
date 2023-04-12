using UnityEngine;
using Cinemachine;
using JFramework;
using JFramework.Core;

public enum GameState
{
    GameState_UI,

    GameState_Run
}

public class GameManager : Entity
{
    public Role role;

    public UIController ui;

    public CinemachineVirtualCamera[] cameras;

    public Vector3 startPos;

    private GameState _state;


    public InputController inputCtrl => Get<InputController>();

    protected override void OnEnable()
    {
        base.OnEnable();
        
        Debug.Log(inputCtrl);
        
        RestartGame();

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

                cameras[0].enabled = false;
                cameras[1].enabled = true;

                ui.ShowEndView();
            }
                break;
            case GameState.GameState_Run:
            {
                ui.HideEndView();

                cameras[1].enabled = false;
                cameras[0].enabled = true;
            }
                break;
        }

        EventManager.Invoke(MsgID.OnGameStateChange, _state);
    }
}