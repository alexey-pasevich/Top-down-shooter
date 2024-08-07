using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public class WeaponAttackItem : MonoBehaviour, IAttackItem
    {
        [SerializeField] private Transform m_muzzle;
        [SerializeField] private BulletComponent m_prefab;
        [SerializeField] private float m_delay = 0.1f;
        private Coroutine m_fireCoroutine;
        public void StartUse()
        {
            Debug.Log("Start Use", this);

            m_fireCoroutine = StartCoroutine(StartFire());
        }

        public void EndUse()
        {
            Debug.Log("End Use", this);
            if (m_fireCoroutine != null)
            { 
                StopCoroutine(m_fireCoroutine);
                m_fireCoroutine = null;
            }
        }

        private IEnumerator StartFire()
        { 
            var waitForSecond = new WaitForSeconds(m_delay);
            do
            {
                Instantiate(m_prefab, m_muzzle.position, m_muzzle.rotation);
                yield return waitForSecond;
            }
            while (true);
        }
    }
}
