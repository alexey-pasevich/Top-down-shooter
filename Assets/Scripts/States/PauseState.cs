using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TopDownShoot
{
    public class PauseState : GameState
    {
        [SerializeField] CameraManager m_cameraManager;

        public GameplayState gameplayState;

        protected override void OnEnable()
        {
            base.OnEnable();
            Time.timeScale = 0f;

            m_cameraManager.Activate(CameraNames.Pause);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            Time.timeScale = 1;
        }

        public void Restart()
        { 
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        public void Resume()
        {
            States.instance.Pop();
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}
