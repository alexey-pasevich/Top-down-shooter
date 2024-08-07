using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public class AttackManager : MonoBehaviour
    {
        private List<IAttackItem> m_items = new();
        private int m_currentIndex = -1;


        private void Start()
        {
            GetComponentsInChildren(true, m_items);

            m_currentIndex = m_items.Count > 0 ? 0 : -1;
        }

        public void StartUse()
        {
            if (m_currentIndex >= 0)
            {
                m_items[m_currentIndex].StartUse();
            }
        }
        public void EndUse()
        {
            if (m_currentIndex >= 0)
            {
                m_items[m_currentIndex].EndUse();
            }
        }

        public void Next()
        {
            if (m_items.Count > 0)
            { 
                m_currentIndex++;
                if (m_currentIndex >= m_items.Count)
                {
                    m_currentIndex = 0;
                }
            }
        }
    }
}
