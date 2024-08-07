using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public interface IAttackItem 
    {
        void StartUse();
        void EndUse();
    }
}
