using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

namespace TopDownShoot
{
    public class LookAtTarget : ActionNode

    {
        private float m_angularSpeed;

        protected override void OnStart()
        {
            m_angularSpeed = context.agent ? context.agent.angularSpeed : 36f;
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            var targetPosition = blackboard.target.position;
            var contextTr = context.transform;
            var contextPosition = contextTr.position;

            targetPosition.y = context.transform.position.y;
            var dir = targetPosition - contextPosition;
            contextTr.rotation = Quaternion.RotateTowards(contextTr.rotation, Quaternion.LookRotation(dir), m_angularSpeed * Time.deltaTime);
            return State.Running;
        }
    }
}
