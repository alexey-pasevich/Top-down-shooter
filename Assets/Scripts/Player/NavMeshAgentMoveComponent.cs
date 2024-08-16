using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TopDownShoot
{
    public class NavMeshAgentMoveComponent : MonoBehaviour, IMoveComponent
    {
        [SerializeField] private NavMeshAgent m_agent;

        public void Init(float speed, float sprintSpeed)
        { 
            m_agent.speed = speed;
        }
    }
}
