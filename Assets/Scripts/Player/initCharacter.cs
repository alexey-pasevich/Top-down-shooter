using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public class initCharacter : MonoBehaviour
    {
        [SerializeField] private Character m_character;
        [SerializeField] private CharacterSO m_data;

        private void Start()
        {
            if (m_character != null)
            {
                m_character.Initialized(m_data);
            }
        }
    }
}
