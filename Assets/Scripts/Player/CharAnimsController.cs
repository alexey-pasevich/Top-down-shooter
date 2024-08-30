using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public class CharAnimsController : MonoBehaviour
    {
        [SerializeField] private Character m_character;
        [SerializeField] private Animator m_animator;

        private static int SpeedId = Animator.StringToHash("Speed");
        private static int DieID = Animator.StringToHash("DeathAnim");
        private static int ShootId = Animator.StringToHash("Shoot");
        private static int JumpId = Animator.StringToHash("Jump");
        private static int GroundedId = Animator.StringToHash("Grounded");
        private static int FreeFallId = Animator.StringToHash("FreeFall");
        private static int DrivingId = Animator.StringToHash("Driving");
        private IMoveComponent moveComponent => m_character.moveComponent;

        private float m_lastTimeGrounded = 0f;

        private void Start()

        {
            if (m_animator == null)
            {
                m_animator = GetComponent<Animator>();
            }
            if (m_character == null)
            { 
                m_character = GetComponent<Character>();
            }
            m_character = GetComponentInParent<Character>();

            m_character.healthComp.onDie += () =>
            {
                m_animator.SetTrigger(DieID);
            };

            m_character.attackManager.onUse += () =>
            {
                m_animator.SetTrigger(ShootId);
            };

            moveComponent.onJump += () =>
            {
                m_animator.SetBool(GroundedId, false);
                m_animator.SetBool(JumpId, true);
            };
        }


        private void LateUpdate()
        {
            var speed = moveComponent.velocity.magnitude;
            m_animator.SetFloat(SpeedId, speed);

            if (moveComponent.isGrounded)
            {
                m_animator.SetBool(GroundedId, true);
                m_animator.SetBool(FreeFallId, false);
                m_animator.SetBool(JumpId, false);

                m_lastTimeGrounded = Time.time;
            }
            else
            {
                m_animator.SetBool(GroundedId, false);
                if (Time.time - m_lastTimeGrounded > 0.1f)
                {
                    m_animator.SetBool(FreeFallId, true);
                }
            }

            bool driving = m_character.transform.parent != null;
            m_animator.SetBool(DrivingId, driving);
        }
    }
}
