using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

namespace TopDownShoot
{

    public class isDeath : DecoratorNode
    {

        HealthComponent healthComponent;
        protected override void OnStart()
        {
            if (healthComponent == null)
            { 
                healthComponent = context.gameObject.GetComponent<HealthComponent>();
            }
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (healthComponent && healthComponent.isDie)
            {
                return child.Update();
            }
            return State.Failure;
        }
    }
}
