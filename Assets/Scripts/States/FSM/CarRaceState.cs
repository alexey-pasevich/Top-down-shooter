using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public class CarRaceState : BaseState
    {
        public CarRaceState(GameplayContext context) : base(context)
        {
            SetPause(true);
        }

        public override void SetPause(bool pause)
        {
            if (context.carController)
            {
                context.carController.enabled = !pause;
            }

            if (context.carInputUI)
            {
                context.carInputUI.SetActive(!pause);
            }

            if (!pause)
            {
                context.cameraManager.Activate(CameraNames.Car);
            }
        }

        public override void Enter()
        {
            context.inCar = true;

            var carController = context.carController;
            var character = context.character;


            var characterTr = character.transform;
            character.enabled = false;
            characterTr.SetParent(context.car.driverPoint);
            characterTr.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

            carController.SetCar(context.car);
            carController.gameObject.SetActive(true);
            carController.OnExitCar += OnExitCar;

            OnColliderFalse();
            SetPause(false);
        }

        public void OnColliderTrue()
        { 
            var characterT = context.character;
            characterT.GetComponent<Collider>().enabled = true;
        }

        public void OnColliderFalse()
        {
            var characterT = context.character;
            characterT.GetComponent<Collider>().enabled = false;
        }

        public override void Exit()
        {
            SetPause(true);

            var carController = context.carController;
            if (carController == null)
            {
                return;
            }

            var character = context.character;
            if (character == null)
            {
                return;
            }


            var characterTr = character.transform;
            var exitPoint = context.car.exitPoint;

            characterTr.SetParent(null);
            characterTr.SetPositionAndRotation(exitPoint.position, exitPoint.rotation);
            character.enabled = true;

            carController.SetCar(null);
            carController.gameObject.SetActive(false);
            carController.OnExitCar -= OnExitCar;

            OnColliderTrue();
            context.car = null;
        }

        private void OnExitCar()
        {
            context.inCar = false;
        }
    }
}
