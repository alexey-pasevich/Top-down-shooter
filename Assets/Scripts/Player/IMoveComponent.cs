using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public interface IMoveComponent 
    {
        void Init(float speed, float sprintSpeed);
    }
}
