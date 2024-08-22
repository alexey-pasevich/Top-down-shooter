using ShadowChimera;
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
        [SerializeField] CarPhysicController m_tempCar;

        private bool m_inCar = false;

        override protected void OnEnable()
        {
            base.OnEnable();

            m_cameraManager.Activate(CameraNames.Player);
            m_carController.gameObject.SetActive(m_inCar);
            m_playerController.gameObject.SetActive(!m_inCar);

            m_playerController.onUseItem += PlayerController_OnUseItem;
            m_carController.OnExitCar += ExitCar;
        }

        private void PlayerController_OnUseItem()
        {
            EnterCar(m_tempCar);
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            if (m_carController) 
            { 
                m_carController?.gameObject.SetActive(false);
                m_carController.OnExitCar -= ExitCar;
            }

            if (m_playerController)
            {
                m_playerController?.gameObject.SetActive(false);
                m_playerController.onUseItem -= PlayerController_OnUseItem;
            }
        }

        public void GoToPause()
        {
            States.instance.Push<PauseState>();
        }

        private void EnterCar(CarPhysicController car)
        { 
            m_carController.Init(car);

            m_playerController.character.transform.SetParent(car.transform, true);

            m_inCar = true;

            m_carController.gameObject.SetActive(true);
            m_playerController.gameObject.SetActive(false);
            m_playerController.SetActiveChar(false);
        }

        private void ExitCar()
        {
            m_inCar = false;

            m_carController.gameObject.SetActive(false);
            m_playerController.gameObject.SetActive(true);
            m_playerController.SetActiveChar(true);

            m_playerController.character.transform.SetParent(null, true);
        }
    }

}
