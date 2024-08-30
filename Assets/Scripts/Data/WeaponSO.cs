using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    [CreateAssetMenu(fileName = "WeaponSO", menuName = "TopDownShoot/WeaponSO")]
    public class WeaponSO : ItemBase
    {
        [SerializeField] private WeaponAttackItem m_prefab;
        [SerializeField] private float m_delay = 0.1f;

        [SerializeField] private float m_reloadTime = 1f;

        [SerializeField] private int m_bulletCount = 90;
        [SerializeField] private int m_MaxCage = 30;
        [SerializeField] private int m_cage = 0;
        [SerializeField] private bool m_autoFire = true;
        [SerializeField] private bool m_autoReload = true;
        [SerializeField] private int[] m_bullets;

        public WeaponAttackItem prefab => m_prefab;
        public float delay => m_delay = 0.1f;
        public float reloadTime => m_reloadTime = 1f;
        public int bulletCount => m_bulletCount = 90;
        public int maxCage => m_MaxCage = 30;
        public int cage => m_cage = 0;
        public bool autoFire => m_autoFire = true;
        public bool autoReload => m_autoReload = true;
    }
}
