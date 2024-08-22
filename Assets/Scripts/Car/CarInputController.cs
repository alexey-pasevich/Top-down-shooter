using Cinemachine;
using ShadowChimera;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TopDownShoot
{
    public class CarInputController : MonoBehaviour
    {
        [SerializeField] private CarPhysicController m_car;
        [SerializeField] private CinemachineVirtualCamera m_camera;
        [SerializeField] private InputActionAsset m_inputActionAsset;

        public event System.Action OnExitCar;

        private CarControl m_carControl;

        private void Awake()
        {
            m_carControl = new CarControl(m_inputActionAsset.FindActionMap("Car"));
        }

        public void Init(CarPhysicController car)
        {
            m_car = car;

            m_camera.Follow = car.transform;
            m_camera.LookAt = car.transform;
        }

        private void OnEnable()
        {
            m_carControl.Enable();
        }
        private void OnDisable()
        {
            m_carControl.Disable();
        }

        private void Start()
        {
            if (m_car != null)
            { 
                Init(m_car);
            }
        }

        private void Update()
        {
            if (m_car) 
            {
                m_car.SetInput(m_carControl.accel, m_carControl.brake, m_carControl.steering);

                if (m_carControl.exitPerformed)
                { 
                    OnExitCar?.Invoke();
                }
            }
        }
    }

    public class CarControl
    {
        public float accel => m_accelAction.ReadValue<float>();
        public float brake => m_brakeAction.ReadValue<float>();
        public float steering => m_steeringAction.ReadValue<float>();

        public bool exitPerformed => m_exitAction.WasPerformedThisFrame();

        private readonly InputAction m_steeringAction;
        private readonly InputAction m_accelAction;
        private readonly InputAction m_brakeAction;
        private readonly InputActionMap m_map;
        private readonly InputAction m_exitAction;

        public CarControl(InputActionMap map)
        { 
            m_map = map;

            m_steeringAction = map.FindAction("Steering", true);
            m_accelAction = map.FindAction("Accel", true);
            m_brakeAction = map.FindAction("Brake", true);
            m_exitAction = map.FindAction("Exit", true);
        }

        public void Enable()
        { 
            m_map.Enable();
        }

        public void Disable()
        {
            m_map.Disable();
        }
    }
}
