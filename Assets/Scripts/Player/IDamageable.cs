using UnityEngine;
using UnityEditor;

namespace TopDownShoot
{ 
    public interface IDamageable
    {
        void TakeDamage(float damage);
    }
}
