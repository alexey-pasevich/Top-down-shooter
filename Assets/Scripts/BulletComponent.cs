using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public class BulletComponent : MonoBehaviour
    {
        [SerializeField] private float m_force = 25f;
        [SerializeField] private float m_lifeTime = 5f;
        [SerializeField] private float m_damage = 10f;
        private void Start()
        {
            var rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * m_force, ForceMode.Impulse);

            Destroy(gameObject, m_lifeTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var damageable = collision.gameObject.GetComponentInParent<IDamageable>();
            if (damageable != null)
            { 
                damageable.TakeDamage(m_damage);
            }

            Destroy(gameObject);
        }
    }
}
