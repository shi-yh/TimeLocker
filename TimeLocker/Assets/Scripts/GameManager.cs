using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
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
            StartCoroutine(SetGameState(GameState.GameState_UI));
        }

    }


    public void RestartGame()
    {
        StartCoroutine(SetGameState(GameState.GameState_Run));
    }


    public IEnumerator SetGameState(GameState state)
    {
        if (_state==state)
        {
            yield break ;
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

                    yield return new WaitForSecondsRealtime(2.15f);

                    ui.ShowEndView();


                }
                break;
            case GameState.GameState_Run:
                {

                    ui.HideEndView();

                    role.Revive(startPos);

                    cameras[1].enabled = false;
                    cameras[0].enabled = true;
                    
                    yield return new WaitForSecondsRealtime(2.15f);

                    role.SetCanControl(true);


                }
                break;
            default:
                break;
        }



    }


    private void Update()
    {
        

       


        
    }


}
