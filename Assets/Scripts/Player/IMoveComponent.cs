using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public interface IMoveComponent 
    {
        void Init(float speed, float sprintSpeed);

        Vector3 velocity { get; }

        bool isGrounded { get; }

        event System.Action onJump;
    }
}
