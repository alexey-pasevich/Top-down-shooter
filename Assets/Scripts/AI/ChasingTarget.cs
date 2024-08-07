using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

namespace TopDownShoot
{
    [System.Serializable]
    public class ChasingTarget : ActionNode
    {
        public float attackDistance;

        protected override void OnStart()
        {
            context.agent.isStopped = false;
            context.agent.stoppingDistance = attackDistance;
            context.agent.destination = blackboard.moveToPosition;
        }

        protected override void OnStop()
        {
            context.agent.isStopped = true;
        }

        protected override State OnUpdate()
        {
            var target = blackboard.target;
            if (target)
            {
                var agent = context.agent;

                if (Time.frameCount % 3 == 0)
                {
                    agent.isStopped = false;
                    agent.SetDestination(target.position);
                }

                if (agent.pathPending)
                {
                    return State.Running;
                }

                if (agent.remainingDistance < attackDistance)
                {
                    return State.Success;
                }

                if (agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid)
                {
                    return State.Failure;
                }

                return State.Running;
            }
            return State.Failure;
        }
    }
}