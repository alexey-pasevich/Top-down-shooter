using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public class GameplayContext
    {
        public Character character;
        public CarPhysicController car;
        public PlayerController playerController;
        public CarInputController carController;
        public bool inCar = false;
        public CameraManager cameraManager;
        public GameObject playerInputUI;
        public GameObject carInputUI;
    }
}
