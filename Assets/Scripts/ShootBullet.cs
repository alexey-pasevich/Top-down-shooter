using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public class ShootBullet : MonoBehaviour, IShoot
    {
        [SerializeField] private Transform m_muzzle;
        [SerializeField] private BulletComponent m_prefab;

        public void Shoot()
        {
            Instantiate(m_prefab, m_muzzle.position, m_muzzle.rotation);
        }
    }
}
