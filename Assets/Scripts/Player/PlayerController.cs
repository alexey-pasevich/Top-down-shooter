using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using System;

namespace TopDownShoot
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Character m_character;
        [SerializeField] private InputActionAsset m_inputActionAsset;
        [SerializeField] private Transform m_cameraTarget;
        [SerializeField] private Transform m_cameraTransform;
        
        [SerializeField] private float m_speedRotation = 200f;
        [SerializeField] private float m_topClamp = 70f;
        [SerializeField] private float m_bottomClamp = -9f;

        private CharMoveComponent m_charMoveComponent;

        public event System.Action onUseItem;

        public Character character => m_character;

        private float m_cameraTargetYaw;
        private float m_cameraTargetPitch;

        //Input
        private InputActionMap m_playerMap;
        private InputAction m_moveAction;
        private InputAction m_lookAction;
        private InputAction m_fireAction;
        private InputAction m_reloadAction;
        private InputAction m_switchWeaponAction;
        private InputAction m_jumpAction;
        private InputAction m_sprintAction;
        private InputAction m_useAction;

        private bool m_canLook = true;
        private void Awake()
        {
            m_playerMap = m_inputActionAsset.FindActionMap("Player");
            m_moveAction = m_playerMap.FindAction("Move");
            m_lookAction = m_playerMap.FindAction("Look");
            m_fireAction = m_playerMap.FindAction("Fire");
            m_reloadAction = m_playerMap.FindAction("Reload");
            m_switchWeaponAction = m_playerMap.FindAction("SwitchWeapon");
            m_jumpAction = m_playerMap.FindAction("Jump");
            m_sprintAction = m_playerMap.FindAction("Sprint");
            m_useAction = m_playerMap.FindAction("Use");

            m_charMoveComponent = m_character.GetComponent<CharMoveComponent>();
        }

        private void OnEnable()
        {
            m_playerMap.Enable();

            m_fireAction.started += OnFireInputStarted;
            m_fireAction.canceled += OnFireInputCanceled;
            m_reloadAction.performed += OnReloadPerformed;
            m_switchWeaponAction.performed += OnSwitchWeaponPerformed;
            m_jumpAction.performed += OnJumpPerformed;
            m_useAction.performed += OnUsePerfmormed;

            m_canLook = true;
        }

        private void OnUsePerfmormed(InputAction.CallbackContext context)
        {
            onUseItem?.Invoke();
        }

        private void OnDisable()
        {
            m_playerMap.Disable();

            m_fireAction.started -= OnFireInputStarted;
            m_fireAction.canceled -= OnFireInputCanceled;
            m_reloadAction.performed -= OnReloadPerformed;
            m_switchWeaponAction.performed -= OnSwitchWeaponPerformed;
            m_jumpAction.performed -= OnJumpPerformed;
            m_useAction.performed -= OnUsePerfmormed;
        }

        private void OnJumpPerformed(InputAction.CallbackContext obj)
        {
            m_charMoveComponent.Jump();
        }

        private void OnReloadPerformed(InputAction.CallbackContext context)
        { 
            m_character.attackManager.Reload();
        }

        private void OnSwitchWeaponPerformed(InputAction.CallbackContext context)
        {
            m_character.attackManager.Next();
        }

        private void OnFireInputStarted(InputAction.CallbackContext context)
        {
            m_character.attackManager.StartUse();
        }
        private void OnFireInputCanceled(InputAction.CallbackContext context)
        {
            m_character.attackManager.EndUse();
        }

        public void SetActiveChar(bool active)
        { 
            m_character.gameObject.SetActive(active);
        }

        private void Update()
        {
            if (m_character == null)
            { 
                enabled = false;
                return;
            }

            Vector2 move = m_moveAction.ReadValue<Vector2>();
            Move(move, m_sprintAction.IsPressed());
        }

        private void LateUpdate()
        {
            if (EventSystem.current.currentInputModule.input.GetMouseButtonDown(0))
            {
                m_canLook = !EventSystem.current.IsPointerOverGameObject();
            }
            else if (EventSystem.current.currentInputModule.input.GetMouseButtonUp(0))
            {
                m_canLook = true;
            }

            var look = m_canLook ? m_lookAction.ReadValue<Vector2>() : Vector2.zero;
            CameraRotation(look);
        }


        private void Move(Vector2 move, bool isSprint)
        {
            m_charMoveComponent.Move(move, isSprint, m_cameraTransform.eulerAngles.y);
        }



        private void CameraRotation(Vector2 look)
        {
            const float threshold = 0.01f;

            if (look.sqrMagnitude >= threshold)
            {
                float deltaTimeMultiplier = m_speedRotation * Time.deltaTime;

                m_cameraTargetYaw += look.x * deltaTimeMultiplier;
                m_cameraTargetPitch += look.y * deltaTimeMultiplier;
            }

            m_cameraTargetYaw = ClampAngle(m_cameraTargetYaw, float.MinValue, float.MaxValue);
            m_cameraTargetPitch = ClampAngle(m_cameraTargetPitch, m_bottomClamp, m_topClamp);

            m_charMoveComponent.Look(Quaternion.Euler(m_cameraTargetPitch, m_cameraTargetYaw, 0f));

        }

        private static float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360f)
            {
                angle += 360f;
            }

            if (angle > 360f)
            {
                angle -= 360f;
            }

            return Mathf.Clamp(angle, min, max);
        }
    }
}
