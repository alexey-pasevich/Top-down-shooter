using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

namespace TopDownShoot
{
    public class GameplayState : GameState
    {
        [SerializeField] CameraManager m_cameraManager;

        [SerializeField] PlayerController m_playerController;
        [SerializeField] CarInputController m_carController;
        [SerializeField] Character m_character;

        [SerializeField] GameObject m_playerInputUI;
        [SerializeField] GameObject m_carInputUI;

        private GameplayFSM m_gameplayFsm;

        private void OnEnable()
        {
            m_gameplayFsm.Activate();
        }

        private void Awake()
        {
            var context = new GameplayContext()
            {
                carController = m_carController,
                playerController = m_playerController,
                character = m_character,
                cameraManager = m_cameraManager,
                playerInputUI = m_playerInputUI,
                carInputUI = m_carInputUI
            };
            m_gameplayFsm = new GameplayFSM(context);

            if (TryGetComponent<TasksController>(out var tasksController))
            {
                tasksController.Init(m_character, GameInstance.instance.player);
            }
        }

        private void OnDisable()
        {
            
            m_gameplayFsm.Deactivate();
        }

        private void Update()
        {
            m_gameplayFsm.Update();         
        }

        public void GoToPause()
        {
            States.instance.Push<PauseState>();
        }
    }

}
