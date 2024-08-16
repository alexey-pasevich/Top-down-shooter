using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public class GameplayState : GameState
    {
        [SerializeField] CameraManager m_cameraManager;

        private void OnEnable()
        {
            base.OnEnable();

            m_cameraManager.Activate(CameraNames.Player);
        }

        public void GoToPause()
        {
            States.instance.Push<PauseState>();
        }
    }

}
