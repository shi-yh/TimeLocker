using Cinemachine;
using JFramework;
using JFramework.Core;
using UnityEngine;

namespace GameManager
{
    public class CameraControl : Controller<GameManager>
    {
        private CinemachineVirtualCamera _runCamera;

        private CinemachineVirtualCamera _endCamera;


        protected override void Spawn()
        {
            GameObject cameraGo = AssetManager.Load<GameObject>("Prefabs/Camera");

            CinemachineVirtualCamera[] camera = cameraGo.GetComponentsInChildren<CinemachineVirtualCamera>();

            _runCamera = camera[0];

            _endCamera = camera[1];

        }

        public void SetCameraType(GameState state)
        {
            switch (state)
            {
                case GameState.GameState_Pause:
                {
                    _runCamera.enabled = false;
                    _endCamera.enabled = true;
                }
                    break;
                case GameState.GameState_Run:
                {
                    _endCamera.enabled = false;

                    _runCamera.enabled = true;
                }
                    break;
            }
        }
    }
}